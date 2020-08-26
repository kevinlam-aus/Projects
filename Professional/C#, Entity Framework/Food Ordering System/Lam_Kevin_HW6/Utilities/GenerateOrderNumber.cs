using Lam_Kevin_HW6.DAL;
using System;
using System.Linq;

namespace Lam_Kevin_HW6.Utilities
{
    public static class GenerateOrderNumber
    {
        public static Int32 GetNextOrderNumber(AppDbContext _context)
        {
            

            Int32 intMaxOrderNumber; //the current maximum course number
            Int32 intNextOrderNumber; //the course number for the next class

            if (_context.Orders.Count() == 0) //there are no courses in the database yet
            {
                intMaxOrderNumber = 3000; //course numbers start at 3001
            }
            else
            {
                intMaxOrderNumber = _context.Orders.Max(o => o.OrderNumber); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextOrderNumber = intMaxOrderNumber + 1;

            //return the value
            return intNextOrderNumber;
        }

    }
}