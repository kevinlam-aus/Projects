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

namespace sp20team15finalproject.Controllers
{
    public class CheckoutController : Controller
    {

        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;

        public CheckoutController(AppDbContext context, IServiceProvider service)
        {
            _db = context;
            _userManager = service.GetRequiredService<UserManager<AppUser>>();
        }

        public async Task<IActionResult> CheckoutBegin(Int32 reservationid)
        {
            //First, we need to update the price of the tickets!

            //We get the reservation associated with the reservation ID above.
            Reservation reservation = new Reservation();
            List<Reservation> listreservations = new List<Reservation>();
            List<Ticket> listtickets = new List<Ticket>();
            Ticket ticket = new Ticket();

            var rquery = from r in _db.Reservations
                         select r;
            rquery = rquery.Where(r => r.ReservationID == reservationid);

            listreservations = rquery.ToList();
            reservation = listreservations.First();


            var tquery = from t in _db.Tickets
                         select t;
            tquery = tquery.Include(t => t.Reservation);
            tquery = tquery.Include(t => t.Name);
            tquery = tquery.Include(t => t.Flightdetail)
                .ThenInclude(t => t.Flight);
            tquery = tquery.Where(t => t.Reservation.ReservationID == reservationid);

            //Here we have the list of tickets that fit the reservation ID that we have above.
            //Now, we need to update the price on them.

            listtickets = tquery.ToList();

            //Here we are going to do a foreach loop to update the price on each of the tickets.

            

            CheckoutViewModel cvm = new CheckoutViewModel();

            foreach (Ticket selectedticket in listtickets)
            {
                Decimal BaseFare = 0.00m;
                Decimal TotalPrice = 0.00m;

                Int32 MileageCost = 1000;
                

                //Total Price is base fare if it doesn't trigger any of the following discounts / premiums.

                BaseFare = selectedticket.Flightdetail.Flight.BaseFare;
                TotalPrice = BaseFare;

                if (selectedticket.Seat == Seats.OneA)
                {
                    MileageCost = 2000;
                    TotalPrice = BaseFare * 1.2m;
                }
                if (selectedticket.Seat == Seats.OneB)
                {
                    MileageCost = 2000;
                    TotalPrice = BaseFare * 1.2m;
                }
                if (selectedticket.Seat == Seats.TwoA)
                {
                    MileageCost = 2000;
                    TotalPrice = BaseFare * 1.2m;
                }
                if (selectedticket.Seat == Seats.TwoB)
                {
                    MileageCost = 2000;
                    TotalPrice = BaseFare * 1.2m;
                }
                //We have the correct price for first class seats. 

                Int32 CustAge;
                //Now we need to get the customer age for each ticket.

                CustAge = DateTime.Now.Year - selectedticket.Name.DOB.Year;
                if(DateTime.Now.DayOfYear < selectedticket.Name.DOB.DayOfYear)
                {
                    CustAge = CustAge - 1;
                }

                if(CustAge <= 12)
                {
                    if(selectedticket.Seat != Seats.OneA && selectedticket.Seat != Seats.OneB && selectedticket.Seat != Seats.TwoA && selectedticket.Seat != Seats.TwoB)
                    {
                        TotalPrice = BaseFare * 0.85m;
                    }
                }
                if (CustAge >= 65)
                {
                    if (selectedticket.Seat != Seats.OneA && selectedticket.Seat != Seats.OneB && selectedticket.Seat != Seats.TwoA && selectedticket.Seat != Seats.TwoB)
                    {
                        TotalPrice = BaseFare * 0.90m;
                    }
                }

                selectedticket.Price = TotalPrice;
                

                _db.Update(selectedticket);
               
                _db.SaveChanges();

                cvm.MileageCost += MileageCost;

            }

            Decimal ReservationSubtotal = 0.00m;
            Decimal ReservationTheft = 0.00m;
            Decimal ReservationTotal = 0.00m;

            foreach (Ticket resticket in listtickets)
            {
                ReservationSubtotal += resticket.Price;
            }

            ReservationTheft = ReservationSubtotal * 0.0775m;
            ReservationTotal = ReservationTheft + ReservationSubtotal;


            reservation.Subtotal = ReservationSubtotal;
            reservation.Tax = ReservationTheft;
            reservation.TotalPrice = ReservationTotal;
            _db.SaveChanges();


            //Make a viewmodel so that the user can see everything.
            

            cvm.Tickets = listtickets;
            cvm.ReservationID = reservationid;
            cvm.Subtotal = ReservationSubtotal;
            cvm.Theft = ReservationTheft;
            cvm.Total = ReservationTotal;

            cvm.user = await _userManager.FindByNameAsync(User.Identity.Name);

            return View("CheckoutPreliminary", cvm);
        }

