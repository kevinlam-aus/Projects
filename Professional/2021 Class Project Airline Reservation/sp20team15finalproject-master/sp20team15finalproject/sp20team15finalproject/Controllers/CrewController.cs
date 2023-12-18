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
    [Authorize(Roles = "Admin , Manager")]
    public class CrewController : Controller
    {

        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;

        public CrewController(AppDbContext context, IServiceProvider service)
        {
            _db = context;
            _userManager = service.GetRequiredService<UserManager<AppUser>>();
            
        }
        // GET: /<controller>/
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
            if (id == null)
            {
                return View("Error");
            }

            //We want to be able to see the flight that the user selected. 

            //var query = from t in _db.Tickets
            //            select t;

            //query = query.Include(t => t.Flightdetail);

            //query = query.Where(t => t.Flightdetail.FlightDetailID == id);

            //query = query.Where(t => t.Seat == Seats.Attendant || t.Seat == Seats.Pilot || t.Seat == Seats.CoPilot);


            //List<Ticket> tickets = new List<Ticket>();

            //tickets = query.ToList();


            var query = from t in _db.FlightDetails
                        select t;

            query = query.Include(t => t.Tickets);

            

            query = query.Where(t => t.FlightDetailID == id);


            CrewSearchViewModel viewmodel = new CrewSearchViewModel();


            List<FlightDetail> flightdetails = new List<FlightDetail>();

            flightdetails = query.ToList();

            FlightDetail flightdetail = flightdetails.First();

            List<Ticket> tickets = flightdetail.Tickets.ToList();
            
            

            //Look here. Might need to add another list of tickets onto my viewmodel. That way we can have the list of tickets associated with the flight.

            var tquery = from t in _db.Tickets select t;

            tquery = tquery.Include(t => t.Name);

            tquery = tquery.Where(t => t.Flightdetail == flightdetail);

            List<Ticket> AllTickets = tquery.ToList();
            List<Ticket> StaffTickets = new List<Ticket>();

            foreach (Ticket ticket in AllTickets)
            {
                if (ticket.Seat == Seats.Pilot)
                {
                    StaffTickets.Add(ticket);
                }
                if (ticket.Seat == Seats.CoPilot)
                {
                    StaffTickets.Add(ticket);
                }
                if (ticket.Seat == Seats.Attendant)
                {
                    StaffTickets.Add(ticket);
                }
            }



            viewmodel.tickets = StaffTickets;

            viewmodel.flightdetail = flightdetail;

            viewmodel.FlightDetailID = flightdetail.FlightDetailID;

            return View(viewmodel);
        }


        public async Task<IActionResult> AddPilot(CrewSearchViewModel viewmodel)
        {
            var query = from u in _db.Users
                        select u;


            List<AppUser> allusers = new List<AppUser>();

            allusers = query.ToList();

            List < AppUser > pilots = new List<AppUser>();

            foreach(AppUser user in allusers)
            {
                if(await _userManager.IsInRoleAsync(user, "Pilot") == true)
                {
                    pilots.Add(user);
                }
            }

            

            CrewSearchViewModel csvm = new CrewSearchViewModel();
            csvm.FlightDetailID = viewmodel.FlightDetailID;

            csvm.Pilots = pilots;


            return View(csvm);
        }
        public async Task<ActionResult> AddNewPilot(CrewSearchViewModel viewmodel)
        {


            var query = from t in _db.FlightDetails
                        select t;

            query = query.Include(t => t.Tickets);

            query = query.Where(t => t.FlightDetailID == viewmodel.FlightDetailID);
            List<FlightDetail> flightdetails = new List<FlightDetail>();
            flightdetails = query.ToList();

            FlightDetail flightDetail = new FlightDetail();

            FlightDetail flightdetail = flightdetails.First();

            List<Ticket> tickets = new List<Ticket>();

            foreach (Ticket ticket in flightdetail.Tickets)
            {
                tickets.Add(ticket);

                if (ticket.Seat != Seats.Pilot)
                {
                    tickets.Remove(ticket);
                }
            }

            if(tickets.Count == 0)
            {
                Ticket ticket = new Ticket();

                ticket.Flightdetail = flightdetail;

                ticket.Seat = Seats.Pilot;

                AppUser user = new AppUser();

                user = await _userManager.FindByNameAsync(viewmodel.PilotEmail);

                ticket.Name = user;

                ticket.seatStatus = SeatStatus.Not_Checked_In;

                _db.Add(ticket);
                await _db.SaveChangesAsync();

            }
            else
            {
                List<Ticket> badtickets = new List<Ticket>();

                foreach (Ticket badticket in flightdetail.Tickets)
                {
                    badtickets.Add(badticket);
                }

                foreach(Ticket tickettoremove in badtickets)
                {
                    if(tickettoremove.Seat == Seats.Pilot)
                    {
                        _db.Remove(tickettoremove);
                        await _db.SaveChangesAsync();
                    }
                    
                }

                Ticket ticket = new Ticket();

                ticket.Flightdetail = flightdetail;

                ticket.Seat = Seats.Pilot;

                AppUser user = new AppUser();

                user = await _userManager.FindByNameAsync(viewmodel.PilotEmail);

                ticket.Name = user;

                ticket.seatStatus = SeatStatus.Not_Checked_In;

                _db.Add(ticket);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");



        }


        //Here we are going to add a co-pilot

        public async Task<IActionResult> AddCoPilot(CrewSearchViewModel viewmodel)
        {
            var query = from u in _db.Users
                        select u;


            List<AppUser> allusers = new List<AppUser>();

            allusers = query.ToList();

            List<AppUser> pilots = new List<AppUser>();

            foreach (AppUser user in allusers)
            {
                if (await _userManager.IsInRoleAsync(user, "CoPilot") == true)
                {
                    pilots.Add(user);
                }
            }



            CrewSearchViewModel csvm = new CrewSearchViewModel();
            csvm.FlightDetailID = viewmodel.FlightDetailID;

            csvm.Pilots = pilots;


            return View(csvm);
        }
        public async Task<ActionResult> AddNewCoPilot(CrewSearchViewModel viewmodel)
        {
            var query = from t in _db.FlightDetails
                        select t;

            query = query.Include(t => t.Tickets);

            query = query.Where(t => t.FlightDetailID == viewmodel.FlightDetailID);
            List<FlightDetail> flightdetails = new List<FlightDetail>();
            flightdetails = query.ToList();

            FlightDetail flightDetail = new FlightDetail();

            FlightDetail flightdetail = flightdetails.First();

            List<Ticket> tickets = new List<Ticket>();

            foreach (Ticket ticket in flightdetail.Tickets)
            {
                tickets.Add(ticket);

                if (ticket.Seat != Seats.CoPilot)
                {
                    tickets.Remove(ticket);
                }
            }

            if (flightdetail.Tickets.Count == 0)
            {
                Ticket ticket = new Ticket();

                ticket.Flightdetail = flightdetail;

                ticket.Seat = Seats.CoPilot;

                AppUser user = new AppUser();

                user = await _userManager.FindByNameAsync(viewmodel.PilotEmail);

                ticket.Name = user;

                ticket.seatStatus = SeatStatus.Not_Checked_In;

                _db.Add(ticket);
                await _db.SaveChangesAsync();

            }
            else
            {
                List<Ticket> badtickets = new List<Ticket>();

                foreach (Ticket badticket in flightdetail.Tickets)
                {
                    badtickets.Add(badticket);
                }

                foreach (Ticket tickettoremove in badtickets)
                {
                    if (tickettoremove.Seat == Seats.CoPilot)
                    {
                        _db.Remove(tickettoremove);
                        await _db.SaveChangesAsync();
                    }
                    
                }

                Ticket ticket = new Ticket();

                ticket.Flightdetail = flightdetail;

                ticket.Seat = Seats.CoPilot;

                AppUser user = new AppUser();

                user = await _userManager.FindByNameAsync(viewmodel.PilotEmail);

                ticket.Name = user;

                ticket.seatStatus = SeatStatus.Not_Checked_In;

                _db.Add(ticket);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");



        }


        //Add an attendant
        public async Task<IActionResult> AddAttendant(CrewSearchViewModel viewmodel)
        {
            var query = from u in _db.Users
                        select u;


            List<AppUser> allusers = new List<AppUser>();

            allusers = query.ToList();

            List<AppUser> pilots = new List<AppUser>();

            foreach (AppUser user in allusers)
            {
                if (await _userManager.IsInRoleAsync(user, "FlightAttendant") == true)
                {
                    pilots.Add(user);
                }
            }



            CrewSearchViewModel csvm = new CrewSearchViewModel();
            csvm.FlightDetailID = viewmodel.FlightDetailID;

            csvm.Pilots = pilots;


            return View(csvm);
        }
        public async Task<ActionResult> AddNewAttendant(CrewSearchViewModel viewmodel)
        {
            var query = from t in _db.FlightDetails
                        select t;

            query = query.Include(t => t.Tickets);

            query = query.Where(t => t.FlightDetailID == viewmodel.FlightDetailID);
            List<FlightDetail> flightdetails = new List<FlightDetail>();
            flightdetails = query.ToList();

            FlightDetail flightDetail = new FlightDetail();

            FlightDetail flightdetail = flightdetails.First();

            List<Ticket> tickets = new List<Ticket>();

            foreach (Ticket ticket in flightdetail.Tickets)
            {
                tickets.Add(ticket);

                if (ticket.Seat != Seats.Attendant)
                {
                    tickets.Remove(ticket);
                }
            }

            if (flightdetail.Tickets.Count == 0)
            {
                Ticket ticket = new Ticket();

                ticket.Flightdetail = flightdetail;

                ticket.Seat = Seats.Attendant;

                AppUser user = new AppUser();

                user = await _userManager.FindByNameAsync(viewmodel.PilotEmail);

                ticket.Name = user;

                ticket.seatStatus = SeatStatus.Not_Checked_In;

                _db.Add(ticket);
                await _db.SaveChangesAsync();

            }
            else
            {
                List<Ticket> badtickets = new List<Ticket>();

                foreach (Ticket badticket in flightdetail.Tickets)
                {
                    badtickets.Add(badticket);
                }

                foreach (Ticket tickettoremove in badtickets)
                {
                    if (tickettoremove.Seat == Seats.Attendant)
                    {
                        _db.Remove(tickettoremove);
                        await _db.SaveChangesAsync();
                    }
                }

                Ticket ticket = new Ticket();

                ticket.Flightdetail = flightdetail;

                ticket.Seat = Seats.Attendant;

                AppUser user = new AppUser();

                user = await _userManager.FindByNameAsync(viewmodel.PilotEmail);

                ticket.Name = user;

                ticket.seatStatus = SeatStatus.Not_Checked_In;

                _db.Add(ticket);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");



        }


    }
}
