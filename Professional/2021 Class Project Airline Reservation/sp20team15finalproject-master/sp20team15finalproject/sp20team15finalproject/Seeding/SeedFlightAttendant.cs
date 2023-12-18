using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;


using sp20team15finalproject.DAL;
using sp20team15finalproject.Models;


namespace sp20team15finalproject.Seeding
{
	//add identity data
	public static class SeedFlightAttendantIdentity
	{
		public static async Task AddFlightAttendants(IServiceProvider serviceProvider)
		{
			AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
			UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
			RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			//TODO: Add the needed roles
			//if role doesn't exist, add ita

			if (await _roleManager.RoleExistsAsync("FlightAttendant") == false)
			{
				await _roleManager.CreateAsync(new IdentityRole("FlightAttendant"));
			}
			AppUser newFlightAttendantUser2 = _db.Users.FirstOrDefault(u => u.Email == "m.rhodes@longhornairlines.neet");

			if (newFlightAttendantUser2 == null)
			{
				newFlightAttendantUser2 = new AppUser();
				newFlightAttendantUser2.UserName = "m.rhodes@longhornairlines.neet";
				newFlightAttendantUser2.Email = "m.rhodes@longhornairlines.neet";
				newFlightAttendantUser2.FirstName = "Megan";
				newFlightAttendantUser2.LastName = "Rhodes";
				newFlightAttendantUser2.MiddleInitial = "C";
				newFlightAttendantUser2.Address = "4587 Enfield Rd.";
				newFlightAttendantUser2.City = "Dallas";
				newFlightAttendantUser2.State = "TX";
				newFlightAttendantUser2.ZipCode = "75039";
				newFlightAttendantUser2.PhoneNumber = "4693744746";

				var result = await _userManager.CreateAsync(newFlightAttendantUser2, "countryrhodes");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newFlightAttendantUser2 = _db.Users.FirstOrDefault(u => u.UserName == "m.rhodes@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newFlightAttendantUser2, "FlightAttendant") == false)
			{
				await _userManager.AddToRoleAsync(newFlightAttendantUser2, "FlightAttendant");
			}
			_db.SaveChanges();


			AppUser newFlightAttendantUser3 = _db.Users.FirstOrDefault(u => u.Email == "c.baker@longhornairlines.neet");

			if (newFlightAttendantUser3 == null)
			{
				newFlightAttendantUser3 = new AppUser();
				newFlightAttendantUser3.UserName = "c.baker@longhornairlines.neet";
				newFlightAttendantUser3.Email = "c.baker@longhornairlines.neet";
				newFlightAttendantUser3.FirstName = "Christopher";
				newFlightAttendantUser3.LastName = "Baker";
				newFlightAttendantUser3.MiddleInitial = "E";
				newFlightAttendantUser3.Address = "1245 Lake Anchorage Blvd.";
				newFlightAttendantUser3.City = "Austin";
				newFlightAttendantUser3.State = "TX";
				newFlightAttendantUser3.ZipCode = "78710";
				newFlightAttendantUser3.PhoneNumber = "5125571146";

				var result = await _userManager.CreateAsync(newFlightAttendantUser3, "hecktour");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newFlightAttendantUser3 = _db.Users.FirstOrDefault(u => u.UserName == "c.baker@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newFlightAttendantUser3, "FlightAttendant") == false)
			{
				await _userManager.AddToRoleAsync(newFlightAttendantUser3, "FlightAttendant");
			}
			_db.SaveChanges();


			AppUser newFlightAttendantUser4 = _db.Users.FirstOrDefault(u => u.Email == "j.mason@longhornairlines.neet");

			if (newFlightAttendantUser4 == null)
			{
				newFlightAttendantUser4 = new AppUser();
				newFlightAttendantUser4.UserName = "j.mason@longhornairlines.neet";
				newFlightAttendantUser4.Email = "j.mason@longhornairlines.neet";
				newFlightAttendantUser4.FirstName = "Jack";
				newFlightAttendantUser4.LastName = "Mason";
				newFlightAttendantUser4.MiddleInitial = "L";
				newFlightAttendantUser4.Address = "444 45th St";
				newFlightAttendantUser4.City = "Houston";
				newFlightAttendantUser4.State = "TX";
				newFlightAttendantUser4.ZipCode = "77012";
				newFlightAttendantUser4.PhoneNumber = "2818833432";

				var result = await _userManager.CreateAsync(newFlightAttendantUser4, "changalang");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newFlightAttendantUser4 = _db.Users.FirstOrDefault(u => u.UserName == "j.mason@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newFlightAttendantUser4, "FlightAttendant") == false)
			{
				await _userManager.AddToRoleAsync(newFlightAttendantUser4, "FlightAttendant");
			}
			_db.SaveChanges();


			AppUser newFlightAttendantUser5 = _db.Users.FirstOrDefault(u => u.Email == "s.barnes@longhornairlines.neet");

			if (newFlightAttendantUser5 == null)
			{
				newFlightAttendantUser5 = new AppUser();
				newFlightAttendantUser5.UserName = "s.barnes@longhornairlines.neet";
				newFlightAttendantUser5.Email = "s.barnes@longhornairlines.neet";
				newFlightAttendantUser5.FirstName = "Susan";
				newFlightAttendantUser5.LastName = "Barnes";
				newFlightAttendantUser5.MiddleInitial = "M";
				newFlightAttendantUser5.Address = "888 S. Main";
				newFlightAttendantUser5.City = "Houston";
				newFlightAttendantUser5.State = "TX";
				newFlightAttendantUser5.ZipCode = "77010";
				newFlightAttendantUser5.PhoneNumber = "2816662323";

				var result = await _userManager.CreateAsync(newFlightAttendantUser5, "rhythm");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newFlightAttendantUser5 = _db.Users.FirstOrDefault(u => u.UserName == "s.barnes@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newFlightAttendantUser5, "FlightAttendant") == false)
			{
				await _userManager.AddToRoleAsync(newFlightAttendantUser5, "FlightAttendant");
			}
			_db.SaveChanges();


			AppUser newFlightAttendantUser6 = _db.Users.FirstOrDefault(u => u.Email == "c.silva@longhornairlines.neet");

			if (newFlightAttendantUser6 == null)
			{
				newFlightAttendantUser6 = new AppUser();
				newFlightAttendantUser6.UserName = "c.silva@longhornairlines.neet";
				newFlightAttendantUser6.Email = "c.silva@longhornairlines.neet";
				newFlightAttendantUser6.FirstName = "Cindy";
				newFlightAttendantUser6.LastName = "Silva";
				newFlightAttendantUser6.MiddleInitial = "S";
				newFlightAttendantUser6.Address = "900 4th St";
				newFlightAttendantUser6.City = "Austin";
				newFlightAttendantUser6.State = "TX";
				newFlightAttendantUser6.ZipCode = "78718";
				newFlightAttendantUser6.PhoneNumber = "5121113333";

				var result = await _userManager.CreateAsync(newFlightAttendantUser6, "arched");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newFlightAttendantUser6 = _db.Users.FirstOrDefault(u => u.UserName == "c.silva@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newFlightAttendantUser6, "FlightAttendant") == false)
			{
				await _userManager.AddToRoleAsync(newFlightAttendantUser6, "FlightAttendant");
			}
			_db.SaveChanges();


			AppUser newFlightAttendantUser7 = _db.Users.FirstOrDefault(u => u.Email == "s.rankin@longhornairlines.neet");

			if (newFlightAttendantUser7 == null)
			{
				newFlightAttendantUser7 = new AppUser();
				newFlightAttendantUser7.UserName = "s.rankin@longhornairlines.neet";
				newFlightAttendantUser7.Email = "s.rankin@longhornairlines.neet";
				newFlightAttendantUser7.FirstName = "Suzie";
				newFlightAttendantUser7.LastName = "Rankin";
				newFlightAttendantUser7.MiddleInitial = "R";
				newFlightAttendantUser7.Address = "23 Polar Bear Road";
				newFlightAttendantUser7.City = "Dallas";
				newFlightAttendantUser7.State = "TX";
				newFlightAttendantUser7.ZipCode = "75088";
				newFlightAttendantUser7.PhoneNumber = "4693336666";

				var result = await _userManager.CreateAsync(newFlightAttendantUser7, "decorate");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newFlightAttendantUser7 = _db.Users.FirstOrDefault(u => u.UserName == "s.rankin@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newFlightAttendantUser7, "FlightAttendant") == false)
			{
				await _userManager.AddToRoleAsync(newFlightAttendantUser7, "FlightAttendant");
			}
			_db.SaveChanges();
		}
	}
}

