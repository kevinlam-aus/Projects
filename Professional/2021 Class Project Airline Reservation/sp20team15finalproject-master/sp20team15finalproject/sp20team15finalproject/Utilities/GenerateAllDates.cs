using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp20team15finalproject.Utilities
{
    public class GenerateAllDates
    {
        public static List<DateTime> GenerateDates()
        {
            List<DateTime> dates = new List<DateTime>();

            DateTime startdate = new DateTime(2020, 4, 15);

            DateTime enddate = new DateTime(2020, 6, 30);
            for (DateTime dt = startdate; dt <= enddate; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            return dates;
        }

        public static List<DateTime> GenerateNewDates()
        {
            List<DateTime> dates = new List<DateTime>();

            DateTime startdate = new DateTime(2020, 5, 8);

            DateTime enddate = new DateTime(2020, 6, 30);
            for (DateTime dt = startdate; dt <= enddate; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            return dates;
        }
    }
}
