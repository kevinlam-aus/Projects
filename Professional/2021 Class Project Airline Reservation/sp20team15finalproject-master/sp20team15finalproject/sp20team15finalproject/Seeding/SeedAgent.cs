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
	public static class SeedAgentIdentity
	{
		public static async Task AddAgents(IServiceProvider serviceProvider)
		{
			AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
			UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
			RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			//TODO: Add the needed roles
			//if role doesn't exist, add ita

			if (await _roleManager.RoleExistsAsync("Agent") == false)
			{
				await _roleManager.CreateAsync(new IdentityRole("Agent"));
			}
			AppUser newAgentUser2 = _db.Users.FirstOrDefault(u => u.Email == "t.jacobs@longhornairlines.neet");

			if (newAgentUser2 == null)
			{
				newAgentUser2 = new AppUser();
				newAgentUser2.UserName = "t.jacobs@longhornairlines.neet";
				newAgentUser2.Email = "t.jacobs@longhornairlines.neet";
				newAgentUser2.FirstName = "Todd";
				newAgentUser2.LastName = "Jacobs";
				newAgentUser2.MiddleInitial = "L";
				newAgentUser2.Address = "4564 Elm St.";
				newAgentUser2.City = "Dallas";
				newAgentUser2.State = "TX";
				newAgentUser2.ZipCode = "75032";
				newAgentUser2.PhoneNumber = "4694653365";

				var result = await _userManager.CreateAsync(newAgentUser2, "society");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newAgentUser2 = _db.Users.FirstOrDefault(u => u.UserName == "t.jacobs@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newAgentUser2, "Agent") == false)
			{
				await _userManager.AddToRoleAsync(newAgentUser2, "Agent");
			}
			_db.SaveChanges();


			AppUser newAgentUser3 = _db.Users.FirstOrDefault(u => u.Email == "a.taylor@longhornairlines.neet");

			if (newAgentUser3 == null)
			{
				newAgentUser3 = new AppUser();
				newAgentUser3.UserName = "a.taylor@longhornairlines.neet";
				newAgentUser3.Email = "a.taylor@longhornairlines.neet";
				newAgentUser3.FirstName = "Allison";
				newAgentUser3.LastName = "Taylor";
				newAgentUser3.MiddleInitial = "R";
				newAgentUser3.Address = "467 Nueces St.";
				newAgentUser3.City = "Dallas";
				newAgentUser3.State = "TX";
				newAgentUser3.ZipCode = "75206";
				newAgentUser3.PhoneNumber = "4694748452";

				var result = await _userManager.CreateAsync(newAgentUser3, "nostalgic");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newAgentUser3 = _db.Users.FirstOrDefault(u => u.UserName == "a.taylor@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newAgentUser3, "Agent") == false)
			{
				await _userManager.AddToRoleAsync(newAgentUser3, "Agent");
			}
			_db.SaveChanges();


			AppUser newAgentUser4 = _db.Users.FirstOrDefault(u => u.Email == "m.sheffield@longhornairlines.neet");

			if (newAgentUser4 == null)
			{
				newAgentUser4 = new AppUser();
				newAgentUser4.UserName = "m.sheffield@longhornairlines.neet";
				newAgentUser4.Email = "m.sheffield@longhornairlines.neet";
				newAgentUser4.FirstName = "Martin";
				newAgentUser4.LastName = "Sheffield";
				newAgentUser4.MiddleInitial = "J";
				newAgentUser4.Address = "3886 Avenue A";
				newAgentUser4.City = "Dallas";
				newAgentUser4.State = "TX";
				newAgentUser4.ZipCode = "75032";
				newAgentUser4.PhoneNumber = "4695479167";

				var result = await _userManager.CreateAsync(newAgentUser4, "longhorns");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newAgentUser4 = _db.Users.FirstOrDefault(u => u.UserName == "m.sheffield@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newAgentUser4, "Agent") == false)
			{
				await _userManager.AddToRoleAsync(newAgentUser4, "Agent");
			}
			_db.SaveChanges();


			AppUser newAgentUser5 = _db.Users.FirstOrDefault(u => u.Email == "j.macleod@longhornairlines.neet");

			if (newAgentUser5 == null)
			{
				newAgentUser5 = new AppUser();
				newAgentUser5.UserName = "j.macleod@longhornairlines.neet";
				newAgentUser5.Email = "j.macleod@longhornairlines.neet";
				newAgentUser5.FirstName = "Jennifer";
				newAgentUser5.LastName = "MacLeod";
				newAgentUser5.MiddleInitial = "D";
				newAgentUser5.Address = "2504 Far West Blvd.";
				newAgentUser5.City = "Houston";
				newAgentUser5.State = "TX";
				newAgentUser5.ZipCode = "77001";
				newAgentUser5.PhoneNumber = "2814748138";

				var result = await _userManager.CreateAsync(newAgentUser5, "smitty");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newAgentUser5 = _db.Users.FirstOrDefault(u => u.UserName == "j.macleod@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newAgentUser5, "Agent") == false)
			{
				await _userManager.AddToRoleAsync(newAgentUser5, "Agent");
			}
			_db.SaveChanges();


			AppUser newAgentUser6 = _db.Users.FirstOrDefault(u => u.Email == "j.tanner@longhornairlines.neet");

			if (newAgentUser6 == null)
			{
				newAgentUser6 = new AppUser();
				newAgentUser6.UserName = "j.tanner@longhornairlines.neet";
				newAgentUser6.Email = "j.tanner@longhornairlines.neet";
				newAgentUser6.FirstName = "Jeremy";
				newAgentUser6.LastName = "Tanner";
				newAgentUser6.MiddleInitial = "S";
				newAgentUser6.Address = "4347 Almstead";
				newAgentUser6.City = "Austin";
				newAgentUser6.State = "TX";
				newAgentUser6.ZipCode = "78705";
				newAgentUser6.PhoneNumber = "5124590929";

				var result = await _userManager.CreateAsync(newAgentUser6, "tanman");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newAgentUser6 = _db.Users.FirstOrDefault(u => u.UserName == "j.tanner@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newAgentUser6, "Agent") == false)
			{
				await _userManager.AddToRoleAsync(newAgentUser6, "Agent");
			}
			_db.SaveChanges();


			AppUser newAgentUser7 = _db.Users.FirstOrDefault(u => u.Email == "e.stuart@longhornairlines.neet");

			if (newAgentUser7 == null)
			{
				newAgentUser7 = new AppUser();
				newAgentUser7.UserName = "e.stuart@longhornairlines.neet";
				newAgentUser7.Email = "e.stuart@longhornairlines.neet";
				newAgentUser7.FirstName = "Eric";
				newAgentUser7.LastName = "Stuart";
				newAgentUser7.MiddleInitial = "F";
				newAgentUser7.Address = "5576 Toro Ring";
				newAgentUser7.City = "Austin";
				newAgentUser7.State = "TX";
				newAgentUser7.ZipCode = "78710";
				newAgentUser7.PhoneNumber = "5128178335";

				var result = await _userManager.CreateAsync(newAgentUser7, "stewboy");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newAgentUser7 = _db.Users.FirstOrDefault(u => u.UserName == "e.stuart@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newAgentUser7, "Agent") == false)
			{
				await _userManager.AddToRoleAsync(newAgentUser7, "Agent");
			}
			_db.SaveChanges();


			AppUser newAgentUser8 = _db.Users.FirstOrDefault(u => u.Email == "c.miller@longhornairlines.neet");

			if (newAgentUser8 == null)
			{
				newAgentUser8 = new AppUser();
				newAgentUser8.UserName = "c.miller@longhornairlines.neet";
				newAgentUser8.Email = "c.miller@longhornairlines.neet";
				newAgentUser8.FirstName = "Charles";
				newAgentUser8.LastName = "Miller";
				newAgentUser8.MiddleInitial = "R";
				newAgentUser8.Address = "8962 Main St.";
				newAgentUser8.City = "El Paso";
				newAgentUser8.State = "TX";
				newAgentUser8.ZipCode = "79901";
				newAgentUser8.PhoneNumber = "9157458615";

				var result = await _userManager.CreateAsync(newAgentUser8, "squirrel");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newAgentUser8 = _db.Users.FirstOrDefault(u => u.UserName == "c.miller@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newAgentUser8, "Agent") == false)
			{
				await _userManager.AddToRoleAsync(newAgentUser8, "Agent");
			}
			_db.SaveChanges();


			AppUser newAgentUser9 = _db.Users.FirstOrDefault(u => u.Email == "v.lawrence@longhornairlines.neet");

			if (newAgentUser9 == null)
			{
				newAgentUser9 = new AppUser();
				newAgentUser9.UserName = "v.lawrence@longhornairlines.neet";
				newAgentUser9.Email = "v.lawrence@longhornairlines.neet";
				newAgentUser9.FirstName = "Victoria";
				newAgentUser9.LastName = "Lawrence";
				newAgentUser9.MiddleInitial = "Y";
				newAgentUser9.Address = "6639 Butterfly Ln.";
				newAgentUser9.City = "Houston";
				newAgentUser9.State = "TX";
				newAgentUser9.ZipCode = "77003";
				newAgentUser9.PhoneNumber = "2819457399";

				var result = await _userManager.CreateAsync(newAgentUser9, "lottery");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newAgentUser9 = _db.Users.FirstOrDefault(u => u.UserName == "v.lawrence@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newAgentUser9, "Agent") == false)
			{
				await _userManager.AddToRoleAsync(newAgentUser9, "Agent");
			}
			_db.SaveChanges();


			AppUser newAgentUser10 = _db.Users.FirstOrDefault(u => u.Email == "e.markham@longhornairlines.neet");

			if (newAgentUser10 == null)
			{
				newAgentUser10 = new AppUser();
				newAgentUser10.UserName = "e.markham@longhornairlines.neet";
				newAgentUser10.Email = "e.markham@longhornairlines.neet";
				newAgentUser10.FirstName = "Elizabeth";
				newAgentUser10.LastName = "Markham";
				newAgentUser10.MiddleInitial = "K";
				newAgentUser10.Address = "7861 Chevy Chase";
				newAgentUser10.City = "Austin";
				newAgentUser10.State = "TX";
				newAgentUser10.ZipCode = "78712";
				newAgentUser10.PhoneNumber = "5124579845";

				var result = await _userManager.CreateAsync(newAgentUser10, "monty3");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newAgentUser10 = _db.Users.FirstOrDefault(u => u.UserName == "e.markham@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newAgentUser10, "Agent") == false)
			{
				await _userManager.AddToRoleAsync(newAgentUser10, "Agent");
			}
			_db.SaveChanges();


			AppUser newAgentUser11 = _db.Users.FirstOrDefault(u => u.Email == "s.saunders@longhornairlines.neet");

			if (newAgentUser11 == null)
			{
				newAgentUser11 = new AppUser();
				newAgentUser11.UserName = "s.saunders@longhornairlines.neet";
				newAgentUser11.Email = "s.saunders@longhornairlines.neet";
				newAgentUser11.FirstName = "Sarah";
				newAgentUser11.LastName = "Saunders";
				newAgentUser11.MiddleInitial = "M";
				newAgentUser11.Address = "332 Avenue C";
				newAgentUser11.City = "Austin";
				newAgentUser11.State = "TX";
				newAgentUser11.ZipCode = "78613";
				newAgentUser11.PhoneNumber = "5123497810";

				var result = await _userManager.CreateAsync(newAgentUser11, "rankmary");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newAgentUser11 = _db.Users.FirstOrDefault(u => u.UserName == "s.saunders@longhornairlines.neet");
			}
			if (await _userManager.IsInRoleAsync(newAgentUser11, "Agent") == false)
			{
				await _userManager.AddToRoleAsync(newAgentUser11, "Agent");
			}
			_db.SaveChanges();
		}
	}
}



