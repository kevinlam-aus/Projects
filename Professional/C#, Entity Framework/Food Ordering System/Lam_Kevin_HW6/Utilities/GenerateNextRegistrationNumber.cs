using sp20RelationalDataDemo.DAL;
using System;
using System.Linq;


namespace sp20RelationalDataDemo.Utilities
{
    public static class GenerateNextRegistrationNumber
    {
        public static Int32 GetNextRegistrationNumber(AppDbContext _context)
        {
            Int32 intMaxRegistrationNumber; //the current maximum course number
            Int32 intNextRegistrationNumber; //the course number for the next class

            if (_context.Registrations.Count() == 0) //there are no registrations in the database yet
            {
                intMaxRegistrationNumber = 100; //registration numbers start at 101
            }
            else
            {
                intMaxRegistrationNumber = _context.Registrations.Max(c => c.RegistrationNumber); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextRegistrationNumber = intMaxRegistrationNumber + 1;

            //return the value
            return intNextRegistrationNumber;
        }

    }
}