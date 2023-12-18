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
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ReservationsController(AppDbContext context, IServiceProvider service)
        {
            _context = context;
            _userManager = service.GetRequiredService<UserManager<AppUser>>();
        }

        //Here we return all of the reservations the User Has.
        //This might need some more complicated code and queries to show the reservations the User is in but didn't make for themselves.
        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            List<Reservation> reservations = new List<Reservation>();

            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Agent"))
            {

                var userreservations = _context.Reservations.Include(r => r.Tickets).ToList();

                return View(userreservations);
                
            }
            else //user is customer
            {

                var query = from t in _context.Tickets
                            select t;

                query = query.Include(t => t.Reservation);
                query = query.Include(t => t.Name);

                query = query.Where(t => t.Name.UserName == User.Identity.Name);

                query = query.Where(t => t.seatStatus != SeatStatus.Canceled);

                List<Ticket> listtickets = query.ToList();

                List<Reservation> userreservations = new List<Reservation>();

                foreach(Ticket ticket in listtickets)
                {
                    userreservations.Add(ticket.Reservation);
                }

                return View(userreservations);


            }


            return View("Error");
        }



        //First, we ask the user if this is round trip or One way.
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> TripDetailsEntry()
        {
            FlightTripTypeSearchViewModel fttsvm = new FlightTripTypeSearchViewModel();
            fttsvm.SearchTripType = enumTripType.round_trip;
            return View(fttsvm);
        }

        public ActionResult TripInformationEntry(FlightTripTypeSearchViewModel fttsvm)
        {
            //We are going to make a reservation search view model to pass into the view.
            ReservationSearchViewModel rsvm = new ReservationSearchViewModel();

            //This goes if the person selects one way.
            if (fttsvm.SearchTripType == enumTripType.one_way)
            {
                rsvm.TripType = enumTripType.one_way;
                ViewBag.AllCities = GetAllCities();
                return View("TripInformationEntryOneWay", rsvm);
            }

            //This goes if the person selects round trip.
            if (fttsvm.SearchTripType == enumTripType.round_trip)
            {
                rsvm.TripType = enumTripType.round_trip;
                ViewBag.AllCities = GetAllCities();
                return View("TripInformationEntryRoundTrip", rsvm);
            }

            return View(fttsvm);
        }

        //Now that we have all of our information, we can begin searching for it!
        //TODO: add code here that makes sure that there are available seats on this flight at least to the number of passengers they selected.
        public async Task<IActionResult> DepartingFlightSearchAsync(ReservationSearchViewModel rsvm)
        {
            //Going to validate our model here.
            bool customModelStateIsValid;

            //At this point, we have ALL THE INFORMATION THE CUSTOMER NEEDS TO PUT IN
            //FIRST, WE VALIDATE IT:

            customModelStateIsValid = true;

            TryValidateModel(rsvm);

            if (rsvm.departingCityID == rsvm.arrivalCityID)
            {
                customModelStateIsValid = false;
                ViewBag.ErrorMessage = "Departing City Can't be the same as Arriving City";
            }

            if (rsvm.arrivalDate != new DateTime(0001, 1, 1))
            {
                if (rsvm.arrivalDate <= rsvm.departureDate)
                {
                    customModelStateIsValid = false;
                    ViewBag.ErrorMessage = "Departure Date can't be after Re-Arrival Date";
                }

                if (rsvm.arrivalDate.Date < new DateTime(2020, 5, 8))
                {

                    customModelStateIsValid = false;
                    ViewBag.ErrorMessage = "Arrival Date must be on or after May 8, 2020";
                }
            }


            if (rsvm.departureDate.Date < new DateTime(2020, 5, 8))
            {

                customModelStateIsValid = false;
                ViewBag.ErrorMessage = "Departure Date must be on or after May 8, 2020";
            }


            if (rsvm.TripType == enumTripType.round_trip)
            {
                if (rsvm.departureDate == new DateTime(0001, 1, 1))
                {
                    customModelStateIsValid = false;
                    ViewBag.ErrorMessage = "Please specify a departure Date.";
                }

                if (rsvm.arrivalDate == new DateTime(0001, 1, 1))
                {
                    customModelStateIsValid = false;
                    ViewBag.ErrorMessage = "Please specify an arrival Date.";
                }
            }

            if (rsvm.TripType == enumTripType.one_way)
            {
                if (rsvm.departureDate == new DateTime(0001, 1, 1))
                {
                    customModelStateIsValid = false;
                    ViewBag.ErrorMessage = "Please specify a departure Date.";
                }
            }

            if (ModelState.IsValid == false || customModelStateIsValid == false)
            {
                if (rsvm.TripType == enumTripType.one_way)
                {
                    ViewBag.AllCities = GetAllCities();
                    return View("TripInformationEntryOneWay", rsvm);
                }
                if (rsvm.TripType == enumTripType.round_trip)
                {
                    ViewBag.AllCities = GetAllCities();
                    return View("TripInformationEntryRoundTrip", rsvm);
                }
            }

            //THEN, WE SEE IF THE FLIGHT EXIST IF THE DATA IS GOOD.

            var queryD = from fd in _context.FlightDetails select fd;

            queryD.Include(f => f.Flight)
                .ThenInclude(f => f.ArrivingCity);

            if (rsvm.departureDate != null)
            {
                queryD = queryD.Where(fd => fd.Date.Date == rsvm.departureDate);
            }

            if (rsvm.departingCityID != 0)
            {
                queryD = queryD.Where(fd => fd.Flight.DepartingCity.CityID == rsvm.departingCityID);
            }

            if (rsvm.arrivalCityID != 0)
            {
                queryD = queryD.Where(fd => fd.Flight.ArrivingCity.CityID == rsvm.arrivalCityID);
            }

            List<FlightDetail> depdetails = queryD.Include(f => f.Flight)
                .ThenInclude(f => f.ArrivingCity)
                .Include(f => f.Flight.DepartingCity)
                .ToList();

            List<FlightDetail> DepartingFlights = new List<FlightDetail>();


            foreach (FlightDetail fd in depdetails)
            {
                if(fd.FlightStatus == Status.Not_Departed)
                {
                    DepartingFlights.Add(fd);
                }
            }



            


            //THIS ONLY TRIGGERS IF THERE IS NO ARRIVAL DATE, THUS INDICATING IT's A ONE WAY TRIP.

            if (rsvm.arrivalDate == new DateTime(0001, 1, 1))
            {
                //Returns an error if no flights were found.
                if (DepartingFlights.Count == 0)
                {
                    ViewBag.AllCities = GetAllCities();
                    ViewBag.errormess = "We do not offer a flight to that city during that day.";
                    return View("ErrorTripInformationEntryOneWay");
                }
                //If the code gets to this point, that means that there are flights available for the user to purchase.
                else
                {
                    //Returns the one-way departing flight results.
                    //First, we make a new reservation and store it in our database.
                    Reservation reservation = new Reservation();

                    reservation.ReservationNumber = Utilities.GenerateNextReservationNumber.GetNextReservationNumber(_context);
                    reservation.ReservationDate = DateTime.Now;

                    //Now we need to see the user that is logged in and placing the order.

                    AppUser user = new AppUser();

                    user = await _userManager.FindByNameAsync(User.Identity.Name);

                    reservation.User = user;

                    if (ModelState.IsValid)
                    {
                        _context.Add(reservation);
                        await _context.SaveChangesAsync();
          
                    }

                    //At this point, we know we have our reservation in our database. Now, we need a viewmodel to pass all the info in.
                    //We are building off of the old rsvm by adding the ability to select specific flights.

                    ReservationSelectionViewModel rsfvm = new ReservationSelectionViewModel();

                    rsfvm.ReservationID = reservation.ReservationID;
                    rsfvm.arrivalCityID = rsvm.arrivalCityID;
                    rsfvm.arrivalDate = rsvm.arrivalDate;
                    rsfvm.arrivingFlightDetails = null;
                    rsfvm.departingCityID = rsvm.departingCityID;
                    rsfvm.departingFlightDetails = DepartingFlights;
                    rsfvm.departureDate = rsvm.departureDate;
                    rsfvm.NumberOfPassengers = rsvm.NumberOfPassengers;
                    rsfvm.TripType = rsvm.TripType;
                    ViewBag.DepartingFlights = getflights(DepartingFlights); 



                    return View("DepartingFlightResultsOW", rsfvm);
                }
            }


            else
            {
                var queryR = from fdr in _context.FlightDetails select fdr;

                queryR.Include(f => f.Flight)
                    .ThenInclude(f => f.ArrivingCity);

                if (rsvm.arrivalDate != null)
                {
                    queryR = queryR.Where(fdr => fdr.Date.Date == rsvm.arrivalDate);
                }

                if (rsvm.departingCityID != 0)
                {
                    queryR = queryR.Where(fdr => fdr.Flight.DepartingCity.CityID == rsvm.arrivalCityID);
                }

                if (rsvm.arrivalCityID != 0)
                {
                    queryR = queryR.Where(fdr => fdr.Flight.ArrivingCity.CityID == rsvm.departingCityID);
                }


                List<FlightDetail> arrdetails = queryR.Include(f => f.Flight)
                    .ThenInclude(f => f.ArrivingCity)
                    .Include(f => f.Flight.DepartingCity)
                    .ToList();

                List<FlightDetail> ReturningFlights = new List<FlightDetail>();


                foreach (FlightDetail fd in arrdetails)
                {
                    if (fd.FlightStatus == Status.Not_Departed)
                    {
                        ReturningFlights.Add(fd);
                    }
                }

                


                if (DepartingFlights.Count == 0 || ReturningFlights.Count == 0)
                { 
                    ViewBag.AllCities = GetAllCities();
                    ViewBag.errormess = "We do not offer a flight to that city during that day.";
                    return View("ErrorTripInformationEntryRoundTrip");
                }

                else
                {
                    Reservation reservation = new Reservation();

                    reservation.ReservationNumber = Utilities.GenerateNextReservationNumber.GetNextReservationNumber(_context);
                    reservation.ReservationDate = DateTime.Now;

                    //Now we need to see the user that is logged in and placing the order.

                    AppUser user = new AppUser();

                    user = await _userManager.FindByNameAsync(User.Identity.Name);

                    reservation.User = user;

                    if (ModelState.IsValid)
                    {
                        _context.Add(reservation);
                        await _context.SaveChangesAsync();

                    }

                    //At this point, we know we have our reservation in our database. Now, we need a viewmodel to pass all the info in.
                    //We are building off of the old rsvm by adding the ability to select specific flights.

                    ReservationSelectionViewModel rsfvm = new ReservationSelectionViewModel();

                    rsfvm.ReservationID = reservation.ReservationID;
                    rsfvm.arrivalCityID = rsvm.arrivalCityID;
                    rsfvm.arrivalDate = rsvm.arrivalDate;
                    
                    rsfvm.departingCityID = rsvm.departingCityID;
                    rsfvm.departingFlightDetails = DepartingFlights;
                    rsfvm.departureDate = rsvm.departureDate;
                    rsfvm.NumberOfPassengers = rsvm.NumberOfPassengers;
                    rsfvm.TripType = rsvm.TripType;

                    ViewBag.DepartingFlights = getflights(DepartingFlights);
                    ViewBag.ReturningFlights = getflights(ReturningFlights);

                    rsfvm.arrivingFlightDetails = ReturningFlights;

                    return View("DepartingFlightResultsRTD", rsfvm);
                }
            }

        }


        //public IActionResult ReturningFlightSearch(int id, ReservationSearchViewModel rsvm)
        //{
        //    ReservationSelectedFlightViewModel rsfvm = new ReservationSelectedFlightViewModel();
        //    rsfvm.departureFlightDetailID = id;

        //    var queryR = from fdr in _context.FlightDetails select fdr;

        //    queryR.Include(f => f.Flight)
        //        .ThenInclude(f => f.ArrivingCity);

        //    if (rsvm.arrivalDate != null)
        //    {
        //        queryR = queryR.Where(fdr => fdr.Date.Date == rsvm.arrivalDate);
        //    }

        //    if (rsvm.departingCityID != 0)
        //    {
        //        queryR = queryR.Where(fdr => fdr.Flight.DepartingCity.CityID == rsvm.departingCityID);
        //    }

        //    if (rsvm.arrivalCityID != 0)
        //    {
        //        queryR = queryR.Where(fdr => fdr.Flight.ArrivingCity.CityID == rsvm.arrivalCityID);
        //    }

        //    List<FlightDetail> ReturningFlights = queryR.Include(f => f.Flight)
        //        .ThenInclude(f => f.ArrivingCity)
        //        .Include(f => f.Flight.DepartingCity)
        //        .ToList();

        //    return View("DepartingFlightResultsRTR", ReturningFlights);
        //}

        public IActionResult AddFlightToCart(ReservationSelectionViewModel rsvfm)
        {
            //OK WHEN WE GET TO THIS WE HAVE A VIEWMODEL WITH ALL THE INFO THE USER ENTERED AND THE FLIGHTS THEY WANT TO SELECT.
            //WE HAVE TO MAKE A NEW VIEWMODEL TO GET THAT SWEET PSEUDO-PERSISTENCE THAT WE ALL KNOW, LOVE, AND HATE.
            //WE JUST UPDATE THIS BITCH WITH ALL THE THINGS WE WANT.
            ReservationSelectionViewModel viewmodel = new ReservationSelectionViewModel();

            viewmodel.ReservationID = rsvfm.ReservationID;
            viewmodel.arrivalCityID = rsvfm.arrivalCityID;
            viewmodel.arrivalDate = rsvfm.arrivalDate;
            viewmodel.departingCityID = rsvfm.departingCityID;
            viewmodel.departingFlightDetails = rsvfm.departingFlightDetails;
            viewmodel.departureDate = rsvfm.departureDate;
            viewmodel.NumberOfPassengers = rsvfm.NumberOfPassengers;
            viewmodel.TripType = rsvfm.TripType;

            viewmodel.arrivingFlightDetailID = rsvfm.arrivingFlightDetailID;
            viewmodel.arrivingFlightDetails = rsvfm.arrivingFlightDetails;
            viewmodel.departureFlightDetailID = rsvfm.departureFlightDetailID;

            return RedirectToAction("SeatSelection", viewmodel);

        }

        public IActionResult SeatSelection(ReservationSelectionViewModel selecteddetails)
        {
            //Copy this bitch over again.
            ReservationSelectionViewModel viewmodel = new ReservationSelectionViewModel();

            viewmodel.ReservationID = selecteddetails.ReservationID;
            viewmodel.arrivalCityID = selecteddetails.arrivalCityID;
            viewmodel.arrivalDate = selecteddetails.arrivalDate;
            viewmodel.departingCityID = selecteddetails.departingCityID;
            viewmodel.departingFlightDetails = selecteddetails.departingFlightDetails;
            viewmodel.departureDate = selecteddetails.departureDate;
            viewmodel.NumberOfPassengers = selecteddetails.NumberOfPassengers;
            viewmodel.TripType = selecteddetails.TripType;

            viewmodel.arrivingFlightDetailID = selecteddetails.arrivingFlightDetailID;
            viewmodel.arrivingFlightDetails = selecteddetails.arrivingFlightDetails;
            viewmodel.departureFlightDetailID = selecteddetails.departureFlightDetailID;

            //First, we need to find the available seats on the flight we are wanting to fly on.

            Int32 departingFlightID = selecteddetails.departureFlightDetailID;
            Int32 arrivingFlightID = selecteddetails.arrivingFlightDetailID;

            //Get the tickets that correspond to the flightdetail that we selected.
            var query = from t in _context.Tickets
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
                var queryrt = from t in _context.Tickets
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
                viewmodel.availableDepartureSeats = availableSeats;

                ViewBag.TakenSeatsRT = strTakenSeatsrt;
                viewmodel.availableDepartureSeats = availableSeatsrt;

                if (viewmodel.NumberOfPassengers > availableSeats.Count)
                {
                    ViewBag.errormess = "We do not have enough seats on that flight.";
                    ViewBag.AllCities = GetAllCities();
                    return View("ErrorTripInformationRoundTrip");
                }
                else
                {
                    return View("SelectSeatsRoundTrip", viewmodel);
                }
            }

            ViewBag.TakenSeats = strTakenSeats;
            viewmodel.availableDepartureSeats = availableSeats;



            if (viewmodel.NumberOfPassengers > availableSeats.Count)
            {
                ViewBag.errormess = "We do not have enough seats on that flight.";
                ViewBag.AllCities = GetAllCities();
                return View("ErrorTripInformationEntryOneWay");
            }
            else
            {
                return View("SelectSeatsOneWay", viewmodel);
            }



        }

        public async Task<IActionResult> TicketGeneration(ReservationSelectionViewModel selecteddetails)
        {
            //This makes sure that the seats that were selected are okay before generating the tickets for them.

            TicketViewModel ticketviewmodel = new TicketViewModel();

            ticketviewmodel.arrivingFlightDetailID = selecteddetails.arrivingFlightDetailID;
            ticketviewmodel.departureFlightDetailID = selecteddetails.departureFlightDetailID;
            ticketviewmodel.NumberOfPassengers = selecteddetails.NumberOfPassengers;
            ticketviewmodel.ReservationID = selecteddetails.ReservationID;
            ticketviewmodel.TripType = selecteddetails.TripType;


            var query = from t in _context.Tickets
                        select t;

            var queryrt = from t in _context.Tickets
                          select t;

            //Narrow the query down to just the ones we have.
            query = query.Where(t => t.Flightdetail.FlightDetailID == selecteddetails.departureFlightDetailID);
            queryrt = queryrt.Where(t => t.Flightdetail.FlightDetailID == selecteddetails.arrivingFlightDetailID);



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

            selecteddetails.availableDepartureSeats = availableSeats;
            selecteddetails.availableArrivalSeats = availableSeatsrt;

            //Here is where we branch the logic based on if round trip or one way.

            if (selecteddetails.TripType == enumTripType.one_way)
            {
                foreach (Seats seat in selecteddetails.availableDepartureSeats)
                {
                    if (selecteddetails.selectedDepartureSeat == seat)
                    {

                        Ticket ticket = new Ticket();

                        ticket.seatStatus = SeatStatus.Not_Checked_In;
                        ticket.Seat = selecteddetails.selectedDepartureSeat;

                        Reservation reservation = new Reservation();

                        var rquery = from r in _context.Reservations
                                     select r;
                        rquery = rquery.Where(r => r.ReservationID == selecteddetails.ReservationID);

                        List<Reservation> reservationlist = rquery.ToList();

                        reservation = reservationlist.First();

                        ticket.Reservation = reservation;

                        FlightDetail depfd = new FlightDetail();

                        var fdquery = from fd in _context.FlightDetails
                                      select fd;
                        fdquery = fdquery.Where(fd => fd.FlightDetailID == selecteddetails.departureFlightDetailID);

                        List<FlightDetail> fdlist = fdquery.ToList();

                        depfd = fdlist.First();


                        ticket.Flightdetail = depfd;

                        AppUser user = new AppUser();

                        user = await _userManager.FindByNameAsync(User.Identity.Name);

                        ticket.Name = user;


                        _context.Add(ticket);
                        await _context.SaveChangesAsync();


                        //KEVIN: Here is where you should redirect to a different action if they still have tickets to check out with. I would recommend passing the view model to it.
                        if (selecteddetails.NumberOfPassengers != 1)
                        {
                            //KEVIN: We redirect to the tickets controller here and pass along our ticket view model we created earlier.
                            
                            ViewBag.TakenSeats = strTakenSeats;
                            return RedirectToAction("CustomerSelection", "Tickets", ticketviewmodel);
                        }

                        //The code only gets to here if the ticket is 
                            //1. Generated and stored in the database without an error.
                            //2. The passenger is only buying a ticket for himself.

                        //Otherwise, he would have been redirected to the customerseletion action on the tickets controller above.
                        return RedirectToAction("CheckoutBegin","Checkout", new { reservationID = selecteddetails.ReservationID });

                    }
                }



                ViewBag.TakenSeats = strTakenSeats;
                ViewBag.ErrorMessage = "Sorry. That Seat is selected. Please select another seat.";

                return View("SelectSeatsOneWay", selecteddetails);
            }

            //If the code gets here that means that we can now develop the tickets for a round trip flight.

            else
            {
                bool customValidation = true;

                foreach(Seats seat in takenSeats)
                {
                    if (selecteddetails.selectedDepartureSeat == seat)
                    {
                        customValidation = false;
                    }
                }

                foreach (Seats seat in takenSeatsrt)
                {
                    if (selecteddetails.selectedReturnSeat == seat)
                    {
                        customValidation = false;
                    }
                }

                if(customValidation == false)
                {
                    ViewBag.TakenSeats = strTakenSeats;
                    ViewBag.TakenSeatsRT = strTakenSeatsrt;
                    ViewBag.ErrorMessage = "Sorry, one of the seats you selected is already taken. Please select another seat.";
                    return View("SelectSeatsRoundTrip", selecteddetails);
                }




                foreach (Seats seat in selecteddetails.availableDepartureSeats)
                {
                    if (selecteddetails.selectedDepartureSeat == seat)
                    {

                        Ticket ticket = new Ticket();

                        ticket.seatStatus = SeatStatus.Not_Checked_In;
                        ticket.Seat = selecteddetails.selectedDepartureSeat;

                        Reservation reservation = new Reservation();

                        var rquery = from r in _context.Reservations
                                     select r;
                        rquery = rquery.Where(r => r.ReservationID == selecteddetails.ReservationID);

                        List<Reservation> reservationlist = rquery.ToList();

                        reservation = reservationlist.First();

                        ticket.Reservation = reservation;

                        FlightDetail depfd = new FlightDetail();

                        var fdquery = from fd in _context.FlightDetails
                                      select fd;
                        fdquery = fdquery.Where(fd => fd.FlightDetailID == selecteddetails.departureFlightDetailID);

                        List<FlightDetail> fdlist = fdquery.ToList();

                        depfd = fdlist.First();


                        ticket.Flightdetail = depfd;

                        AppUser user = new AppUser();

                        user = await _userManager.FindByNameAsync(User.Identity.Name);

                        ticket.Name = user;

                        _context.Add(ticket);
                        await _context.SaveChangesAsync();
                    }
                }

                foreach (Seats seat in selecteddetails.availableArrivalSeats)
                {
                    if(selecteddetails.selectedReturnSeat == seat)
                    {
                        Ticket ticket = new Ticket();

                        ticket.seatStatus = SeatStatus.Not_Checked_In;
                        ticket.Seat = selecteddetails.selectedReturnSeat;

                        Reservation reservation = new Reservation();

                        var rquery = from r in _context.Reservations
                                     select r;
                        rquery = rquery.Where(r => r.ReservationID == selecteddetails.ReservationID);

                        List<Reservation> reservationlist = rquery.ToList();

                        reservation = reservationlist.First();

                        ticket.Reservation = reservation;

                        FlightDetail arrfd = new FlightDetail();

                        var fdquery = from fd in _context.FlightDetails
                                      select fd;
                        fdquery = fdquery.Where(fd => fd.FlightDetailID == selecteddetails.arrivingFlightDetailID);

                        List<FlightDetail> fdlist = fdquery.ToList();

                        arrfd = fdlist.First();


                        ticket.Flightdetail = arrfd;

                        AppUser user = new AppUser();

                        user = await _userManager.FindByNameAsync(User.Identity.Name);

                        ticket.Name = user;

                        _context.Add(ticket);
                        await _context.SaveChangesAsync();



                        if (selecteddetails.NumberOfPassengers != 1)
                        {
                            //KEVIN: We redirect to the tickets controller here and pass along our ticket view model we created earlier.
                            //Again, this only happens if the passenger is NOT travelling alone (i.e. they need to buy a ticket for someone else.
                            ViewBag.TakenSeats = strTakenSeats;
                            return RedirectToAction("CustomerSelection", "Tickets", ticketviewmodel);
                        }

                        //KEVIN: Here is where you should redirect to a different action if they still have tickets to check out with. I would recommend passing the view model to it.
                        return RedirectToAction("CheckoutBegin", "Checkout", new { reservationID = selecteddetails.ReservationID });
                    }
                }


            }

            return View("Error");
            
            
        }



        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a registration to view!" });
            }

            Reservation reservation = await _context.Reservations
                .Include(r => r.Tickets)
                .ThenInclude(r => r.Flightdetail)
                .ThenInclude(r => r.Flight)
                .Include(r =>r.User)
                .FirstOrDefaultAsync(m => m.ReservationID == id);

            var tquery = from t in _context.Tickets
                         select t;

            tquery = tquery.Include(t => t.Reservation);
            tquery = tquery.Include(t => t.Name);


            tquery = tquery.Where(t => t.Reservation.ReservationID == id);


            List < Ticket > ticketList = tquery.ToList();


            ReservationDetailsViewModel rdvm = new ReservationDetailsViewModel();

            rdvm.Tickets = ticketList;
            rdvm.reservation = reservation;

            if (reservation == null)
            {
                return View("Error", new String[] { "Cannot find this registration!" });
            }
            


            if (reservation.TotalPrice == 0)
            {
                ViewBag.Message = "You paid in Miles! Nothing was charged to your card.";
            }

            return View(rdvm);
        }

        public async Task<IActionResult> ChangeSeat(int? id)
        {
            //First, get all the tickets associated with the TICKET id above

            var tquery = from t in _context.Tickets
                         select t;

            tquery = tquery.Include(t => t.Flightdetail);
            tquery = tquery.Include(t => t.Name);

            tquery = tquery.Where(t => t.TicketID == id);

            List<Ticket> listtickets = tquery.ToList();
            Ticket ticket = listtickets.First();

            FlightDetail flightdetail = ticket.Flightdetail;

            var othertquery = from t in _context.Tickets
                              select t;

            othertquery = othertquery.Include(t => t.Flightdetail);
            othertquery = othertquery.Include(t => t.Name);
            othertquery = othertquery.Where(t => t.Flightdetail.FlightDetailID == flightdetail.FlightDetailID);

            List<Ticket> listtakentickets = othertquery.ToList();


            List < Seats > takenseats = new List<Seats>();

            foreach(Ticket takenticket in listtakentickets)
            {
                takenseats.Add(takenticket.Seat);
            }



            string strTakenSeats = "Taken Seats on this flight: ";

            
            foreach(Seats seat in takenseats)
            {
                strTakenSeats = strTakenSeats + seat + ", ";
            }

            ViewBag.TakenSeats = strTakenSeats;

            SeatReSelectionViewModel srsvm = new SeatReSelectionViewModel();
            srsvm.TicketID = ticket.TicketID;

            return View("SeatChangeSelect", srsvm);
        }

        public async Task<IActionResult> SeatSelectionConfirmation(SeatReSelectionViewModel viewmodel)
        {
            var tquery = from t in _context.Tickets
                         select t;

            tquery = tquery.Include(t => t.Flightdetail);
            tquery = tquery.Include(t => t.Name)
                .Include(t => t.Reservation);


            tquery = tquery.Where(t => t.TicketID == viewmodel.TicketID);

            List<Ticket> listtickets = tquery.ToList();
            Ticket ticket = listtickets.First();

            FlightDetail flightdetail = ticket.Flightdetail;

            var othertquery = from t in _context.Tickets
                              select t;

            othertquery = othertquery.Include(t => t.Flightdetail)
                .ThenInclude(fd => fd.Flight);
            othertquery = othertquery.Include(t => t.Name);
            othertquery = othertquery.Where(t => t.Flightdetail.FlightDetailID == flightdetail.FlightDetailID);

            List<Ticket> listtakentickets = othertquery.ToList();


            bool CustomSeatValidation = true;
            List<Seats> takenseats = new List<Seats>();

            foreach (Ticket takenticket in listtakentickets)
            {
                if(viewmodel.SelectedSeat == takenticket.Seat)
                {
                    
                    CustomSeatValidation = false;
                    takenseats.Add(takenticket.Seat);

                }

                takenseats.Add(takenticket.Seat);

            }

            String strTakenSeats = "Taken Seats: ";

            if (CustomSeatValidation == false)
            {
                foreach (Seats seat in takenseats)
                {
                    strTakenSeats = strTakenSeats + seat + ", ";
                }

                ViewBag.TakenSeats = strTakenSeats;
                ViewBag.ErrorMessage = "That Seat is Taken. Please select another seat.";

                return View("SeatChangeSelect", viewmodel);
            }

            //If the code gets here, we have a valid seat!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //Now we need to update the ticket.

            Seats oldseat = ticket.Seat;

            Decimal Oldprice = ticket.Price;

            ticket.Seat = viewmodel.SelectedSeat;
            _context.SaveChanges();

            Decimal NewPrice = 0.00m;

            Decimal BaseFare = 0.00m;

            
           

            //Total Price is base fare if it doesn't trigger any of the following discounts / premiums.

            BaseFare = ticket.Flightdetail.Flight.BaseFare;
            NewPrice = BaseFare;

            if (ticket.Seat == Seats.OneA)
            {
                
                NewPrice = BaseFare * 1.2m;
            }
            if (ticket.Seat == Seats.OneB)
            {
                NewPrice = BaseFare * 1.2m;
            }
            if (ticket.Seat == Seats.TwoA)
            {
                
                NewPrice = BaseFare * 1.2m;
            }
            if (ticket.Seat == Seats.TwoB)
            {
                
                NewPrice = BaseFare * 1.2m;
            }
            //We have the correct price for first class seats. 

            Int32 CustAge;
            //Now we need to get the customer age for each ticket.

            CustAge = DateTime.Now.Year - ticket.Name.DOB.Year;
            if (DateTime.Now.DayOfYear < ticket.Name.DOB.DayOfYear)
            {
                CustAge = CustAge - 1;
            }

            if (CustAge <= 12)
            {
                if (ticket.Seat != Seats.OneA && ticket.Seat != Seats.OneB && ticket.Seat != Seats.TwoA && ticket.Seat != Seats.TwoB)
                {
                    NewPrice = BaseFare * 0.85m;
                }
            }
            if (CustAge >= 65)
            {
                if (ticket.Seat != Seats.OneA && ticket.Seat != Seats.OneB && ticket.Seat != Seats.TwoA && ticket.Seat != Seats.TwoB)
                {
                    NewPrice = BaseFare * 0.90m;
                }
            }

            ticket.Price = NewPrice;

            Decimal difference;

            difference = NewPrice - Oldprice;

            if(NewPrice > Oldprice)
            {
                difference = NewPrice - Oldprice;
            }

            if (NewPrice < Oldprice)
            {
                difference = NewPrice - Oldprice;
            }

            if (NewPrice == Oldprice)
             {
                difference = 0;
             }


            var query = from t in _context.Tickets
                        select t;

            query = query.Include(t => t.Reservation);

            query = query.Where(t => t.TicketID == viewmodel.TicketID);

            List < Ticket > ticketlist = query.ToList();

            Ticket specialticket = ticketlist.First();

            var rquery = from r in _context.Reservations
                     select r;

            rquery = rquery.Include(t => t.Tickets);

            rquery = rquery.Where(r => r.ReservationID == specialticket.Reservation.ReservationID);

            List<Reservation> reslist = rquery.ToList();



            Reservation reservationtoupdate = specialticket.Reservation;

            Decimal Subtotal = 0.00m;
            Decimal Tax = 0.00m;
            Decimal Total = 0.00m;

            foreach(Ticket tic in reservationtoupdate.Tickets)
            {
                Subtotal += tic.Price;
            }

            Tax = Subtotal * 0.0775m;
            Total = Tax + Subtotal;

            reservationtoupdate.Subtotal = Subtotal;
            reservationtoupdate.Tax = Tax;
            reservationtoupdate.TotalPrice = Total;

            _context.SaveChanges();





            String strdifference = Convert.ToString(difference);


                _context.SaveChanges();

            string useremail;
            string subject;
            string body;

            useremail = ticket.Name.Email;

            string strticketno = Convert.ToString(ticket.TicketID);

            subject = "Your seat on Ticket No. " + strticketno + " has been changed!";

            string seatnumber = Convert.ToString(ticket.Seat);
            string resnumber = Convert.ToString(ticket.Reservation.ReservationNumber);


            body = "Hello! This email is to inform you that your old seat on ticket number " + strticketno + " has been successfully changed! " +
                "You are now in seat #" + seatnumber + "! "
                + "This is part of reservation number " + resnumber + "." +
                "Because there was a difference in the prices of the seats you selected, your credit card was charged (if positive)" +
                " or refunded (if negative) a total of $" + strdifference +"."
                + " You can now view this reservation on our website! We hope to see you on board soon!";

            //Next - test this functionality.

            SendMailTest.EmailMessaging.SendEmail(useremail, subject, body);


            return View("SeatChangeConfirmation");
        }



        public async Task<IActionResult> GoBackHome(CheckoutViewModel cvm)
        {
            return RedirectToAction("Index", "Home");
        }





        /*public IActionResult PassengerSearch(ReservationSelectionViewModel selecteddetails)
        {
            ReservationSelectionViewModel viewmodel = new ReservationSelectionViewModel();

            viewmodel.ReservationID = selecteddetails.ReservationID;
            viewmodel.arrivalCityID = selecteddetails.arrivalCityID;
            viewmodel.arrivalDate = selecteddetails.arrivalDate;
            viewmodel.departingCityID = selecteddetails.departingCityID;
            viewmodel.departingFlightDetails = selecteddetails.departingFlightDetails;
            viewmodel.departureDate = selecteddetails.departureDate;
            viewmodel.NumberOfPassengers = selecteddetails.NumberOfPassengers;
            viewmodel.TripType = selecteddetails.TripType;

            viewmodel.arrivingFlightDetailID = selecteddetails.arrivingFlightDetailID;
            viewmodel.arrivingFlightDetails = selecteddetails.arrivingFlightDetails;
            viewmodel.departureFlightDetailID = selecteddetails.departureFlightDetailID;

            return View("PassengerSearch", selecteddetails);
        }*/


        // Bring back user to main first page because there are no flights that exist but if statement no work






        // GET: Reservations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationID,ReservationNumber,ReservationDate,PaymentMethod,TotalPrice")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationID,ReservationNumber,ReservationDate,PaymentMethod,TotalPrice")] Reservation reservation)
        {
            if (id != reservation.ReservationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationID == id);
        }

        private MultiSelectList GetAllCities()
        {
            List<City> cityList = _context.Cities.ToList();

            SelectList citySelectList = new SelectList(cityList.OrderBy(c => c.CityName), "CityID", "CityName");

            return citySelectList;
        }

        private SelectList getflights(List<FlightDetail> fds)
        {
            List<FlightDetail> fdlist = fds.ToList();
            SelectList flightSelectList = new SelectList(fdlist.OrderBy(f => f.Date), "FlightDetailID", "Date");
            return flightSelectList;
        }




    }
}
