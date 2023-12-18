using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sp20team15finalproject.DAL;
using sp20team15finalproject.Models;
using sp20team15finalproject.Models.ViewModels;

namespace sp20team15finalproject.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class FlightsController : Controller
    {
        private readonly AppDbContext _context;

        public FlightsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flights.ToListAsync());
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {

            ViewBag.AllCities = GetAllCities();
            FlightAdditionViewModel viewmodel = new FlightAdditionViewModel();


            return View(viewmodel);
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFlight(FlightAdditionViewModel viewmodel)
        {
            //Here is a bunch of validation before we add this shit to the database / start querying it.
            bool customverification = true;
            bool timeverification = false;

            if (viewmodel.DepartingCityID == 0)
            {
                ViewBag.ErrorMessage = "Please Select a Departing City.";
                customverification = false;
            }
            if (viewmodel.ArrivingCityID == 0)
            {
                ViewBag.ErrorMessage = "Please Select an Arriving City.";
                customverification = false;
            }

            if(viewmodel.ArrivingCityID == viewmodel.DepartingCityID)
            {
                ViewBag.ErrorMessage = "Your Arriving City Can't be the same as your Departing City";
                customverification = false;
            }

            string strHour;
            string strMinute;
            Int32 intHour;
            Int32 intMinute;

            if (viewmodel.DepTime != null)
            {
                if (viewmodel.DepTime.Length == 5)
                {
                    strHour = viewmodel.DepTime.Substring(0, 2);
                    strMinute = viewmodel.DepTime.Substring(3, 2);

                    intHour = Convert.ToInt32(strHour);
                    intMinute = Convert.ToInt32(strMinute);

                    if (intHour > 24)
                    {
                        ViewBag.ErrorMessage = "Invalid Time. Hour must be less than 25.";
                        timeverification = false;
                    }
                    if (intHour < 10)
                    {
                        ViewBag.ErrorMessage = "Invalid Time. Hour must be greater than 12 (don't put a 0 in front of 9:15).";
                        timeverification = false;
                    }
                    if (intMinute > 60)
                    {
                        ViewBag.ErrorMessage = "Invalid Time. Minutes must be less than 60.";
                        timeverification = false;
                    }
                    if(intMinute == 15 || intMinute == 00 || intMinute == 30 || intMinute == 45)
                    {
                        timeverification = true;
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Invalid Time. Minutes must be in 15 minute increments.";
                        timeverification = false;
                    }
                }

                if (viewmodel.DepTime.Length == 4)
                {
                    strHour = viewmodel.DepTime.Substring(0, 1);
                    strMinute = viewmodel.DepTime.Substring(2, 2);

                    intHour = Convert.ToInt32(strHour);
                    intMinute = Convert.ToInt32(strMinute);

                    if (intHour > 10)
                    {
                        ViewBag.ErrorMessage = "Invalid Time.";
                        timeverification = false;
                    }
                    if (intMinute > 60)
                    {
                        ViewBag.ErrorMessage = "Invalid Time. Minutes must be less than 60.";
                        timeverification = false;
                    }
                    if (intMinute == 15 || intMinute == 00 || intMinute == 30 || intMinute == 45)
                    {
                        timeverification = true;
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Invalid Time. Minutes must be in 15 minute increments.";
                        timeverification = false;
                    }

                }
                if (viewmodel.DepTime.Length > 5)
                {
                    ViewBag.ErrorMessage = "Invalid Time. Please enter time in form such as 9:15 or 21:45.";
                    timeverification = false;
                }

                if (viewmodel.DepTime.Length < 4)
                {
                    ViewBag.ErrorMessage = "Invalid Time. Please enter time in form such as 9:15 or 21:45.";
                    timeverification = false;
                }
            }

            if(viewmodel.DepTime == null)
            {
                ViewBag.ErrorMessage = "Please specify a departing time.";
                timeverification = false;

            }

            if(viewmodel.BaseFare == 0)
            {
                ViewBag.ErrorMessage = "Please specify a base fare.";
                customverification = false;
            }

           

            if(customverification == false)
            {
                ViewBag.AllCities = GetAllCities();
                return View("Create", viewmodel);
            }

            if (timeverification == false)
            {
                ViewBag.AllCities = GetAllCities();
                return View("Create", viewmodel);
            }



            Flight flight = new Flight();

            List<City> arrCities = new List<City>();
            List<City> depCities = new List<City>();

            var query = from c in _context.Cities
                        select c;

            var dquery = from c in _context.Cities
                         select c;

            query = query.Where(c => c.CityID == viewmodel.ArrivingCityID);
            dquery = dquery.Where(c => c.CityID == viewmodel.DepartingCityID);


            arrCities = query.ToList();
            depCities = dquery.ToList();

            flight.DepartingCity = depCities.First();
            flight.ArrivingCity = arrCities.First();

            flight.BaseFare = viewmodel.BaseFare;
            flight.DepTime = viewmodel.DepTime;
            flight.FlyFri = viewmodel.FlyFri;
            flight.FlyMon = viewmodel.FlyMon;
            flight.FlySat = viewmodel.FlySat;
            flight.FlySun = viewmodel.FlySun;
            flight.FlyThu = viewmodel.FlyThu;
            flight.FlyTue = viewmodel.FlyTue;
            flight.FlyWed = viewmodel.FlyWed;
            


            flight.FlightNumber = Utilities.GenerateFlightNumber.GetNextFlightNumber(_context);



            var fquery = from f in _context.Flights
                         select f;

            fquery = fquery.Where(f => f.ArrivingCity.CityID == viewmodel.ArrivingCityID);

            fquery = fquery.Where(f => f.DepartingCity.CityID == viewmodel.DepartingCityID);

            fquery = fquery.Where(f => f.Mileage != 0);

            List<Flight> mileageFlights = fquery.ToList();

            Flight flightmileagereference = mileageFlights.First();

            flight.Mileage = flightmileagereference.Mileage;
            flight.FlightTime = flightmileagereference.FlightTime;




            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                Utilities.GenerateFlightDetails.UpdateNewFlightDetails(_context);
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightID,FlightNumber,DepTime,Days,FlySun,FlyMon,FlyTue,FlyWed,FlyThu,FlyFri,FlySat,BaseFare")] Flight flight)
        {
            if (id != flight.FlightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightID))
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
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.FlightID == id);
        }

        //This gets all the cities.
        private MultiSelectList GetAllCities()
        {
            List<City> cityList = _context.Cities.ToList();

            City SelectNone = new City() { CityID = 0, CityName = "All Cities" };
            cityList.Add(SelectNone);

            SelectList citySelectList = new SelectList(cityList.OrderBy(c => c.CityName), "CityID", "CityName");

            return citySelectList;
        }
    }
}
