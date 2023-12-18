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
	public static class SeedPilotIdentity
	{
		public static async Task AddPilots(IServiceProvider serviceProvider)
		{
			AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
			UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
			RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			//TODO: Add the needed roles
			//if role doesn't exist, add ita

			if (await _roleManager.RoleExistsAsync("Pilot") == false)
			{
				await _roleManager.CreateAsync(new IdentityRole("Pilot"));
			}
			AppUser newPilotUser2 = _db.Users.FirstOrDefault(u => u.Email =="b.ingram@longhornairlines.neet");

			if (newPilotUser2 == null)
			{
				newPilotUser2 = new AppUser();
				newPilotUser2.UserName ="b.ingram@longhornairlines.neet";
				newPilotUser2.Email ="b.ingram@longhornairlines.neet";
				newPilotUser2.FirstName ="Brad";
				newPilotUser2.LastName ="Ingram";
				newPilotUser2.MiddleInitial ="S";
				newPilotUser2.Address ="6548 La Posada Ct.";
				newPilotUser2.City ="Dallas";
				newPilotUser2.State ="TX";
				newPilotUser2.ZipCode ="75209";
				newPilotUser2.PhoneNumber ="4694678821";

				var result = await _userManager.CreateAsync(newPilotUser2,"ingram45");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "+ result.ToString());
				}
				_db.SaveChanges();
				newPilotUser2= _db.Users.FirstOrDefault(u => u.UserName == "b.ingram@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newPilotUser2, "Pilot") == false)
			{
				await _userManager.AddToRoleAsync(newPilotUser2, "Pilot");
			}
			_db.SaveChanges();


			AppUser newPilotUser3 = _db.Users.FirstOrDefault(u => u.Email =="m.nguyen@longhornairlines.neet");

			if (newPilotUser3 == null)
			{
				newPilotUser3 = new AppUser();
				newPilotUser3.UserName ="m.nguyen@longhornairlines.neet";
				newPilotUser3.Email ="m.nguyen@longhornairlines.neet";
				newPilotUser3.FirstName ="Mary";
				newPilotUser3.LastName ="Nguyen";
				newPilotUser3.MiddleInitial ="J";
				newPilotUser3.Address ="465 N. Bear Cub";
				newPilotUser3.City ="Dallas";
				newPilotUser3.State ="TX";
				newPilotUser3.ZipCode ="75001";
				newPilotUser3.PhoneNumber ="4695524141";

				var result = await _userManager.CreateAsync(newPilotUser3,"landus");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "+ result.ToString());
				}
				_db.SaveChanges();
				newPilotUser3= _db.Users.FirstOrDefault(u => u.UserName == "m.nguyen@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newPilotUser3, "Pilot") == false)
			{
				await _userManager.AddToRoleAsync(newPilotUser3, "Pilot");
			}
			_db.SaveChanges();


			AppUser newPilotUser4 = _db.Users.FirstOrDefault(u => u.Email =="h.garcia@longhornairlines.neet");

			if (newPilotUser4 == null)
			{
				newPilotUser4 = new AppUser();
				newPilotUser4.UserName ="h.garcia@longhornairlines.neet";
				newPilotUser4.Email ="h.garcia@longhornairlines.neet";
				newPilotUser4.FirstName ="Hector";
				newPilotUser4.LastName ="Garcia";
				newPilotUser4.MiddleInitial ="W";
				newPilotUser4.Address ="777 PBR Drive";
				newPilotUser4.City ="Houston";
				newPilotUser4.State ="TX";
				newPilotUser4.ZipCode ="77012";
				newPilotUser4.PhoneNumber ="2811114444";

				var result = await _userManager.CreateAsync(newPilotUser4,"instrument");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "+ result.ToString());
				}
				_db.SaveChanges();
				newPilotUser4= _db.Users.FirstOrDefault(u => u.UserName == "h.garcia@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newPilotUser4, "Pilot") == false)
			{
				await _userManager.AddToRoleAsync(newPilotUser4, "Pilot");
			}
			_db.SaveChanges();


			AppUser newPilotUser5 = _db.Users.FirstOrDefault(u => u.Email =="b.larson@longhornairlines.neet");

			if (newPilotUser5 == null)
			{
				newPilotUser5 = new AppUser();
				newPilotUser5.UserName ="b.larson@longhornairlines.neet";
				newPilotUser5.Email ="b.larson@longhornairlines.neet";
				newPilotUser5.FirstName ="Bill";
				newPilotUser5.LastName ="Larson";
				newPilotUser5.MiddleInitial ="B";
				newPilotUser5.Address ="1212 N. First Ave";
				newPilotUser5.City ="Houston";
				newPilotUser5.State ="TX";
				newPilotUser5.ZipCode ="77025";
				newPilotUser5.PhoneNumber ="2815554444";

				var result = await _userManager.CreateAsync(newPilotUser5,"approval");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "+ result.ToString());
				}
				_db.SaveChanges();
				newPilotUser5= _db.Users.FirstOrDefault(u => u.UserName == "b.larson@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newPilotUser5, "Pilot") == false)
			{
				await _userManager.AddToRoleAsync(newPilotUser5, "Pilot");
			}
			_db.SaveChanges();


		}
	}
}
