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
    //AIGHT IM CAFFEINED UP AND SUPER HORNY SO LET'S GET THIS CODE FUCKING DONE.
    public static class GenerateFlightDetails
    {

        public static Int32 UpdateFlightDetails(AppDbContext _db)
        {
            Int32 RowsUpdated = 0;

            var query = from f in _db.Flights
                        select f;


            List<Flight> AllFlights = query.ToList();


            List<FlightDetail> flightDetailsToUpdate = new List<FlightDetail>();

            List<DateTime> AllDates = GenerateAllDates.GenerateDates();

            foreach (var flight in AllFlights)
            {

                foreach (DateTime date in AllDates)
                {
                    string dayofweek = (date.ToString("ddd"));

                    if (dayofweek == "Mon")
                    {
                        if (flight.FlyMon == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                    if (dayofweek == "Tue")
                    {
                        if (flight.FlyTue == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                    if (dayofweek == "Wed")
                    {
                        if (flight.FlyWed == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                    if (dayofweek == "Thu")
                    {
                        if (flight.FlyThu == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                    if (dayofweek == "Fri")
                    {
                        if (flight.FlyFri == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                    if (dayofweek == "Sat")
                    {
                        if (flight.FlySat == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                    if (dayofweek == "Sun")
                    {
                        if (flight.FlySun == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                }

            }

            try
            {
                foreach (FlightDetail seedFlightDetail in flightDetailsToUpdate)
                {
                    var fdquery = from fd in _db.FlightDetails
                                select fd;

                    fdquery = fdquery.Where(f => f.Flight == seedFlightDetail.Flight);
                    fdquery = fdquery.Where(f => f.Date == seedFlightDetail.Date);

                    List<FlightDetail> dbFlightDetail = fdquery.ToList();

                    //FlightDetail dbFlightDetail = _db.FlightDetails.FirstOrDefault(m => m.Flight == seedFlightDetail.Flight);

                    //There is no flightdetail in the system.
                    if (dbFlightDetail.Count == 0)
                    {
                        DateTime date = new DateTime(2020, 5, 8);

                        if (seedFlightDetail.Date < date)
                        {
                            seedFlightDetail.FlightStatus = Status.Departed;
                        }
                        else
                        {
                            seedFlightDetail.FlightStatus = Status.Not_Departed;
                        }
                        

                        _db.FlightDetails.Add(seedFlightDetail);
                        _db.SaveChanges();
                        RowsUpdated = RowsUpdated + 1;
                    }

                    else
                    {
                        foreach (FlightDetail dbFlightDetailIndividual in dbFlightDetail)
                        {
                            DateTime date = new DateTime(2020, 5, 8);

                            dbFlightDetailIndividual.Date = seedFlightDetail.Date;
                            dbFlightDetailIndividual.Flight = seedFlightDetail.Flight;
                            dbFlightDetailIndividual.FlightStatus = dbFlightDetailIndividual.FlightStatus;
                            if (seedFlightDetail.Date < date)
                            {
                                dbFlightDetailIndividual.FlightStatus = Status.Departed;
                            }
                            else
                            {
                                dbFlightDetailIndividual.FlightStatus = Status.Not_Departed;
                            }
                            _db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
                    StringBuilder msg = new StringBuilder();
                    msg.Append("There was a problem adding the a flight.: ");
                   
                    msg.Append(" (Sorry ");
                    
                    msg.Append(")");
                    throw new Exception(msg.ToString(), ex);
                
            }


            return RowsUpdated;
        }

        public static Int32 UpdateNewFlightDetails(AppDbContext _db)
        {
            Int32 RowsUpdated = 0;

            var query = from f in _db.Flights
                        select f;

            query = query.Where(f => f.FlightID > 15);


            List<Flight> AllFlights = query.ToList();


            List<FlightDetail> flightDetailsToUpdate = new List<FlightDetail>();

            List<DateTime> AllDates = GenerateAllDates.GenerateNewDates();

            foreach (var flight in AllFlights)
            {

                foreach (DateTime date in AllDates)
                {
                    string dayofweek = (date.ToString("ddd"));

                    if (dayofweek == "Mon")
                    {
                        if (flight.FlyMon == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                    if (dayofweek == "Tue")
                    {
                        if (flight.FlyTue == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                    if (dayofweek == "Wed")
                    {
                        if (flight.FlyWed == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                    if (dayofweek == "Thu")
                    {
                        if (flight.FlyThu == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                    if (dayofweek == "Fri")
                    {
                        if (flight.FlyFri == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                    if (dayofweek == "Sat")
                    {
                        if (flight.FlySat == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                    if (dayofweek == "Sun")
                    {
                        if (flight.FlySun == true)
                        {
                            FlightDetail newflightdetail = new FlightDetail();

                            newflightdetail.Flight = flight;


                            String strHour;
                            String strMinute;

                            Int32 intHour = 0;
                            Int32 intMinute = 0;


                            if (flight.DepTime.Length == 5)
                            {
                                strHour = flight.DepTime.Substring(0, 2);
                                strMinute = flight.DepTime.Substring(3, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            if (flight.DepTime.Length == 4)
                            {
                                strHour = flight.DepTime.Substring(0, 1);
                                strMinute = flight.DepTime.Substring(2, 2);

                                intHour = Convert.ToInt32(strHour);
                                intMinute = Convert.ToInt32(strMinute);
                            }

                            TimeSpan time = new TimeSpan(intHour, intMinute, 0);

                            DateTime dateToAdd = date + time;

                            newflightdetail.Date = dateToAdd;

                            flightDetailsToUpdate.Add(newflightdetail);
                        }
                    }
                }

            }

            try
            {
                foreach (FlightDetail seedFlightDetail in flightDetailsToUpdate)
                {
                    var fdquery = from fd in _db.FlightDetails
                                  select fd;

                    fdquery = fdquery.Where(f => f.Flight == seedFlightDetail.Flight);
                    fdquery = fdquery.Where(f => f.Date == seedFlightDetail.Date);

                    List<FlightDetail> dbFlightDetail = fdquery.ToList();

                    //FlightDetail dbFlightDetail = _db.FlightDetails.FirstOrDefault(m => m.Flight == seedFlightDetail.Flight);

                    //There is no flightdetail in the system.
                    if (dbFlightDetail.Count == 0)
                    {
                        DateTime date = new DateTime(2020, 5, 8);

                        if (seedFlightDetail.Date < date)
                        {
                            seedFlightDetail.FlightStatus = Status.Departed;
                        }
                        else
                        {
                            seedFlightDetail.FlightStatus = Status.Not_Departed;
                        }


                        _db.FlightDetails.Add(seedFlightDetail);
                        _db.SaveChanges();
                        RowsUpdated = RowsUpdated + 1;
                    }

                    else
                    {
                        foreach (FlightDetail dbFlightDetailIndividual in dbFlightDetail)
                        {
                            DateTime date = new DateTime(2020, 5, 8);

                            dbFlightDetailIndividual.Date = seedFlightDetail.Date;
                            dbFlightDetailIndividual.Flight = seedFlightDetail.Flight;
                            dbFlightDetailIndividual.FlightStatus = dbFlightDetailIndividual.FlightStatus;
                            if (seedFlightDetail.Date < date)
                            {
                                dbFlightDetailIndividual.FlightStatus = Status.Departed;
                            }
                            else
                            {
                                dbFlightDetailIndividual.FlightStatus = Status.Not_Departed;
                            }
                            _db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                StringBuilder msg = new StringBuilder();
                msg.Append("There was a problem adding the a flight.: ");

                msg.Append(" (Sorry ");

                msg.Append(")");
                throw new Exception(msg.ToString(), ex);

            }


            return RowsUpdated;
        }

    }
}
