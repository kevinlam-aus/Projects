using sp20team15finalproject.DAL;
using sp20team15finalproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sp20team15finalproject.Seeding
{
	public static class SeedFlightInfo
	{
		public static void SeedAllFlights(AppDbContext db)
		{
			//Create a new list for all of the movies
			List<Flight> AllFlights = new List<Flight>();

			AllFlights.Add(new Flight
			{
				//FlightID = 1,
				FlightNumber = 1000,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "AUS"),
				DepTime = "8:00",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "DFW"),
				Days = "Weekdays",
				BaseFare = 105,
				Mileage = 190,
				FlightTime = new TimeSpan(0,55,0)

				//if (Days = "Weekdays")

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 2,
				FlightNumber = 1001,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "DFW"),
				DepTime = "9:00",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "AUS"),
				Days = "Weekdays",
				BaseFare = 105,
				Mileage = 190,
				FlightTime = new TimeSpan(0, 55, 0)

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 3,
				FlightNumber = 1002,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "AUS"),
				DepTime = "11:15",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "HOU"),
				Days = "Daily",
				BaseFare = 130,
				Mileage = 148,
				FlightTime = new TimeSpan(1, 0, 0)

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 4,
				FlightNumber = 1003,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "HOU"),
				DepTime = "12:00",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "AUS"),
				Days = "Daily",
				BaseFare = 130,
				Mileage = 148,
				FlightTime = new TimeSpan(1, 0, 0)

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 5,
				FlightNumber = 1004,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "HOU"),
				DepTime = "13:00",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "ELP"),
				Days = "Daily",
				BaseFare = 140,
				Mileage = 667,
				FlightTime = new TimeSpan(2, 9, 0)

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 6,
				FlightNumber = 1005,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "ELP"),
				DepTime = "15:00",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "HOU"),
				Days = "Daily",
				BaseFare = 140,
				Mileage = 667,
				FlightTime = new TimeSpan(2, 9, 0)
			});


			AllFlights.Add(new Flight
			{
				//FlightID = 7,
				FlightNumber = 1006,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "DFW"),
				DepTime = "9:00",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "ELP"),
				Days = "Weekdays",
				BaseFare = 98,
				Mileage = 551,
				FlightTime = new TimeSpan(1, 53, 0)

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 8,
				FlightNumber = 1007,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "ELP"),
				DepTime = "10:15",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "DFW"),
				Days = "Weekdays",
				BaseFare = 100,
				Mileage = 551,
				FlightTime = new TimeSpan(1, 53, 0)

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 9,
				FlightNumber = 1008,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "AUS"),
				DepTime = "13:00",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "ELP"),
				Days = "Daily",
				BaseFare = 115,
				Mileage = 527,
				FlightTime = new TimeSpan(1, 40, 0)

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 10,
				FlightNumber = 1009,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "ELP"),
				DepTime = "14:30",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "AUS"),
				Days = "Daily",
				BaseFare = 115,
				Mileage = 527,
				FlightTime = new TimeSpan(1, 40, 0)

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 11,
				FlightNumber = 1010,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "DFW"),
				DepTime = "14:00",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "HOU"),
				Days = "Weekdays",
				BaseFare = 110,
				Mileage = 224,
				FlightTime = new TimeSpan(1, 13, 0)

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 12,
				FlightNumber = 1011,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "HOU"),
				DepTime = "14:45",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "DFW"),
				Days = "Weekdays",
				BaseFare = 110,
				Mileage = 224,
				FlightTime = new TimeSpan(1, 13, 0)

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 13,
				FlightNumber = 1012,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "AUS"),
				DepTime = "18:00",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "ELP"),
				Days = "Daily",
				BaseFare = 105,
				Mileage = 527,
				FlightTime = new TimeSpan(1, 40, 0)

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 14,
				FlightNumber = 1013,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "ELP"),
				DepTime = "19:45",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "AUS"),
				Days = "Daily",
				BaseFare = 105,
				Mileage = 527,
				FlightTime = new TimeSpan(1, 40, 0)

			});


			AllFlights.Add(new Flight
			{
				//FlightID = 15,
				FlightNumber = 1014,
				DepartingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "DFW"),
				DepTime = "10:30",
				ArrivingCity = db.Cities.FirstOrDefault(c => c.AirportCode == "HOU"),
				Days = "Saturday",
				BaseFare = 225,
				Mileage = 224,
				FlightTime = new TimeSpan(1, 13, 0)

			});





			//create some counters to help debug problems
			Int32 intFlightID = 0;
			Int32 intFlightNumber = 0;

			//loop through the list to add or update the movie
			try
			{
				foreach (Flight seedFlightInformation in AllFlights)
				{
					//update the counters
					intFlightID = seedFlightInformation.FlightID;
					intFlightNumber = seedFlightInformation.FlightNumber;
					//see if the movie is already in the database using the IMDBID
					Flight dbFlight = db.Flights.FirstOrDefault(m => m.FlightNumber == seedFlightInformation.FlightNumber);

					//This is where our if statement comes in about the "Days" thing

					if (seedFlightInformation.Days == "Daily")
					{
						seedFlightInformation.FlyMon = true;
						seedFlightInformation.FlyTue = true;
						seedFlightInformation.FlyWed = true;
						seedFlightInformation.FlyThu = true;
						seedFlightInformation.FlyFri = true;
						seedFlightInformation.FlySat = true;
						seedFlightInformation.FlySun = true;
					}

					if (seedFlightInformation.Days == "Weekdays")
					{
						seedFlightInformation.FlyMon = true;
						seedFlightInformation.FlyTue = true;
						seedFlightInformation.FlyWed = true;
						seedFlightInformation.FlyThu = true;
						seedFlightInformation.FlyFri = true;
						seedFlightInformation.FlySat = false;
						seedFlightInformation.FlySun = false;
					}

					if (seedFlightInformation.Days == "Saturday")
					{
						seedFlightInformation.FlyMon = false;
						seedFlightInformation.FlyTue = false;
						seedFlightInformation.FlyWed = false;
						seedFlightInformation.FlyThu = false;
						seedFlightInformation.FlyFri = false;
						seedFlightInformation.FlySat = true;
						seedFlightInformation.FlySun = false;
					}



					//if movie is null, movie is not in database
					if (dbFlight == null)
					{
						//Add the movie to the database
						db.Flights.Add(seedFlightInformation);
						db.SaveChanges();
					}
					else //the movie is in the database - reset all fields except ID and IMDBID
					{
						dbFlight.DepartingCity = seedFlightInformation.DepartingCity;
						dbFlight.DepTime = seedFlightInformation.DepTime;
						dbFlight.ArrivingCity = seedFlightInformation.ArrivingCity;
						dbFlight.Days = seedFlightInformation.Days;
						dbFlight.BaseFare = seedFlightInformation.BaseFare;
						dbFlight.Mileage = seedFlightInformation.Mileage;
						dbFlight.FlightTime = seedFlightInformation.FlightTime;
						db.SaveChanges();
					}
				}
			}
			catch (Exception ex) //throw error if there is a problem in the database
			{
				StringBuilder msg = new StringBuilder();
				msg.Append("There was a problem adding the movie with the title: ");
				msg.Append(intFlightNumber);
				msg.Append(" (MovieID: ");
				msg.Append(intFlightID);
				msg.Append(")");
				throw new Exception(msg.ToString(), ex);
			}
		}
	}
}
