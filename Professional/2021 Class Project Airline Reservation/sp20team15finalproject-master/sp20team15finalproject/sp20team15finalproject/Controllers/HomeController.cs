using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sp20team15finalproject.DAL;
using sp20team15finalproject.Models;

//david wuz here
//Kevin wuz als0 here

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sp20team15finalproject.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _db;
        public HomeController(AppDbContext context)
        {
            _db = context; //set appdb
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var query = from fd in _db.FlightDetails select fd;

            query.Include(f => f.Flight)
                .ThenInclude(f => f.ArrivingCity);

            query = query.Include(f => f.Flight)
                .ThenInclude(f => f.ArrivingCity)
                .Include(f => f.Flight.DepartingCity);

            query = query.Where(f => f.FlightStatus == Status.Not_Departed);

            query = query.OrderBy(f => f.Date);
                

            List<FlightDetail> AllFlights = query.ToList();



            return View(AllFlights.OrderBy(f => f.Date));

            

        }
    }
}
