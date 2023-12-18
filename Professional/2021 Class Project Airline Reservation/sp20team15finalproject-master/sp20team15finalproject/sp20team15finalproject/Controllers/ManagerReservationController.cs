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
    [Authorize(Roles = "Admin , Manager, Agent")]
    public class ManagerReservationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ManagerReservationController(AppDbContext context, IServiceProvider service)
        {
            _context = context;
            _userManager = service.GetRequiredService<UserManager<AppUser>>();
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


        public async Task<IActionResult> CreateNewAccount()
        {
            return RedirectToAction("Register", "Account");
        }


        public async Task<IActionResult> CustomerLookup()
        {
            var uquery = from u in _context.Users
                         select u;

            uquery = uquery.OrderBy(u => u.AdvantageNumber);

            List<AppUser> AllUsers = uquery.ToList();

            List<AppUser> customers = new List<AppUser>();

            foreach (AppUser user in AllUsers)
            {
                if (await _userManager.IsInRoleAsync(user, "Customer") == true)
                {
                    customers.Add(user);
                }
            }

            ManagerReservationViewModel mrvm = new ManagerReservationViewModel();

            mrvm.Customers = customers;

            ViewBag.AllUserCount = _context.Users.Count();

            ViewBag.SelectedUserCount = customers.Count();


            return View(mrvm);
        }

        public async Task<IActionResult> DetailedCustomerSearch()
        {
            CustomerSearchViewModel csvm = new CustomerSearchViewModel();

            return View(csvm);
        }

        public async Task<IActionResult> DetailedCustomerSearchResults(CustomerSearchViewModel csvm)
        {
            var uquery = from u in _context.Users
                         select u;

            uquery = uquery.OrderBy(u => u.AdvantageNumber);

            if (csvm.advantageNumber != null)
            {
                uquery = uquery.Where(u => u.AdvantageNumber == csvm.advantageNumber);
            }

            if (csvm.FirstName != null)
            {
                uquery = uquery.Where(u => u.FirstName.Contains(csvm.FirstName));
            }

            if (csvm.LastName != null)
            {
                uquery = uquery.Where(u => u.LastName.Contains(csvm.LastName));
            }

            List<AppUser> AllUsers = uquery.ToList();

            List<AppUser> SelectedUsers = new List<AppUser>();

            foreach (AppUser user in AllUsers)
            {
                if (await _userManager.IsInRoleAsync(user, "Customer") == true)
                {
                    SelectedUsers.Add(user);
                }
            }

            ViewBag.AllUserCount = _context.Users.Count();

            ViewBag.SelectedUserCount = SelectedUsers.Count();

            ManagerReservationViewModel mrvm = new ManagerReservationViewModel();

            mrvm.Customers = SelectedUsers;

            return View("CustomerLookup", mrvm);
        }


      

        //We get here when we have the email of the person they want to make a reservation for.
        public async Task<IActionResult> InputFlightInfo(ManagerReservationViewModel mrvm)
        {
            //Now we have the email of the person that we want to make the reservation for. Now we need to get all the information 
            //For the flights they want to get.
            //We need to determine if it is a round trip or a one way.



            FlightTripTypeSearchViewModel fttsvm = new FlightTripTypeSearchViewModel();
            fttsvm.SearchTripType = enumTripType.round_trip;

            fttsvm.customeremail = mrvm.CustEmail;


            return View(fttsvm);


        }

        public ActionResult TripInformationEntry(FlightTripTypeSearchViewModel fttsvm)
        {
            //We are going to make a reservation search view model to pass into the view.
            ReservationSearchViewModel rsvm = new ReservationSearchViewModel();

            //This goes if the person selects one way.
            if (fttsvm.SearchTripType == enumTripType.one_way)
            {
                rsvm.customeremail = fttsvm.customeremail;
                rsvm.TripType = enumTripType.one_way;
                ViewBag.AllCities = GetAllCities();
                return View("TripInformationEntryOneWay", rsvm);
            }

            //This goes if the person selects round trip.
            if (fttsvm.SearchTripType == enumTripType.round_trip)
            {
                rsvm.customeremail = fttsvm.customeremail;
                rsvm.TripType = enumTripType.round_trip;
                ViewBag.AllCities = GetAllCities();
                return View("TripInformationEntryRoundTrip", rsvm);
            }

            return View(fttsvm);
        }

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
                if (fd.FlightStatus == Status.Not_Departed)
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
                    return View("ErrorTripInformationEntryOneWay", rsvm);
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

                    List<AppUser> appusers = new List<AppUser>();

                    var uquery = from u in _context.Users
                                 select u;

                    uquery = uquery.Where(u => u.Email == rsvm.customeremail);

                    appusers = uquery.ToList();

                    user = appusers.First();

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
                    rsfvm.customeremail = rsvm.customeremail;
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
                    return View("ErrorTripInformationEntryRoundTrip", rsvm);
                }

                else
                {
                    Reservation reservation = new Reservation();

                    reservation.ReservationNumber = Utilities.GenerateNextReservationNumber.GetNextReservationNumber(_context);
                    reservation.ReservationDate = DateTime.Now;

                    //Now we need to see the user that is logged in and placing the order.

                    AppUser user = new AppUser();

                    List<AppUser> appusers = new List<AppUser>();

                    var uquery = from u in _context.Users
                                 select u;

                    uquery = uquery.Where(u => u.Email == rsvm.customeremail);

                    appusers = uquery.ToList();

                    user = appusers.First();


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
                    rsfvm.customeremail = rsvm.customeremail;

                    ViewBag.DepartingFlights = getflights(DepartingFlights);
                    ViewBag.ReturningFlights = getflights(ReturningFlights);

                    rsfvm.arrivingFlightDetails = ReturningFlights;

                    return View("DepartingFlightResultsRTD", rsfvm);
                }
            }

        }


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
            viewmodel.customeremail = rsvfm.customeremail;

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
            viewmodel.customeremail = selecteddetails.customeremail;

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
            ticketviewmodel.CustomerEmail = selecteddetails.customeremail;


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

                        List<AppUser> appusers = new List<AppUser>();

                        var uquery = from u in _context.Users
                                     select u;

                        uquery = uquery.Where(u => u.Email == ticketviewmodel.CustomerEmail);

                        appusers = uquery.ToList();

                        user = appusers.First();

                        ticket.Name = user;


                        _context.Add(ticket);
                        await _context.SaveChangesAsync();


                        if (selecteddetails.NumberOfPassengers != 1)
                        {
                            //KEVIN: We redirect to the tickets controller here and pass along our ticket view model we created earlier.
                            //We Pass in the ticket view model to this if the number of passengers they want is more than 1.

                            ViewBag.TakenSeats = strTakenSeats;
                            return RedirectToAction("CustomerSelection", "Tickets", ticketviewmodel);
                        }

                        //The code only gets to here if the ticket is 
                        //1. Generated and stored in the database without an error.
                        //2. The passenger is only buying a ticket for himself.

                        //Otherwise, he would have been redirected to the customerseletion action on the tickets controller above.
                        return RedirectToAction("CheckoutBegin", "Checkout", new { reservationID = selecteddetails.ReservationID });

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

                foreach (Seats seat in takenSeats)
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

                if (customValidation == false)
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

                        List<AppUser> appusers = new List<AppUser>();

                        var uquery = from u in _context.Users
                                     select u;

                        uquery = uquery.Where(u => u.Email == ticketviewmodel.CustomerEmail);

                        appusers = uquery.ToList();

                        user = appusers.First();

                        ticket.Name = user;

                        _context.Add(ticket);
                        await _context.SaveChangesAsync();
                    }
                }

                foreach (Seats seat in selecteddetails.availableArrivalSeats)
                {
                    if (selecteddetails.selectedReturnSeat == seat)
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

                        List<AppUser> appusers = new List<AppUser>();

                        var uquery = from u in _context.Users
                                     select u;

                        uquery = uquery.Where(u => u.Email == ticketviewmodel.CustomerEmail);

                        appusers = uquery.ToList();

                        user = appusers.First();

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

