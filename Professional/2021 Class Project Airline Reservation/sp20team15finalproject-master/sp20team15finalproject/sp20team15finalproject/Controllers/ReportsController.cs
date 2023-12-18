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
    
    public enum ReportType { TotalSeats, TotalRevenue, Both} //enum for type of report the user wants to see
    public enum ClassSearch { Economy, FirstClass, Both } //enum for type of seat 



    [Authorize(Roles = "Admin , Manager")]
    public class ReportsController : Controller
    {
        private AppDbContext _db;

        public ReportsController(AppDbContext context)
        {
            _db = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReportsSearch()
        {
            //populate the drop down with cities
            ViewBag.AllCities = GetAllCities();
            return View();
        }

        public async Task<IActionResult> FlightManifests()
        {
            return View(await _db.FlightDetails.ToListAsync());
        }

        public IActionResult DisplayFlightManifests(int? id)
        {

            var FirstDay = new DateTime(2020, 5, 8);
            
            //if in future show everyone if in past only show if they checked in
            //Step 2: (on another controller) - display flight manifests
            if (id == null)
            {
                return View("Error");
            }

            var query = from t in _db.FlightDetails
                        select t;

            query = query.Include(t => t.Tickets);

            query = query.Where(t => t.FlightDetailID == id);


            List<FlightDetail> flightdetails = new List<FlightDetail>();

            flightdetails = query.ToList();

            FlightDetail flightdetail = flightdetails.First();

            var tquery = from t in _db.Tickets select t;

            tquery = tquery.Include(t => t.Name)
                .Include(t => t.Flightdetail);

            tquery = tquery.Where(t => t.Flightdetail.FlightDetailID == id);

            List<Ticket> AllTickets = tquery.ToList();
            List<Ticket> ManifestTickets = new List<Ticket>();

            foreach (Ticket ticket in AllTickets)
            {
                if (flightdetail.Date < FirstDay)
                {
                    if(ticket.seatStatus == SeatStatus.Checked_In)
                    {
                        ManifestTickets.Add(ticket);
                    }
                    
                }
                if (flightdetail.Date >= FirstDay)
                {
                    ManifestTickets.Add(ticket);
                }
               
            }

            ReportsViewModel viewmodel = new ReportsViewModel();

            viewmodel.tickets = ManifestTickets;

            return View(viewmodel);

        }

        public IActionResult DisplaySearchResults(ReportsViewModel rvm)
        {
            var query = from fd in _db.FlightDetails 
                        select fd;

            query = query.Include(f => f.Flight)
                .ThenInclude(f => f.ArrivingCity)
                .Include(f => f.Flight)
                .ThenInclude(f => f.DepartingCity)
                .Include(f => f.Tickets);

            List<FlightDetail> SelectedFlights = new List<FlightDetail>();   

            List<Ticket> AllTickets = new List<Ticket>();
            List<Ticket> ReportTickets = new List<Ticket>();



            if (rvm.DateOne != null)  //search after this date 
            {
                query = query.Where(f => f.Date > rvm.DateOne);
            }

            if (rvm.DateTwo != null)  //search before this date
            {
                query = query.Where(f => f.Date < rvm.DateTwo);
            }

            if (rvm.DepSearchID !=0)
            {
                query = query.Where(f => f.Flight.DepartingCity.CityID == rvm.DepSearchID);
            }

            if (rvm.ArrSearchID != 0)
            {
                query = query.Where(f => f.Flight.ArrivingCity.CityID == rvm.ArrSearchID);
            }


            //list of flightdetails narrowed down step 2.1


            SelectedFlights = query.ToList();


            foreach(FlightDetail flightDetail in SelectedFlights)   //step 2.2
            {

                if(flightDetail.Tickets.Count != 0)
                {
                    foreach (Ticket ticket in flightDetail.Tickets)
                    {
                        ReportTickets.Add(ticket);
                    }

                }
    
            }

            List<Ticket> FinalizedTickets = new List<Ticket>();
            
            foreach (Ticket ticket in ReportTickets)           //step 3
            {
                if (rvm.ClassSearch == ClassSearch.Economy)
                {
                    if (ticket.Seat == Seats.ThreeA)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.ThreeB)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.ThreeC)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.ThreeD)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FourA)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FourB)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FourC)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FourD)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FiveA)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FiveB)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FiveC)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FiveD)
                    {
                        FinalizedTickets.Add(ticket);
                    }

                }
                if (rvm.ClassSearch == ClassSearch.FirstClass)
                {
                    if (ticket.Seat == Seats.OneA)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.OneB)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.TwoA)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.TwoB)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                }
                if (rvm.ClassSearch == ClassSearch.Both)
                {
                    if (ticket.Seat == Seats.ThreeA)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.ThreeB)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.ThreeC)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.ThreeD)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FourA)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FourB)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FourC)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FourD)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FiveA)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FiveB)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FiveC)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.FiveD)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.OneA)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.OneB)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.TwoA)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                    if (ticket.Seat == Seats.TwoB)
                    {
                        FinalizedTickets.Add(ticket);
                    }
                }
            }

            //Once the code gets to here we should have a list of all the tickets management wants to view.
            //CALCULATION TIME

            //Finalized Tickets = List of Tickets that meet the criteria of the user, including economy / first class / both.
            //SelectedFlights = list of flight details that meet the criteria of the user.

            //If statement to determine what they want.



            //David - go in here and create if statements. Start on line 254

            //if Revenue, don't populate the seats viewbags.
            //If seats, dont populate viewbags.
            //When determining seats available, look at the selection they chose above for seats (like seats and things).

            //If test: 5/9 to 5/10 Austin to El Paso.
            // 15 Total Sold out of 36
            // 6 First Class out of 8
            // 9 Are economy out of 24
            // 2 flights scheduled


            //Total Seats Sold




            Int32 TotalSeatsSold;
            //Total Seats Available to be sold.

            Int32 TotalSeatsAvailable;
            TotalSeatsAvailable = SelectedFlights.Count();

            //Total Revenue.
            //Here loop through each of the tickets.
            //Add price to TotalRevenue

            Decimal TotalRevenue = 0.00m;

            //if economy is selected multiple count of selected flights * 12
            //if fc is selected multiple count of selected flights * 4
            //if economy is selected multiple count of selected flights * 16


            if (rvm.ReportType == ReportType.TotalSeats)
            {
                TotalSeatsSold = FinalizedTickets.Count();
                ViewBag.TotalSeatsSold = TotalSeatsSold;
                
                if(rvm.ClassSearch == ClassSearch.Economy)
                {
                    TotalSeatsAvailable = TotalSeatsAvailable * 12;
                    ViewBag.TotalSeatsAvailable = TotalSeatsAvailable;
                }

                if (rvm.ClassSearch == ClassSearch.FirstClass)
                {
                    TotalSeatsAvailable = TotalSeatsAvailable * 4;
                    ViewBag.TotalSeatsAvailable = TotalSeatsAvailable;
                }

                if (rvm.ClassSearch == ClassSearch.Both)
                {
                    TotalSeatsAvailable = TotalSeatsAvailable * 16;
                    ViewBag.TotalSeatsAvailable = TotalSeatsAvailable;
                }
            }

            if(rvm.ReportType == ReportType.TotalRevenue)
            {
                foreach (Ticket ticket in FinalizedTickets)
                {
                    TotalRevenue += ticket.Price;
                }
                ViewBag.TotalRevenue = TotalRevenue;

                if (rvm.ClassSearch == ClassSearch.Economy)
                {
                    TotalSeatsAvailable = TotalSeatsAvailable * 12;
                    ViewBag.TotalSeatsAvailable = TotalSeatsAvailable;
                }

                if (rvm.ClassSearch == ClassSearch.FirstClass)
                {
                    TotalSeatsAvailable = TotalSeatsAvailable * 4;
                    ViewBag.TotalSeatsAvailable = TotalSeatsAvailable;
                }

                if (rvm.ClassSearch == ClassSearch.Both)
                {
                    TotalSeatsAvailable = TotalSeatsAvailable * 16;
                    ViewBag.TotalSeatsAvailable = TotalSeatsAvailable;
                }
            }

            if(rvm.ReportType == ReportType.Both)
            {
                TotalSeatsSold = FinalizedTickets.Count();
               
                foreach (Ticket ticket in FinalizedTickets)
                {
                    TotalRevenue += ticket.Price;
                }

                ViewBag.TotalSeatsSold = TotalSeatsSold;
                ViewBag.TotalRevenue = TotalRevenue;

                if (rvm.ClassSearch == ClassSearch.Economy)
                {
                    TotalSeatsAvailable = TotalSeatsAvailable * 12;
                    ViewBag.TotalSeatsAvailable = TotalSeatsAvailable;
                }

                if (rvm.ClassSearch == ClassSearch.FirstClass)
                {
                    TotalSeatsAvailable = TotalSeatsAvailable * 4;
                    ViewBag.TotalSeatsAvailable = TotalSeatsAvailable;
                }

                if (rvm.ClassSearch == ClassSearch.Both)
                {
                    TotalSeatsAvailable = TotalSeatsAvailable * 16;
                    ViewBag.TotalSeatsAvailable = TotalSeatsAvailable;
                }
            }


            return View();

            
        }

        private MultiSelectList GetAllCities()
        {
            List<City> cityList = _db.Cities.ToList();

            City NoCity = new City() { CityID = 0, CityName = "All Cities" };
            cityList.Add(NoCity);

            SelectList citySelectList = new SelectList(cityList.OrderBy(c => c.CityName), "CityID", "CityName");

            return citySelectList;
        }
    }
}