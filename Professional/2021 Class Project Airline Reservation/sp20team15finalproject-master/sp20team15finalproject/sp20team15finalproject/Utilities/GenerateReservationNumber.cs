using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using sp20team15finalproject.DAL;
using sp20team15finalproject.Models;
using sp20team15finalproject.Utilities;
namespace sp20team15finalproject.Utilities
{
    public static class GenerateNextReservationNumber
    {

        public static Int32 GetNextReservationNumber(AppDbContext _context)
        {
            Int32 intMaxReservationNumber; //The highest maximum order number.
            Int32 intNextReservationNumber;

            if (_context.Reservations.Count() == 0) //No reservations in the system :(
            {
                intMaxReservationNumber = 9999;
            }

            else //there is something in our database
            {
                intMaxReservationNumber = _context.Reservations.Max(o => o.ReservationNumber);
            }

            intNextReservationNumber = intMaxReservationNumber + 1;
            return intNextReservationNumber;
        }
    }
}
