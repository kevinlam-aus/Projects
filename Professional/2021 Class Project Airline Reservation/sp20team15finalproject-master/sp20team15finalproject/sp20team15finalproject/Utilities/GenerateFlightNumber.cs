using sp20team15finalproject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp20team15finalproject.Utilities
{
    public class GenerateFlightNumber
    {
        public static Int32 GetNextFlightNumber(AppDbContext _context)
        {


            Int32 intMaxFlightNumber; //the current maximum course number
            Int32 intNextFlightNumber; //the course number for the next class

            if (_context.Flights.Count() == 0) //there are no courses in the database yet
            {
                intMaxFlightNumber = 1000; //course numbers start at 1000
            }
            else
            {
                intMaxFlightNumber = _context.Flights.Max(p => p.FlightNumber); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextFlightNumber = intMaxFlightNumber + 1;

            //return the value
            return intNextFlightNumber;
        }
    }
}