        public async Task<IActionResult> CheckoutCreditCard(CheckoutViewModel cvm)
        {
            //We get here if the user selects they want to check out with a credit card.



            return View(cvm);
        }

        public async Task<IActionResult> CheckoutMiles(CheckoutViewModel cvm)
        {
            
            List<Reservation> listreservations = new List<Reservation>();
            List<Ticket> listtickets = new List<Ticket>();
            Ticket ticket = new Ticket();
            Reservation reservation = new Reservation();


            var rquery = from r in _db.Reservations
                         select r;

            rquery = rquery.Include(r => r.User);

            rquery = rquery.Where(r => r.ReservationID == cvm.ReservationID);

            listreservations = rquery.ToList();
            reservation = listreservations.First();


            var tquery = from t in _db.Tickets
                         select t;
            tquery = tquery.Include(t => t.Reservation);
            tquery = tquery.Include(t => t.Name);
            tquery = tquery.Include(t => t.Flightdetail)
                .ThenInclude(t => t.Flight);
            tquery = tquery.Where(t => t.Reservation.ReservationID == cvm.ReservationID);


            listtickets = tquery.ToList();

            //Here we are going to do a foreach loop to update the price on each of the tickets.

            AppUser user = new AppUser();

            user = reservation.User;

            Int32 TotalMileageCost = 0;

            foreach (Ticket selectedticket in listtickets)
            {

                Int32 MileageCost = 1000;

                if (selectedticket.Seat == Seats.OneA)
                {
                    MileageCost = 2000;
                }
                if (selectedticket.Seat == Seats.OneB)
                {
                    MileageCost = 2000;
                }
                if (selectedticket.Seat == Seats.TwoA)
                {
                    MileageCost = 2000;
                }
                if (selectedticket.Seat == Seats.TwoB)
                {
                    MileageCost = 2000;
                }
                
                TotalMileageCost += MileageCost;

            }


            if (user.RewardMiles < TotalMileageCost)
            {
                ViewBag.ErrorMessage = "You Don't have enough miles to complete this. Please pay with card!";
                return RedirectToAction("CheckoutCreditCard", cvm);
            }

            if (user.RewardMiles >= TotalMileageCost)
            {

                foreach (Ticket selectedticket in listtickets)
                {
                    selectedticket.Price = 0;
                }

                reservation.TotalPrice = 0;
                reservation.Tax = 0;
                reservation.Subtotal = 0;

                user.RewardMiles -= TotalMileageCost;

                _db.SaveChanges();

                return RedirectToAction("CheckoutMilesConfirmation", cvm);

                
                
            }

            return View("Error");



        }

