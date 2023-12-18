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
    public class TicketsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;

        public TicketsController(AppDbContext context, IServiceProvider service)
        {
            _db = context;
            _userManager = service.GetRequiredService<UserManager<AppUser>>();
        }



        //Here, we get the viewmodel from the reservations controller and begin to ask the customer to select who else they want to register.
        public async Task<IActionResult> CustomerSelection(TicketViewModel tvm)
        {
            TicketViewModel ticketviewmodel = new TicketViewModel();

            ticketviewmodel.arrivingFlightDetailID = tvm.arrivingFlightDetailID;
            ticketviewmodel.departureFlightDetailID = tvm.departureFlightDetailID;
            ticketviewmodel.NumberOfPassengers = tvm.NumberOfPassengers;
            ticketviewmodel.ReservationID = tvm.ReservationID;
            ticketviewmodel.TripType = tvm.TripType;


            var setUpQuery = from u in _db.Users.OrderBy(u => u.AdvantageNumber)
                             select u;

            List<AppUser> allusers = new List<AppUser>();

            allusers = setUpQuery.ToList();

            List<AppUser> Customers = new List<AppUser>();

            foreach (AppUser user in allusers)
            {
                if (await _userManager.IsInRoleAsync(user, "Customer") == true)
                {
                    Customers.Add(user);
                }
            }

            ticketviewmodel.Customers = Customers;
            //execute the query

            //Populate the counts for all books & selected books
            ViewBag.AllUserCount = Customers.Count();

            return View("CustomerSelection", ticketviewmodel);
        }

        

        public IActionResult SeatSelection(TicketViewModel selecteddetails)
        {
            //Copy this bitch over again.
            TicketViewModel ticketviewmodel = new TicketViewModel();

            ticketviewmodel.arrivingFlightDetailID = selecteddetails.arrivingFlightDetailID;
            ticketviewmodel.departureFlightDetailID = selecteddetails.departureFlightDetailID;
            ticketviewmodel.NumberOfPassengers = selecteddetails.NumberOfPassengers;
            ticketviewmodel.ReservationID = selecteddetails.ReservationID;
            ticketviewmodel.TripType = selecteddetails.TripType;
            ticketviewmodel.CustomerEmail = selecteddetails.CustomerEmail;
          


            //First, we need to find the available seats on the flight we are wanting to fly on.

            Int32 departingFlightID = selecteddetails.departureFlightDetailID;
            Int32 arrivingFlightID = selecteddetails.arrivingFlightDetailID;

            //Get the tickets that correspond to the flightdetail that we selected.
            var query = from t in _db.Tickets
                        select t;

            //Narrow the query down to just the ones we have.
            query = query.Where(t => t.Flightdetail.FlightDetailID == selecteddetails.departureFlightDetailID);


            List<Ticket> returningtickets = new List<Ticket>();

            List<Seats> allSeatsrt = new List<Seats>();
            List<Seats> takenSeatsrt = new List<Seats>();
            List<Seats> availableSeatsrt = new List<Seats>();


            //Make the tickets into a list.
            List<Ticket> departingtickets = query.ToList();

            List<Seats> allSeats = new List<Seats>();
            List<Seats> takenSeats = new List<Seats>();
            List<Seats> availableSeats = new List<Seats>();

            allSeats.Add(Seats.OneA);
            allSeats.Add(Seats.OneB);
            allSeats.Add(Seats.TwoA);
            allSeats.Add(Seats.TwoB);
            allSeats.Add(Seats.ThreeA);
            allSeats.Add(Seats.ThreeB);
            allSeats.Add(Seats.ThreeC);
            allSeats.Add(Seats.ThreeD);
            allSeats.Add(Seats.FourA);
            allSeats.Add(Seats.FourB);
            allSeats.Add(Seats.FourC);
            allSeats.Add(Seats.FourD);
            allSeats.Add(Seats.FiveA);
            allSeats.Add(Seats.FiveB);
            allSeats.Add(Seats.FiveC);
            allSeats.Add(Seats.FiveD);

            string strTakenSeats = "Taken Seats: ";


            if (departingtickets.Count == 0)
            {
                availableSeats = allSeats;
            }
            else
            {
                availableSeats = allSeats;
                foreach (Ticket ticket in departingtickets)
                {
                    strTakenSeats = strTakenSeats + ticket.Seat + ", ";
                    takenSeats.Add(ticket.Seat);
                }

                foreach (Seats seat in takenSeats)
                {
                    availableSeats.Remove(seat);
                }
            }

            if (arrivingFlightID != 0)
            {
                var queryrt = from t in _db.Tickets
                              select t;

                queryrt = queryrt.Where(t => t.Flightdetail.FlightDetailID == selecteddetails.arrivingFlightDetailID);

                returningtickets = queryrt.ToList();
                allSeatsrt.Add(Seats.OneA);
                allSeatsrt.Add(Seats.OneB);
                allSeatsrt.Add(Seats.TwoA);
                allSeatsrt.Add(Seats.TwoB);
                allSeatsrt.Add(Seats.ThreeA);
                allSeatsrt.Add(Seats.ThreeB);
                allSeatsrt.Add(Seats.ThreeC);
                allSeatsrt.Add(Seats.ThreeD);
                allSeatsrt.Add(Seats.FourA);
                allSeatsrt.Add(Seats.FourB);
                allSeatsrt.Add(Seats.FourC);
                allSeatsrt.Add(Seats.FourD);
                allSeatsrt.Add(Seats.FiveA);
                allSeatsrt.Add(Seats.FiveB);
                allSeatsrt.Add(Seats.FiveC);
                allSeatsrt.Add(Seats.FiveD);

                string strTakenSeatsrt = "Taken Returning Seats: ";


                if (departingtickets.Count == 0)
                {
                    availableSeatsrt = allSeatsrt;
                }
                else
                {
                    availableSeatsrt = allSeatsrt;
                    foreach (Ticket ticket in returningtickets)
                    {
                        strTakenSeatsrt = strTakenSeatsrt + ticket.Seat + ", ";
                        takenSeatsrt.Add(ticket.Seat);
                    }

                    foreach (Seats seat in takenSeatsrt)
                    {
                        availableSeatsrt.Remove(seat);
                    }
                }

                ViewBag.TakenSeats = strTakenSeats;
                ticketviewmodel.availableDepartureSeats = availableSeats;

                ViewBag.TakenSeatsRT = strTakenSeatsrt;
                ticketviewmodel.availableDepartureSeats = availableSeatsrt;


               return View("SelectSeatsRoundTrip", ticketviewmodel);
            }

            ViewBag.TakenSeats = strTakenSeats;
            ticketviewmodel.availableDepartureSeats = availableSeats;


                return View("SelectSeatsOneWay", ticketviewmodel);



        }










        public async Task<IActionResult> TicketGeneration(TicketViewModel tvm)
        {
            //This makes sure that the seats that were selected are okay before generating the tickets for them.

            TicketViewModel ticketviewmodel = new TicketViewModel();

            ticketviewmodel.arrivingFlightDetailID = tvm.arrivingFlightDetailID;
            ticketviewmodel.departureFlightDetailID = tvm.departureFlightDetailID;
            ticketviewmodel.NumberOfPassengers = tvm.NumberOfPassengers;
            ticketviewmodel.ReservationID = tvm.ReservationID;
            ticketviewmodel.TripType = tvm.TripType;


            var query = from t in _db.Tickets
                        select t;

            var queryrt = from t in _db.Tickets
                          select t;

            //Narrow the query down to just the ones we have.
            query = query.Where(t => t.Flightdetail.FlightDetailID == tvm.departureFlightDetailID);
            queryrt = queryrt.Where(t => t.Flightdetail.FlightDetailID == tvm.arrivingFlightDetailID);



            //Make the tickets into a list.
            List<Ticket> departingtickets = query.ToList();
            List<Ticket> arrivingtickets = queryrt.ToList();

            List<Seats> allSeats = new List<Seats>();
            List<Seats> takenSeats = new List<Seats>();
            List<Seats> availableSeats = new List<Seats>();

            List<Seats> allSeatsrt = new List<Seats>();
            List<Seats> takenSeatsrt = new List<Seats>();
            List<Seats> availableSeatsrt = new List<Seats>();

            allSeats.Add(Seats.OneA);
            allSeats.Add(Seats.OneB);
            allSeats.Add(Seats.TwoA);
            allSeats.Add(Seats.TwoB);
            allSeats.Add(Seats.ThreeA);
            allSeats.Add(Seats.ThreeB);
            allSeats.Add(Seats.ThreeC);
            allSeats.Add(Seats.ThreeD);
            allSeats.Add(Seats.FourA);
            allSeats.Add(Seats.FourB);
            allSeats.Add(Seats.FourC);
            allSeats.Add(Seats.FourD);
            allSeats.Add(Seats.FiveA);
            allSeats.Add(Seats.FiveB);
            allSeats.Add(Seats.FiveC);
            allSeats.Add(Seats.FiveD);

            allSeatsrt.Add(Seats.OneA);
            allSeatsrt.Add(Seats.OneB);
            allSeatsrt.Add(Seats.TwoA);
            allSeatsrt.Add(Seats.TwoB);
            allSeatsrt.Add(Seats.ThreeA);
            allSeatsrt.Add(Seats.ThreeB);
            allSeatsrt.Add(Seats.ThreeC);
            allSeatsrt.Add(Seats.ThreeD);
            allSeatsrt.Add(Seats.FourA);
            allSeatsrt.Add(Seats.FourB);
            allSeatsrt.Add(Seats.FourC);
            allSeatsrt.Add(Seats.FourD);
            allSeatsrt.Add(Seats.FiveA);
            allSeatsrt.Add(Seats.FiveB);
            allSeatsrt.Add(Seats.FiveC);
            allSeatsrt.Add(Seats.FiveD);


            //At this point we are just copying the code above and making sure it works for round trip and one way.

            string strTakenSeats = "Taken Seats: ";
            string strTakenSeatsrt = "Taken Seats: ";


            if (departingtickets.Count == 0)
            {
                availableSeats = allSeats;
            }
            else
            {
                availableSeats = allSeats;
                foreach (Ticket ticket in departingtickets)
                {
                    strTakenSeats = strTakenSeats + ticket.Seat + ", ";
                    takenSeats.Add(ticket.Seat);
                }

                foreach (Seats seat in takenSeats)
                {
                    availableSeats.Remove(seat);
                }
            }

            if (arrivingtickets.Count == 0)
            {
                availableSeatsrt = allSeatsrt;
            }
            else
            {
                availableSeatsrt = allSeatsrt;
                foreach (Ticket ticket in arrivingtickets)
                {
                    strTakenSeatsrt = strTakenSeatsrt + ticket.Seat + ", ";
                    takenSeatsrt.Add(ticket.Seat);
                }

                foreach (Seats seat in takenSeatsrt)
                {
                    availableSeatsrt.Remove(seat);
                }
            }

            tvm.availableDepartureSeats = availableSeats;
            tvm.availableArrivalSeats = availableSeatsrt;

            //Here is where we branch the logic based on if round trip or one way.

            if (tvm.TripType == enumTripType.one_way)
            {
                foreach (Seats seat in tvm.availableDepartureSeats)
                {
                    if (tvm.selectedDepartureSeat == seat)
                    {

                        Ticket ticket = new Ticket();

                        ticket.seatStatus = SeatStatus.Not_Checked_In;
                        ticket.Seat = tvm.selectedDepartureSeat;

                        Reservation reservation = new Reservation();

                        var rquery = from r in _db.Reservations
                                     select r;
                        rquery = rquery.Where(r => r.ReservationID == tvm.ReservationID);

                        List<Reservation> reservationlist = rquery.ToList();

                        reservation = reservationlist.First();

                        ticket.Reservation = reservation;

                        FlightDetail depfd = new FlightDetail();

                        var fdquery = from fd in _db.FlightDetails
                                      select fd;
                        fdquery = fdquery.Where(fd => fd.FlightDetailID == tvm.departureFlightDetailID);

                        List<FlightDetail> fdlist = fdquery.ToList();

                        depfd = fdlist.First();


                        ticket.Flightdetail = depfd;

                        var userquery = from u in _db.Users
                                        select u;
                        userquery = userquery.Where(u => u.Email == tvm.CustomerEmail);

                        List<AppUser> Appusers = userquery.ToList();

                        AppUser user = new AppUser();

                        user = Appusers.First();

                        ticket.Name = user;


                        _db.Add(ticket);
                        await _db.SaveChangesAsync();


                        Int32 ticketCount = _db.Tickets.Count(f => f.Reservation.ReservationID == tvm.ReservationID);

                        //KEVIN: Here is where you should redirect to a different action if they still have tickets to check out with. I would recommend passing the view model to it.
                        if (ticketCount < tvm.NumberOfPassengers)
                        {
                            //KEVIN: We redirect to the tickets controller here and pass along our ticket view model we created earlier.

                            ViewBag.TakenSeats = strTakenSeats;
                            return RedirectToAction("CustomerSelection", ticketviewmodel);
                        }

                        //The code only gets to here if the ticket is 
                        //1. Generated and stored in the database without an error.
                        //2. The ticketCount is greater than the number of passengers.

                        //DAVID IT ENDS HERE.
                        //Otherwise, he would have been redirected to the customerseletion action on the tickets controller above.
                        return RedirectToAction("CheckoutBegin", "Checkout", new { reservationID = tvm.ReservationID });

                    }
                }



                ViewBag.TakenSeats = strTakenSeats;
                ViewBag.ErrorM = "Sorry. That Seat is selected. Please select another seat.";

                return View("SelectSeatsOneWay", tvm);
            }

            //If the code gets here that means that we can now develop the tickets for a round trip flight.

            else
            {
                bool customValidation = true;

                foreach (Seats seat in takenSeats)
                {
                    if (tvm.selectedDepartureSeat == seat)
                    {
                        customValidation = false;
                    }
                }

                foreach (Seats seat in takenSeatsrt)
                {
                    if (tvm.selectedReturnSeat == seat)
                    {
                        customValidation = false;
                    }
                }

                if (customValidation == false)
                {
                    ViewBag.TakenSeats = strTakenSeats;
                    ViewBag.TakenSeatsRT = strTakenSeatsrt;
                    ViewBag.ErrorM = "Sorry, one of the seats you selected is already taken. Please select another seat.";
                    return View("SelectSeatsRoundTrip", tvm);
                }




                foreach (Seats seat in tvm.availableDepartureSeats)
                {
                    if (tvm.selectedDepartureSeat == seat)
                    {

                        Ticket ticket = new Ticket();

                        ticket.seatStatus = SeatStatus.Not_Checked_In;
                        ticket.Seat = tvm.selectedDepartureSeat;

                        Reservation reservation = new Reservation();

                        var rquery = from r in _db.Reservations
                                     select r;
                        rquery = rquery.Where(r => r.ReservationID == tvm.ReservationID);

                        List<Reservation> reservationlist = rquery.ToList();

                        reservation = reservationlist.First();

                        ticket.Reservation = reservation;

                        FlightDetail depfd = new FlightDetail();

                        var fdquery = from fd in _db.FlightDetails
                                      select fd;
                        fdquery = fdquery.Where(fd => fd.FlightDetailID == tvm.departureFlightDetailID);

                        List<FlightDetail> fdlist = fdquery.ToList();

                        depfd = fdlist.First();


                        ticket.Flightdetail = depfd;

                        var userquery = from u in _db.Users
                                        select u;
                        userquery = userquery.Where(u => u.Email == tvm.CustomerEmail);

                        List<AppUser> Appusers = userquery.ToList();

                        AppUser user = new AppUser();

                        user = Appusers.First();

                        ticket.Name = user;

                        _db.Add(ticket);
                        await _db.SaveChangesAsync();
                    }
                }

                foreach (Seats seat in tvm.availableArrivalSeats)
                {
                    if (tvm.selectedReturnSeat == seat)
                    {
                        Ticket ticket = new Ticket();

                        ticket.seatStatus = SeatStatus.Not_Checked_In;
                        ticket.Seat = tvm.selectedReturnSeat;

                        Reservation reservation = new Reservation();

                        var rquery = from r in _db.Reservations
                                     select r;
                        rquery = rquery.Where(r => r.ReservationID == tvm.ReservationID);

                        List<Reservation> reservationlist = rquery.ToList();

                        reservation = reservationlist.First();

                        ticket.Reservation = reservation;

                        FlightDetail arrfd = new FlightDetail();

                        var fdquery = from fd in _db.FlightDetails
                                      select fd;
                        fdquery = fdquery.Where(fd => fd.FlightDetailID == tvm.arrivingFlightDetailID);

                        List<FlightDetail> fdlist = fdquery.ToList();

                        arrfd = fdlist.First();


                        ticket.Flightdetail = arrfd;


                        var userquery = from u in _db.Users
                                        select u;
                        userquery = userquery.Where(u => u.Email == tvm.CustomerEmail);

                        List<AppUser> Appusers = userquery.ToList();

                        AppUser user = new AppUser();

                        user = Appusers.First();

                        ticket.Name = user;

                        _db.Add(ticket);
                        await _db.SaveChangesAsync();


                        Int32 passengerCount = (_db.Tickets.Count(f => f.Reservation.ReservationID == tvm.ReservationID))/2;

                        if (passengerCount < tvm.NumberOfPassengers)
                        {
                            //KEVIN: We redirect to the tickets controller here and pass along our ticket view model we created earlier.
                            //Again, this only happens if the passenger is NOT travelling alone (i.e. they need to buy a ticket for someone else.
                            ViewBag.TakenSeats = strTakenSeats;
                            return RedirectToAction("CustomerSelection", ticketviewmodel);
                        }


                        //The code only gets to here if the ticket is 
                        //1. Generated and stored in the database without an error.
                        //2. The ticketCount is greater than the number of passengers.


                        


                        //Otherwise, he would have been redirected to the customerseletion action on the tickets controller above.
                        //KEVIN: Here is where you should redirect to a different action if they still have tickets to check out with. I would recommend passing the view model to it.
                        return RedirectToAction("CheckoutBegin", "Checkout", new { reservationID = tvm.ReservationID });
                    }
                }


            }

            return View("Error");


        }
    }
}















