using sp20team15finalproject.DAL;
using sp20team15finalproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sp20team15finalproject.Seeding
{
	public static class SeedCities
	{
		public static void SeedAllCities(AppDbContext db)
		{
			//Create a new list for all of the movies
			List<City> AllCities = new List<City>();

			AllCities.Add(new City
			{
				//FlightID = 1,
				CityNumber = 8001,
				CityName = "Austin",
				AirportCode = "AUS"

			});
			AllCities.Add(new City
			{
				//FlightID = 1,
				CityNumber = 8002,
				CityName = "Dallas",
				AirportCode = "DFW"

			});
			AllCities.Add(new City
			{
				//FlightID = 1,
				CityNumber = 8003,
				CityName = "Houston",
				AirportCode = "HOU"

			});

			AllCities.Add(new City
			{
				//FlightID = 1,
				CityNumber = 8004,
				CityName = "El Paso",
				AirportCode = "ELP"

			});


			try
			{
				foreach (City seedCity in AllCities)
				{
	
					//see if the movie is already in the database using the IMDBID
					City dbCity = db.Cities.FirstOrDefault(m => m.CityNumber == seedCity.CityNumber);
					
					if (dbCity == null)
					{
						//Add the movie to the database
						db.Cities.Add(seedCity);
						db.SaveChanges();
					}
					else //the movie is in the database - reset all fields except ID and IMDBID
					{
						dbCity.CityNumber = seedCity.CityNumber;
						dbCity.CityName = seedCity.CityName;
						dbCity.AirportCode = seedCity.AirportCode;
						db.SaveChanges();
					}
				}
			}
			catch (Exception ex) //throw error if there is a problem in the database
			{
			}
		}
	}
}