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
	public static class SeedCoPilotIdentity
	{
		public static async Task AddCoPilots(IServiceProvider serviceProvider)
		{
			AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
			UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
			RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			//TODO: Add the needed roles
			//if role doesn't exist, add ita

			if (await _roleManager.RoleExistsAsync("CoPilot") == false)
			{
				await _roleManager.CreateAsync(new IdentityRole("CoPilot"));
			}
			AppUser newCoPilotUser2 = _db.Users.FirstOrDefault(u => u.Email =="g.martinez@longhornairlines.neet");

			if (newCoPilotUser2 == null)
			{
				newCoPilotUser2 = new AppUser();
				newCoPilotUser2.UserName ="g.martinez@longhornairlines.neet";
				newCoPilotUser2.Email ="g.martinez@longhornairlines.neet";
				newCoPilotUser2.FirstName ="Gregory";
				newCoPilotUser2.LastName ="Martinez";
				newCoPilotUser2.MiddleInitial ="R";
				newCoPilotUser2.Address ="8295 Sunset Blvd.";
				newCoPilotUser2.City ="Austin";
				newCoPilotUser2.State ="TX";
				newCoPilotUser2.ZipCode ="78653";
				newCoPilotUser2.PhoneNumber ="5128746718";

				var result = await _userManager.CreateAsync(newCoPilotUser2,"fungus");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "+ result.ToString());
				}
				_db.SaveChanges();
				newCoPilotUser2= _db.Users.FirstOrDefault(u => u.UserName == "g.martinez@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newCoPilotUser2, "CoPilot") == false)
			{
				await _userManager.AddToRoleAsync(newCoPilotUser2, "CoPilot");
			}
			_db.SaveChanges();


			AppUser newCoPilotUser3 = _db.Users.FirstOrDefault(u => u.Email =="j.jackson@longhornairlines.neet");

			if (newCoPilotUser3 == null)
			{
				newCoPilotUser3 = new AppUser();
				newCoPilotUser3.UserName ="j.jackson@longhornairlines.neet";
				newCoPilotUser3.Email ="j.jackson@longhornairlines.neet";
				newCoPilotUser3.FirstName ="Jack";
				newCoPilotUser3.LastName ="Jackson";
				newCoPilotUser3.MiddleInitial ="J";
				newCoPilotUser3.Address ="222 Main";
				newCoPilotUser3.City ="Houston";
				newCoPilotUser3.State ="TX";
				newCoPilotUser3.ZipCode ="77004";
				newCoPilotUser3.PhoneNumber ="2815554545";

				var result = await _userManager.CreateAsync(newCoPilotUser3,"offbeat");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "+ result.ToString());
				}
				_db.SaveChanges();
				newCoPilotUser3= _db.Users.FirstOrDefault(u => u.UserName == "j.jackson@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newCoPilotUser3, "CoPilot") == false)
			{
				await _userManager.AddToRoleAsync(newCoPilotUser3, "CoPilot");
			}
			_db.SaveChanges();


			AppUser newCoPilotUser4 = _db.Users.FirstOrDefault(u => u.Email =="l.jones@longhornairlines.neet");

			if (newCoPilotUser4 == null)
			{
				newCoPilotUser4 = new AppUser();
				newCoPilotUser4.UserName ="l.jones@longhornairlines.neet";
				newCoPilotUser4.Email ="l.jones@longhornairlines.neet";
				newCoPilotUser4.FirstName ="Lester";
				newCoPilotUser4.LastName ="Jones";
				newCoPilotUser4.MiddleInitial ="L";
				newCoPilotUser4.Address ="999 LeBlat";
				newCoPilotUser4.City ="Houston";
				newCoPilotUser4.State ="TX";
				newCoPilotUser4.ZipCode ="77011";
				newCoPilotUser4.PhoneNumber ="2816662222";

				var result = await _userManager.CreateAsync(newCoPilotUser4,"kindly");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "+ result.ToString());
				}
				_db.SaveChanges();
				newCoPilotUser4= _db.Users.FirstOrDefault(u => u.UserName == "l.jones@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newCoPilotUser4, "CoPilot") == false)
			{
				await _userManager.AddToRoleAsync(newCoPilotUser4, "CoPilot");
			}
			_db.SaveChanges();


			AppUser newCoPilotUser5 = _db.Users.FirstOrDefault(u => u.Email =="m.lopez@longhornairlines.neet");

			if (newCoPilotUser5 == null)
			{
				newCoPilotUser5 = new AppUser();
				newCoPilotUser5.UserName ="m.lopez@longhornairlines.neet";
				newCoPilotUser5.Email ="m.lopez@longhornairlines.neet";
				newCoPilotUser5.FirstName ="Marshall";
				newCoPilotUser5.LastName ="Lopez";
				newCoPilotUser5.MiddleInitial ="T";
				newCoPilotUser5.Address ="90 SW North St";
				newCoPilotUser5.City ="Austin";
				newCoPilotUser5.State ="TX";
				newCoPilotUser5.ZipCode ="78719";
				newCoPilotUser5.PhoneNumber ="5124442222";

				var result = await _userManager.CreateAsync(newCoPilotUser5,"median");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "+ result.ToString());
				}
				_db.SaveChanges();
				newCoPilotUser5= _db.Users.FirstOrDefault(u => u.UserName == "m.lopez@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newCoPilotUser5, "CoPilot") == false)
			{
				await _userManager.AddToRoleAsync(newCoPilotUser5, "CoPilot");
			}
			_db.SaveChanges();


		}
	}
}
