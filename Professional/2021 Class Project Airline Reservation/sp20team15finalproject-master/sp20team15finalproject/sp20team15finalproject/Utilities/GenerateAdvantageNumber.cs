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
    public static class GenerateNextAdvantageNumber
    {

        public static String GetNextAdvantageNumber(AppDbContext _context)
        {
            Int32 intMaxAdvantageNumber; //The highest maximum order number.
            Int32 intNextAdvantageNumber;

            String strMaxAdvantageNumber;
            String strNextAdvantageNumber;


            strMaxAdvantageNumber = _context.Users.Max(o => o.AdvantageNumber);

            intMaxAdvantageNumber = Convert.ToInt32(strMaxAdvantageNumber);
 

            intNextAdvantageNumber = intMaxAdvantageNumber + 1;

            strNextAdvantageNumber = Convert.ToString(intNextAdvantageNumber);



            return strNextAdvantageNumber;
        }
    }
}
