using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sp20team15finalproject.DAL;
using sp20team15finalproject.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sp20team15finalproject.Controllers
{
    public class SeedController : Controller
    {

        private AppDbContext _db;


        public SeedController(AppDbContext context)
        {
            _db = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SeedFlights()
        {
            try
            {
                Seeding.SeedFlightInfo.SeedAllFlights(_db);
                Int32 RowsUpdated = 0;

                RowsUpdated = Utilities.GenerateFlightDetails.UpdateFlightDetails(_db);

            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error adding flights to the database",
                ex.Message,
                ex.InnerException.Message,
                ex.InnerException.InnerException.Message});
            }

            return View("Confirm");
        }

        public IActionResult SeedCities()
        {
            try
            {
                Seeding.SeedCities.SeedAllCities(_db);

            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error adding flights to the database",
                ex.Message,
                ex.InnerException.Message,
                ex.InnerException.InnerException.Message});
            }

            return View("Confirm");
        }

        //        public IActionResult SeedEmployees()
        //        {
        //            try
        //            {
        //                Seeding.SeedEmployees.SeedAllEmployees(_db);

        //            }
        //            catch (Exception ex)
        //            {
        //                return View("Error", new String[] { "There was an error adding employees to the database",
        //                ex.Message,
        //                ex.InnerException.Message,
        //                ex.InnerException.InnerException.Message});

        //            }

        //            return View("Confirm");
        //        }


    //    public IActionResult SeedCityDetails()
    //    {
    //        try
    //        {
    //            Seeding.SeedCityDetails.SeedAllCities(_db);
    //        }
    //        catch (Exception ex)
    //        {
    //            return View("Error", new String[] { "There was an error adding flights to the database",
    //                    ex.Message,
    //                    ex.InnerException.Message,
    //                    ex.InnerException.InnerException.Message});
    //        }

    //        return View("Confirm");
    //    }
    }
}
