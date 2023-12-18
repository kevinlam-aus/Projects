//using sp20team15finalproject.DAL;
//using sp20team15finalproject.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace sp20team15finalproject.Seeding
//{
//	public static class SeedEmployees
//	{

//		public static void SeedAllEmployees(AppDbContext db)
//		{
//			//Create a new list for all of the Employees
//			List<AppUser> AllEmployees = new List<AppUser>();
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Jacobs",
//				FirstName = "Todd",
//				MiddleInitial = "L",
//				Address = "4564 Elm St.",
//				City = "Dallas",
//				State = "TX",
//				ZipCode = 75032,
//				Email = "t.jacobs@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Rice",
//				FirstName = "Eryn",
//				MiddleInitial = "M",
//				Address = "3405 Rio Grande",
//				City = "Dallas",
//				State = "TX",
//				ZipCode = 75043,
//				Email = "e.rice@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Ingram",
//				FirstName = "Brad",
//				MiddleInitial = "S",
//				Address = "6548 La Posada Ct.",
//				City = "Dallas",
//				State = "TX",
//				ZipCode = 75209,
//				Email = "b.ingram@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Taylor",
//				FirstName = "Allison",
//				MiddleInitial = "R",
//				Address = "467 Nueces St.",
//				City = "Dallas",
//				State = "TX",
//				ZipCode = 75206,
//				Email = "a.taylor@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Martinez",
//				FirstName = "Gregory",
//				MiddleInitial = "R",
//				Address = "8295 Sunset Blvd.",
//				City = "Austin",
//				State = "TX",
//				ZipCode = 78653,
//				Email = "g.martinez@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Sheffield",
//				FirstName = "Martin",
//				MiddleInitial = "J",
//				Address = "3886 Avenue A",
//				City = "Dallas",
//				State = "TX",
//				ZipCode = 75032,
//				Email = "m.sheffield@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "MacLeod",
//				FirstName = "Jennifer",
//				MiddleInitial = "D",
//				Address = "2504 Far West Blvd.",
//				City = "Houston",
//				State = "TX",
//				ZipCode = 77001,
//				Email = "j.macleod@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Tanner",
//				FirstName = "Jeremy",
//				MiddleInitial = "S",
//				Address = "4347 Almstead",
//				City = "Austin",
//				State = "TX",
//				ZipCode = 78705,
//				Email = "j.tanner@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Rhodes",
//				FirstName = "Megan",
//				MiddleInitial = "C",
//				Address = "4587 Enfield Rd.",
//				City = "Dallas",
//				State = "TX",
//				ZipCode = 75039,
//				Email = "m.rhodes@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Stuart",
//				FirstName = "Eric",
//				MiddleInitial = "F",
//				Address = "5576 Toro Ring",
//				City = "Austin",
//				State = "TX",
//				ZipCode = 78710,
//				Email = "e.stuart@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Miller",
//				FirstName = "Charles",
//				MiddleInitial = "R",
//				Address = "8962 Main St.",
//				City = "El Paso",
//				State = "TX",
//				ZipCode = 79901,
//				Email = "c.miller@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Taylor",
//				FirstName = "Rachel",
//				MiddleInitial = "O",
//				Address = "345 Longview Dr.",
//				City = "Houston",
//				State = "TX",
//				ZipCode = 77002,
//				Email = "r.taylor@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Lawrence",
//				FirstName = "Victoria",
//				MiddleInitial = "Y",
//				Address = "6639 Butterfly Ln.",
//				City = "Houston",
//				State = "TX",
//				ZipCode = 77003,
//				Email = "v.lawrence@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Rogers",
//				FirstName = "Allen",
//				MiddleInitial = "H",
//				Address = "4965 Oak Hill",
//				City = "Dallas",
//				State = "TX",
//				ZipCode = 75043,
//				Email = "a.rogers@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Markham",
//				FirstName = "Elizabeth",
//				MiddleInitial = "K",
//				Address = "7861 Chevy Chase",
//				City = "Austin",
//				State = "TX",
//				ZipCode = 78712,
//				Email = "e.markham@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Baker",
//				FirstName = "Christopher",
//				MiddleInitial = "E",
//				Address = "1245 Lake Anchorage Blvd.",
//				City = "Austin",
//				State = "TX",
//				ZipCode = 78710,
//				Email = "c.baker@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Saunders",
//				FirstName = "Sarah",
//				MiddleInitial = "M",
//				Address = "332 Avenue C",
//				City = "Austin",
//				State = "TX",
//				ZipCode = 78613,
//				Email = "s.saunders@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Sewell",
//				FirstName = "William",
//				MiddleInitial = "G",
//				Address = "2365 51st St.",
//				City = "Austin",
//				State = "TX",
//				ZipCode = 78705,
//				Email = "w.sewell@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Mason",
//				FirstName = "Jack",
//				MiddleInitial = "L",
//				Address = "444 45th St",
//				City = "Houston",
//				State = "TX",
//				ZipCode = 77012,
//				Email = "j.mason@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Jackson",
//				FirstName = "Jack",
//				MiddleInitial = "J",
//				Address = "222 Main",
//				City = "Houston",
//				State = "TX",
//				ZipCode = 77004,
//				Email = "j.jackson@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Nguyen",
//				FirstName = "Mary",
//				MiddleInitial = "J",
//				Address = "465 N. Bear Cub",
//				City = "Dallas",
//				State = "TX",
//				ZipCode = 75001,
//				Email = "m.nguyen@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Barnes",
//				FirstName = "Susan",
//				MiddleInitial = "M",
//				Address = "888 S. Main",
//				City = "Houston",
//				State = "TX",
//				ZipCode = 77010,
//				Email = "s.barnes@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Jones",
//				FirstName = "Lester",
//				MiddleInitial = "L",
//				Address = "999 LeBlat",
//				City = "Houston",
//				State = "TX",
//				ZipCode = 77011,
//				Email = "l.jones@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Garcia",
//				FirstName = "Hector",
//				MiddleInitial = "W",
//				Address = "777 PBR Drive",
//				City = "Houston",
//				State = "TX",
//				ZipCode = 77012,
//				Email = "h.garcia@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Silva",
//				FirstName = "Cindy",
//				MiddleInitial = "S",
//				Address = "900 4th St",
//				City = "Austin",
//				State = "TX",
//				ZipCode = 78718,
//				Email = "c.silva@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Lopez",
//				FirstName = "Marshall",
//				MiddleInitial = "T",
//				Address = "90 SW North St",
//				City = "Austin",
//				State = "TX",
//				ZipCode = 78719,
//				Email = "m.lopez@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Larson",
//				FirstName = "Bill",
//				MiddleInitial = "B",
//				Address = "1212 N. First Ave",
//				City = "Houston",
//				State = "TX",
//				ZipCode = 77025,
//				Email = "b.larson@longhornairlines.neet",
//			});
//			AllEmployees.Add(new AppUser
//			{
//				LastName = "Rankin",
//				FirstName = "Suzie",
//				MiddleInitial = "R",
//				Address = "23 Polar Bear Road",
//				City = "Dallas",
//				State = "TX",
//				ZipCode = 75088,
//				Email = "s.rankin@longhornairlines.neet",
//			});