        public async Task<IActionResult> CheckoutMilesConfirmation(CheckoutViewModel cvm)
        {
            var tquery = from t in _db.Tickets
                         select t;

            tquery = tquery.Include(t => t.Reservation);
            tquery = tquery.Include(t => t.Name);

            tquery = tquery.Where(t => t.Reservation.ReservationID == cvm.ReservationID);

            List<Ticket> listtickets = new List<Ticket>();

            listtickets = tquery.ToList();

            string primaryuseremail;
            string primarysubject;
            string primarybody;


            var rquery = from r in _db.Reservations
                         select r;

            rquery = rquery.Include(r => r.User);
            rquery = rquery.Where(r => r.ReservationID == cvm.ReservationID);

            
            List<Reservation> reservations = new List<Reservation>();
            reservations = rquery.ToList();

            Reservation primaryres = reservations.First();


            primaryuseremail = primaryres.User.Email;

            string resnumber = Convert.ToString(primaryres.ReservationNumber);

            primarysubject = "Reservation #" + resnumber + " has been completed!";

            String ticketcount = Convert.ToString(listtickets.Count());

            

            primarybody = "Hello! Your reservation, #" + resnumber + " has been completed. You paid with reward miles, so nothing was charged to your credit card." +
                ". You have booked a total of " + ticketcount +
                " tickets. Further information can be found under your reservations on our site! Thank you so much for booking, we hope to see you on board soon!";

            SendMailTest.EmailMessaging.SendEmail(primaryuseremail, primarysubject, primarybody);


            foreach (Ticket ticket in listtickets)
            {
                AppUser user = new AppUser();

                user = ticket.Name;

                string useremail;
                string subject;
                string body;

                useremail = ticket.Name.Email;

                string strticketno = Convert.ToString(ticket.TicketID);

                subject = "Ticket No. " + strticketno + " has been booked!";

                string seatnumber = Convert.ToString(ticket.Seat);

                body = "Hello! This email is to inform you that ticket number " + strticketno + " has been successfully booked! " +
                    "You are in seat #" + seatnumber + "! "
                    + "This is part of reservation number " + resnumber + " that was recently booked by a user with the email " +
                    primaryuseremail + ". You can now view this reservation on our website! We hope to see you on board soon!";

                //Next - test this functionality.

                SendMailTest.EmailMessaging.SendEmail(useremail, subject, body);
            }




            //user = ticket.Name;

            //useremail = user.Email;




            return View("CheckoutConfirmation");
        }

        public async Task<IActionResult> CheckoutConfirmation(CheckoutViewModel cvm)
        {
            var tquery = from t in _db.Tickets
                         select t;

            tquery = tquery.Include(t => t.Reservation);
            tquery = tquery.Include(t => t.Name);

            tquery = tquery.Where(t => t.Reservation.ReservationID == cvm.ReservationID);

            List<Ticket> listtickets = new List<Ticket>();

            listtickets = tquery.ToList();

            string primaryuseremail;
            string primarysubject;
            string primarybody;

            

            //First we send the primary user an email.

            var rquery = from r in _db.Reservations
                         select r;

            rquery = rquery.Include(r => r.User);
            rquery = rquery.Where(r => r.ReservationID == cvm.ReservationID);

            //David - Start here. Need to send a primary email.
            //

            List<Reservation> reservations = new List<Reservation>();
            reservations = rquery.ToList();


            Reservation primaryres = reservations.First();


            primaryuseremail = primaryres.User.Email;

            string resnumber = Convert.ToString(primaryres.ReservationNumber);

            primarysubject = "Reservation #" + resnumber + " has been completed!";

            string subtotalcost = Convert.ToString(primaryres.Subtotal);
            string taxtotalcost = Convert.ToString(primaryres.Tax);
            string totalcost = Convert.ToString(primaryres.TotalPrice);

            string ticketcount = Convert.ToString(listtickets.Count());

            primarybody = "Hello! Your reservation, #" + resnumber + " has been completed. The subtotal is $" + subtotalcost +
                ". The Tax charged on the reservatoin was $" + taxtotalcost + ". The Grand Total is $" + totalcost +
                ". You have booked a total of " + ticketcount +
                " tickets. Further information can be found under your reservations on our site! Thank you so much for booking, we hope to see you on board soon!";

            SendMailTest.EmailMessaging.SendEmail(primaryuseremail, primarysubject, primarybody);


            foreach(Ticket ticket in listtickets)
            {
                AppUser user = new AppUser();

                user = ticket.Name;

                string useremail;
                string subject;
                string body;

                useremail = ticket.Name.Email;

                string strticketno = Convert.ToString(ticket.TicketID);

                subject = "Ticket No. " + strticketno + " has been booked!";

                string seatnumber = Convert.ToString(ticket.Seat);

                body = "Hello! This email is to inform you that ticket number " + strticketno + " has been successfully booked! " +
                    "You are in seat #" + seatnumber + "! "
                    + "This is part of reservation number " + resnumber + " that was recently booked by a user with the email " +
                    primaryuseremail + ". You can now view this reservation on our website! We hope to see you on board soon!";

                //Next - test this functionality.

                SendMailTest.EmailMessaging.SendEmail(useremail, subject, body);
            }




            //user = ticket.Name;

            //useremail = user.Email;




            return View();
        }

        public async Task<IActionResult> GoBackHome(CheckoutViewModel cvm)
        {
            return RedirectToAction("Index","Home");
        }





    }
}
