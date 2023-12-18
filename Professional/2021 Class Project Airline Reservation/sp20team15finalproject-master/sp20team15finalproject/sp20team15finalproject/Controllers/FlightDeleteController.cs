using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sp20team15finalproject.DAL;
using sp20team15finalproject.Models;
using sp20team15finalproject.Controllers;
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
    public class FlightDeleteController : Controller
    {

        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;

        public FlightDeleteController(AppDbContext context, IServiceProvider service)
        {
            _db = context;
            _userManager = service.GetRequiredService<UserManager<AppUser>>();

        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Flights.ToListAsync());
        }

        public async Task<IActionResult> Delete(int? id)
        {

            //Mark the Flight as de-activated.

            var fquery = from f in _db.Flights
                         select f;

            fquery = fquery.Where(f => f.FlightID == id);

            List<Flight> flights = fquery.ToList();

            Flight flight = flights.First();

            flight.Deactivated = true;

            _db.SaveChanges();


            List < FlightDetail > detailstoremove = new List<FlightDetail>();

            var fdquery = from fd in _db.FlightDetails
                          select fd;

            fdquery = fdquery.Include(fd => fd.Flight)
                .Include(fd => fd.Tickets);

            fdquery = fdquery.Where(fd => fd.Flight.FlightID == id);

            detailstoremove = fdquery.ToList();

            foreach(FlightDetail flightdetail in detailstoremove)
            {
                flightdetail.FlightStatus = Status.Deactivated;
                _db.SaveChanges();
            }


            foreach(FlightDetail fd in detailstoremove)
            {
                var tquery = from t in _db.Tickets
                             select t;

                tquery = tquery.Include(t => t.Flightdetail);
                tquery = tquery.Include(t => t.Name);

                tquery = tquery.Where(t => t.Flightdetail.FlightDetailID == fd.FlightDetailID);


                List<Ticket> disabledtickets = new List<Ticket>();

                disabledtickets = tquery.ToList();

                foreach(Ticket ticket in disabledtickets)
                {
                    ticket.seatStatus = SeatStatus.Canceled;
                    _db.SaveChanges();

                    string useremail;
                    string subject;
                    string body;

                    AppUser user = new AppUser();

                    user = ticket.Name;

                    useremail = user.Email;

                    subject = "We canceled a flight you had a ticket on.";

                    body = "Dear valued customer, we recently canceled flight #" + fd.Flight.FlightNumber + " , a flight you had a ticket on. We have since refunded your money. If you so desire, please make another reservation.";


                    SendMailTest.EmailMessaging.SendEmail(useremail, subject, body);



                }





            }

            
            return View("Confirmation");
        }

    }
}

