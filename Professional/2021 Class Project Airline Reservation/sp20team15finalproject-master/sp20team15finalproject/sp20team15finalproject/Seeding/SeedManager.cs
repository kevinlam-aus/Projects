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
	public static class SeedManagerIdentity
	{
		public static async Task AddManagers(IServiceProvider serviceProvider)
		{
			AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
			UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
			RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			//TODO: Add the needed roles
			//if role doesn't exist, add ita

			if (await _roleManager.RoleExistsAsync("Manager") == false)
			{
				await _roleManager.CreateAsync(new IdentityRole("Manager"));
			}
			AppUser newManagerUser2 = _db.Users.FirstOrDefault(u => u.Email =="e.rice@longhornairlines.neet");

			if (newManagerUser2 == null)
			{
				newManagerUser2 = new AppUser();
				newManagerUser2.UserName ="e.rice@longhornairlines.neet";
				newManagerUser2.Email ="e.rice@longhornairlines.neet";
				newManagerUser2.FirstName ="Eryn";
				newManagerUser2.LastName ="Rice";
				newManagerUser2.MiddleInitial ="M";
				newManagerUser2.Address ="3405 Rio Grande";
				newManagerUser2.City ="Dallas";
				newManagerUser2.State ="TX";
				newManagerUser2.ZipCode ="75043";
				newManagerUser2.PhoneNumber ="4693876657";

				var result = await _userManager.CreateAsync(newManagerUser2,"ricearoni");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "+ result.ToString());
				}
				_db.SaveChanges();
				newManagerUser2= _db.Users.FirstOrDefault(u => u.UserName == "e.rice@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newManagerUser2, "Manager") == false)
			{
				await _userManager.AddToRoleAsync(newManagerUser2, "Manager");
			}
			_db.SaveChanges();


			AppUser newManagerUser3 = _db.Users.FirstOrDefault(u => u.Email =="r.taylor@longhornairlines.neet");

			if (newManagerUser3 == null)
			{
				newManagerUser3 = new AppUser();
				newManagerUser3.UserName ="r.taylor@longhornairlines.neet";
				newManagerUser3.Email ="r.taylor@longhornairlines.neet";
				newManagerUser3.FirstName ="Rachel";
				newManagerUser3.LastName ="Taylor";
				newManagerUser3.MiddleInitial ="O";
				newManagerUser3.Address ="345 Longview Dr.";
				newManagerUser3.City ="Houston";
				newManagerUser3.State ="TX";
				newManagerUser3.ZipCode ="77002";
				newManagerUser3.PhoneNumber ="2814512631";

				var result = await _userManager.CreateAsync(newManagerUser3,"swansong");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "+ result.ToString());
				}
				_db.SaveChanges();
				newManagerUser3= _db.Users.FirstOrDefault(u => u.UserName == "r.taylor@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newManagerUser3, "Manager") == false)
			{
				await _userManager.AddToRoleAsync(newManagerUser3, "Manager");
			}
			_db.SaveChanges();


			AppUser newManagerUser4 = _db.Users.FirstOrDefault(u => u.Email =="a.rogers@longhornairlines.neet");

			if (newManagerUser4 == null)
			{
				newManagerUser4 = new AppUser();
				newManagerUser4.UserName ="a.rogers@longhornairlines.neet";
				newManagerUser4.Email ="a.rogers@longhornairlines.neet";
				newManagerUser4.FirstName ="Allen";
				newManagerUser4.LastName ="Rogers";
				newManagerUser4.MiddleInitial ="H";
				newManagerUser4.Address ="4965 Oak Hill";
				newManagerUser4.City ="Dallas";
				newManagerUser4.State ="TX";
				newManagerUser4.ZipCode ="75043";
				newManagerUser4.PhoneNumber ="4698752943";

				var result = await _userManager.CreateAsync(newManagerUser4,"evanescent");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "+ result.ToString());
				}
				_db.SaveChanges();
				newManagerUser4= _db.Users.FirstOrDefault(u => u.UserName == "a.rogers@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newManagerUser4, "Manager") == false)
			{
				await _userManager.AddToRoleAsync(newManagerUser4, "Manager");
			}
			_db.SaveChanges();


			AppUser newManagerUser5 = _db.Users.FirstOrDefault(u => u.Email =="w.sewell@longhornairlines.neet");

			if (newManagerUser5 == null)
			{
				newManagerUser5 = new AppUser();
				newManagerUser5.UserName ="w.sewell@longhornairlines.neet";
				newManagerUser5.Email ="w.sewell@longhornairlines.neet";
				newManagerUser5.FirstName ="William";
				newManagerUser5.LastName ="Sewell";
				newManagerUser5.MiddleInitial ="G";
				newManagerUser5.Address ="2365 51st St.";
				newManagerUser5.City ="Austin";
				newManagerUser5.State ="TX";
				newManagerUser5.ZipCode ="78705";
				newManagerUser5.PhoneNumber ="5124510084";

				var result = await _userManager.CreateAsync(newManagerUser5,"walkamile");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "+ result.ToString());
				}
				_db.SaveChanges();
				newManagerUser5= _db.Users.FirstOrDefault(u => u.UserName == "w.sewell@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newManagerUser5, "Manager") == false)
			{
				await _userManager.AddToRoleAsync(newManagerUser5, "Manager");
			}
			_db.SaveChanges();


		}
	}
}