//			//create some counters to help debug problems
//			String strEmployeeEmail = "Start";
//			//loop through the list to add or update an employee
//			try
//			{
//				foreach (AppUser seedEmployee in AllEmployees)
//				{
//					//update counters
//					strEmployeeEmail = seedEmployee.Email;
//					//see if the Employee is already in the database using the EmployeeID
//					AppUser dbEmployee = db.Users.FirstOrDefault(e => e.Email == seedEmployee.Email);

//					//if customer is null, customer is not in database
//					if (dbEmployee == null)
//					{
//						//Add the Customer to the database
//						db.Users.Add(seedEmployee);
//						db.SaveChanges();
//					}
//					else //the Customer is in the database - reset all fields except Email
//					{
//						dbEmployee.LastName = seedEmployee.LastName;
//						dbEmployee.FirstName = seedEmployee.FirstName;
//						dbEmployee.MiddleInitial = seedEmployee.MiddleInitial;
//						dbEmployee.Address = seedEmployee.Address;
//						dbEmployee.City = seedEmployee.City;
//						dbEmployee.State = seedEmployee.State;
//						dbEmployee.ZipCode = seedEmployee.ZipCode;

//					}
//				}
//			}
//			catch (Exception ex) //throw error if there is a problem in the database
//			{
//				StringBuilder msg = new StringBuilder();
//				msg.Append("There was a problem adding the Employee with the Email: ");
//				msg.Append(strEmployeeEmail);
//				msg.Append(")");
//				throw new Exception(msg.ToString(), ex);
//			}
//		}
//	}
//}
