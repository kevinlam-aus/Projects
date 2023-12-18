using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sp20team15finalproject.DAL;
using sp20team15finalproject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using sp20team15finalproject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.ResponseCaching.Internal;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.ProjectModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sp20team15finalproject.Controllers
{
    [Authorize(Roles = "Admin , Manager, Agent")]
    public class FrontGateController : Controller
    {

        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;

        public FrontGateController(AppDbContext context, IServiceProvider service)
        {
            _db = context;
            _userManager = service.GetRequiredService<UserManager<AppUser>>();

        }

        public IActionResult Index()
        {

            var query = from fd in _db.FlightDetails select fd;

            query.Include(f => f.Flight)
                .ThenInclude(f => f.ArrivingCity);

            query = query.Where(f => f.FlightStatus == Status.Not_Departed);

            query = query.OrderBy(f => f.Date).ThenBy(f => f.FlightDetailID);


            List<FlightDetail> AllFlights = query.Include(f => f.Flight)
                .ThenInclude(f => f.ArrivingCity)
                .Include(f => f.Flight.DepartingCity)
                .ToList();



            return View(AllFlights);
            
        }

        public async Task<IActionResult> Details(int? id)
        {
            FrontGateViewModel viewmodel = new FrontGateViewModel();
            Int32 FDID = Convert.ToInt32(id);
            viewmodel.FlightDetailID = FDID;
            return View(viewmodel);
        }

        public async Task<IActionResult> CheckIn(FrontGateViewModel viewmodel)
        {

            var tquery = from t in _db.Tickets
                         select t;

            tquery = tquery.Include(t => t.Name);


            FlightDetail flightdetail = new FlightDetail();
            List<FlightDetail> flightdetails = new List<FlightDetail>();

            var fquery = from f in _db.FlightDetails
                         select f;
            fquery = fquery.Where(f => f.FlightDetailID == viewmodel.FlightDetailID);
            flightdetails = fquery.ToList();
            flightdetail = flightdetails.First();


            tquery = tquery.Where(t => t.Flightdetail == flightdetail);
            tquery = tquery.Where(t => t.seatStatus == SeatStatus.Not_Checked_In);
            

            List<Ticket> tickets = new List<Ticket>();

            tickets = tquery.ToList();

            viewmodel.tickets = tickets;
            viewmodel.FlightDetailID = viewmodel.FlightDetailID;
            
            return View(viewmodel);
        }

        public async Task<IActionResult> CheckCustomerIn(FrontGateViewModel viewmodel)
        {

            var tquery = from t in _db.Tickets
                         select t;

            tquery = tquery.Where(t => t.TicketID == viewmodel.checkinTicketID);

            List<Ticket> checkinTickets = new List<Ticket>();
            Ticket checkinticket = new Ticket();

            checkinTickets = tquery.ToList();
            checkinticket = checkinTickets.First();

            checkinticket.seatStatus = SeatStatus.Checked_In;

            _db.Update(checkinticket);
            _db.SaveChanges();
            
            

            return RedirectToAction("CheckIn", viewmodel);
        }

        public async Task<IActionResult> FlightDeparture(FrontGateViewModel viewmodel)
        {

            var fdquery = from fd in _db.FlightDetails
                          select fd;

            fdquery = fdquery.Include(f => f.Tickets)
                .Include(f => f.Flight);

            fdquery = fdquery.Where(fd => fd.FlightDetailID == viewmodel.FlightDetailID);
            List<FlightDetail> fds = fdquery.ToList();
            FlightDetail flightdetail = fds.First();

            List<Ticket> tickets = new List<Ticket>();

            bool pilotcheckedin = false;
            bool copilotcheckedin = false;
            bool attendantcheckedin = false;

            bool readytodepart = true;

            foreach(Ticket ticket in flightdetail.Tickets)
            {
                if (ticket.Seat == Seats.Pilot)
                {
                    if (ticket.seatStatus == SeatStatus.Checked_In)
                    {
                        pilotcheckedin = true;
                    }
                }
                if (ticket.Seat == Seats.CoPilot)
                {
                    if (ticket.seatStatus == SeatStatus.Checked_In)
                    {
                        copilotcheckedin = true;
                    }
                }
                if (ticket.Seat == Seats.Attendant)
                {
                    if (ticket.seatStatus == SeatStatus.Checked_In)
                    {
                        attendantcheckedin = true;
                    }
                }
            }

            if(attendantcheckedin == false)
            {
                readytodepart = false;
            }
            if (pilotcheckedin == false)
            {
                readytodepart = false;

            }
            if (copilotcheckedin == false)
            {
                readytodepart = false;
            }

            if (readytodepart == false)
            {
                ViewBag.ErrorMessage = "Flight not Marked as Departed because not all crew are checked in";
                return View();
            }


            //If code gets here that means that the pilot / copilot / attendant are all checked in and the plan is ready to take off.

            //Now, we need to update all of the people's mileage.

            Int32 MilesToAdd;

            MilesToAdd = flightdetail.Flight.Mileage;

            foreach(Ticket ticket in flightdetail.Tickets)
            {
                AppUser user = new AppUser();
                var tquery = from t in _db.Tickets
                             select t
                             ;

                tquery = tquery.Include(t => t.Name);

                tquery = tquery.Where(t => t.TicketID == ticket.TicketID);

                List<Ticket> ticketlist = tquery.ToList();
                Ticket selectedticket = ticketlist.First();


                user = selectedticket.Name;
                //We don't want mileage added to pilots / attendants / copilots
                if (await _userManager.IsInRoleAsync(user, "Customer") == true)
                {
                    if(selectedticket.seatStatus == SeatStatus.Checked_In)
                    {
                        user.RewardMiles += MilesToAdd;
                        _db.Update(ticket.Name);
                        _db.SaveChanges();
                    }
                    else
                    {
                        selectedticket.seatStatus = SeatStatus.Canceled;
                        _db.Update(selectedticket);
                        _db.SaveChanges();
                        
                    }
                    
                }


            }


            //Now, we need to mark this flightdetail as departed.

            flightdetail.FlightStatus = Status.Departed;
            _db.Update(flightdetail);
            _db.SaveChanges();

            ViewBag.SuccessMessage = "The light has been marked as departed and users have received their miles.";

            return View();
        }
    }
}