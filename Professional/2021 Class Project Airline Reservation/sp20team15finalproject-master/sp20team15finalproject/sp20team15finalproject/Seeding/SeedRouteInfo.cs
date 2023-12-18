//using sp20team15finalproject.DAL;
//using sp20team15finalproject.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace sp20team15finalproject.Seeding
//{
//	public static class SeedCityDetails
//	{
//		public static void SeedAllCities(AppDbContext db)
//		{
//			//Create a new list for all of the movies
//			List<RouteInfo> AllCityDetails = new List<RouteInfo>();

//			AllCityDetails.Add(new RouteInfo
//			{
//				Mileage = 190,
//				FlightTime = "00:55",
//				City1 = "AUS",
//				City2 = "DFW"

//			});

//			AllCityDetails.Add(new RouteInfo
//			{
//				Mileage = 148,
//				FlightTime = "1:00",
//				City1 = "AUS",
//				City2 = "HOU"

//			});
//			AllCityDetails.Add(new RouteInfo
//			{
//				Mileage = 527,
//				FlightTime = "1:40",
//				City1 = "AUS",
//				City2 = "ELP"

//			});
//			AllCityDetails.Add(new RouteInfo
//			{
//				Mileage = 224,
//				FlightTime = "1:13",
//				City1 = "DFW",
//				City2 = "HOU"

//			});
//			AllCityDetails.Add(new RouteInfo
//			{
//				Mileage = 551,
//				FlightTime = "1:53",
//				City1 = "DFW",
//				City2 = "ELP"

//			});
//			AllCityDetails.Add(new RouteInfo
//			{
//				Mileage = 667,
//				FlightTime = "2:09",
//				City1 = "HOU",
//				City2 = "ELP"

//			});

//			try
//			{
//				foreach (RouteInfo seedCityDetail in AllCityDetails)
//				{


//					RouteInfo dbCityDetail = db.CityDetails.FirstOrDefault(m => m.Mileage == seedCityDetail.Mileage);

//					if (dbCityDetail == null)
//					{
//						//Add the movie to the database
//						db.CityDetails.Add(seedCityDetail);
//						db.SaveChanges();
//					}
//					else //the movie is in the database - reset all fields except ID and IMDBID
//					{
//						dbCityDetail.Mileage = seedCityDetail.Mileage;
//						dbCityDetail.FlightTime = seedCityDetail.FlightTime;
//						dbCityDetail.City1 = seedCityDetail.City1;
//						dbCityDetail.City2 = seedCityDetail.City2;
//						db.SaveChanges();
//					}
//				}
//			}
//			catch (Exception ex) //throw error if there is a problem in the database
//			{
//			}
//		}
//	}
//}