//        // GET: Tickets
//        public async Task<IActionResult> Index()
//        {
//            return View(await _db.Tickets.ToListAsync());
//        }

//        // GET: Tickets/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var ticket = await _db.Tickets
//                .FirstOrDefaultAsync(m => m.TicketID == id);
//            if (ticket == null)
//            {
//                return NotFound();
//            }

//            return View(ticket);
//        }

//        // GET: Tickets/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Tickets/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("TicketID,Price,Seat")] Ticket ticket)
//        {
//            if (ModelState.IsValid)
//            {
//                _db.Add(ticket);
//                await _db.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(ticket);
//        }

//        // GET: Tickets/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var ticket = await _db.Tickets.FindAsync(id);
//            if (ticket == null)
//            {
//                return NotFound();
//            }
//            return View(ticket);
//        }

//        // POST: Tickets/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("TicketID,Price,Seat")] Ticket ticket)
//        {
//            if (id != ticket.TicketID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _db.Update(ticket);
//                    await _db.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!TicketExists(ticket.TicketID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(ticket);
//        }

//        // GET: Tickets/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var ticket = await _db.Tickets
//                .FirstOrDefaultAsync(m => m.TicketID == id);
//            if (ticket == null)
//            {
//                return NotFound();
//            }

//            return View(ticket);
//        }

//        // POST: Tickets/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var ticket = await _db.Tickets.FindAsync(id);
//            _db.Tickets.Remove(ticket);
//            await _db.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool TicketExists(int id)
//        {
//            return _db.Tickets.Any(e => e.TicketID == id);
//        }
//    }
//}
