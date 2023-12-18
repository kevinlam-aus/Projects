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
	public static class SeedCustomerIdentity
	{
		public static async Task AddCustomers(IServiceProvider serviceProvider)
		{
			AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
			UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
			RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			//TODO: Add the needed roles
			//if role doesn't exist, add ita

			if (await _roleManager.RoleExistsAsync("Customer") == false)
			{
				await _roleManager.CreateAsync(new IdentityRole("Customer"));
			}

			AppUser newCustUser2 = _db.Users.FirstOrDefault(u => u.Email == "cbaker@freserve.co.uk");

			var DOB2 = new DateTime(1949, 11, 23);

			if (newCustUser2 == null)
			{
				newCustUser2 = new AppUser();
				newCustUser2.UserName = "cbaker@freserve.co.uk";
				newCustUser2.Email = "cbaker@freserve.co.uk";
				newCustUser2.AdvantageNumber = "5001";
				newCustUser2.FirstName = "Christopher";
				newCustUser2.LastName = "Baker";
				newCustUser2.MiddleInitial = "L";
				newCustUser2.DOB = DOB2;
				newCustUser2.Address = "1245 Lake Anchorage Blvd.";
				newCustUser2.City = "Dallas";
				newCustUser2.State = "TX";
				newCustUser2.ZipCode = "75001";
				newCustUser2.PhoneNumber = "4695571146";
				newCustUser2.RewardMiles = 5000;

				var result = await _userManager.CreateAsync(newCustUser2, "hello");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser2 = _db.Users.FirstOrDefault(u => u.UserName == "cbaker@freserve.co.uk");
			}
			if (await _userManager.IsInRoleAsync(newCustUser2, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser2, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser3 = _db.Users.FirstOrDefault(u => u.Email == "banker@longhorn.net");

			var DOB3 = new DateTime(1962, 11, 27);

			if (newCustUser3 == null)
			{
				newCustUser3 = new AppUser();
				newCustUser3.UserName = "banker@longhorn.net";
				newCustUser3.Email = "banker@longhorn.net";
				newCustUser3.AdvantageNumber = "5002";
				newCustUser3.FirstName = "Michelle";
				newCustUser3.LastName = "Banks";
				newCustUser3.MiddleInitial = "";
				newCustUser3.DOB = DOB3;
				newCustUser3.Address = "1300 Tall Pine Lane";
				newCustUser3.City = "Dallas";
				newCustUser3.State = "TX";
				newCustUser3.ZipCode = "75002";
				newCustUser3.PhoneNumber = "4692678873";
				newCustUser3.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser3, "potato");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser3 = _db.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net");
			}
			if (await _userManager.IsInRoleAsync(newCustUser3, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser3, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser4 = _db.Users.FirstOrDefault(u => u.Email == "franco@aoll.com");

			var DOB4 = new DateTime(1992, 10, 11);

			if (newCustUser4 == null)
			{
				newCustUser4 = new AppUser();
				newCustUser4.UserName = "franco@aoll.com";
				newCustUser4.Email = "franco@aoll.com";
				newCustUser4.AdvantageNumber = "5003";
				newCustUser4.FirstName = "Franco";
				newCustUser4.LastName = "Broccolo";
				newCustUser4.MiddleInitial = "V";
				newCustUser4.DOB = DOB4;
				newCustUser4.Address = "62 Browning Road";
				newCustUser4.City = "Houston";
				newCustUser4.State = "TX";
				newCustUser4.ZipCode = "77003";
				newCustUser4.PhoneNumber = "2815659699";
				newCustUser4.RewardMiles = 10000;

				var result = await _userManager.CreateAsync(newCustUser4, "painting");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser4 = _db.Users.FirstOrDefault(u => u.UserName == "franco@aoll.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser4, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser4, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser5 = _db.Users.FirstOrDefault(u => u.Email == "wchang@gogle.com");

			var DOB5 = new DateTime(1997, 5, 16);

			if (newCustUser5 == null)
			{
				newCustUser5 = new AppUser();
				newCustUser5.UserName = "wchang@gogle.com";
				newCustUser5.Email = "wchang@gogle.com";
				newCustUser5.AdvantageNumber = "5004";
				newCustUser5.FirstName = "Wendy";
				newCustUser5.LastName = "Chang";
				newCustUser5.MiddleInitial = "L";
				newCustUser5.DOB = DOB5;
				newCustUser5.Address = "202 Bellmont Hall";
				newCustUser5.City = "Austin";
				newCustUser5.State = "TX";
				newCustUser5.ZipCode = "78719";
				newCustUser5.PhoneNumber = "5125943222";
				newCustUser5.RewardMiles = 5000;

				var result = await _userManager.CreateAsync(newCustUser5, "texas");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser5 = _db.Users.FirstOrDefault(u => u.UserName == "wchang@gogle.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser5, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser5, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser6 = _db.Users.FirstOrDefault(u => u.Email == "limchou@yoho.com");

			var DOB6 = new DateTime(1970, 4, 6);

			if (newCustUser6 == null)
			{
				newCustUser6 = new AppUser();
				newCustUser6.UserName = "limchou@yoho.com";
				newCustUser6.Email = "limchou@yoho.com";
				newCustUser6.AdvantageNumber = "5005";
				newCustUser6.FirstName = "Lim";
				newCustUser6.LastName = "Chou";
				newCustUser6.MiddleInitial = "";
				newCustUser6.DOB = DOB6;
				newCustUser6.Address = "1600 Teresa Lane";
				newCustUser6.City = "Fort Meyers";
				newCustUser6.State = "FL";
				newCustUser6.ZipCode = "33917";
				newCustUser6.PhoneNumber = "8137724599";
				newCustUser6.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser6, "Anchorage");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser6 = _db.Users.FirstOrDefault(u => u.UserName == "limchou@yoho.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser6, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser6, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser7 = _db.Users.FirstOrDefault(u => u.Email == "shdixon@utx.edu");

			var DOB7 = new DateTime(1984, 1, 12);

			if (newCustUser7 == null)
			{
				newCustUser7 = new AppUser();
				newCustUser7.UserName = "shdixon@utx.edu";
				newCustUser7.Email = "shdixon@utx.edu";
				newCustUser7.AdvantageNumber = "5006";
				newCustUser7.FirstName = "Shan";
				newCustUser7.LastName = "Dixon";
				newCustUser7.MiddleInitial = "D";
				newCustUser7.DOB = DOB7;
				newCustUser7.Address = "234 Holston Circle";
				newCustUser7.City = "Sheffield";
				newCustUser7.State = "AL";
				newCustUser7.ZipCode = "35662";
				newCustUser7.PhoneNumber = "2052643255";
				newCustUser7.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser7, "pepperoni");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser7 = _db.Users.FirstOrDefault(u => u.UserName == "shdixon@utx.edu");
			}
			if (await _userManager.IsInRoleAsync(newCustUser7, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser7, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser8 = _db.Users.FirstOrDefault(u => u.Email == "j.b.evans@aheca.org");

			var DOB8 = new DateTime(1959, 9, 9);

			if (newCustUser8 == null)
			{
				newCustUser8 = new AppUser();
				newCustUser8.UserName = "j.b.evans@aheca.org";
				newCustUser8.Email = "j.b.evans@aheca.org";
				newCustUser8.AdvantageNumber = "5007";
				newCustUser8.FirstName = "Jim Bob";
				newCustUser8.LastName = "Evans";
				newCustUser8.MiddleInitial = "";
				newCustUser8.DOB = DOB8;
				newCustUser8.Address = "506 Farrell Circle";
				newCustUser8.City = "Austin";
				newCustUser8.State = "TX";
				newCustUser8.ZipCode = "78705";
				newCustUser8.PhoneNumber = "5122565834";
				newCustUser8.RewardMiles = 9000;

				var result = await _userManager.CreateAsync(newCustUser8, "longhorns");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser8 = _db.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org");
			}
			if (await _userManager.IsInRoleAsync(newCustUser8, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser8, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser9 = _db.Users.FirstOrDefault(u => u.Email == "feeley@longhorn.org");

			var DOB9 = new DateTime(2002, 1, 12);

			if (newCustUser9 == null)
			{
				newCustUser9 = new AppUser();
				newCustUser9.UserName = "feeley@longhorn.org";
				newCustUser9.Email = "feeley@longhorn.org";
				newCustUser9.AdvantageNumber = "5008";
				newCustUser9.FirstName = "Lou Ann";
				newCustUser9.LastName = "Feeley";
				newCustUser9.MiddleInitial = "K";
				newCustUser9.DOB = DOB9;
				newCustUser9.Address = "600 S 8th Street W";
				newCustUser9.City = "El Paso";
				newCustUser9.State = "TX";
				newCustUser9.ZipCode = "79901";
				newCustUser9.PhoneNumber = "9152556749";
				newCustUser9.RewardMiles = 6000;

				var result = await _userManager.CreateAsync(newCustUser9, "aggies");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser9 = _db.Users.FirstOrDefault(u => u.UserName == "feeley@longhorn.org");
			}
			if (await _userManager.IsInRoleAsync(newCustUser9, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser9, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser10 = _db.Users.FirstOrDefault(u => u.Email == "tfreeley@minnetonka.ci.us");

			var DOB10 = new DateTime(1991, 2, 4);

			if (newCustUser10 == null)
			{
				newCustUser10 = new AppUser();
				newCustUser10.UserName = "tfreeley@minnetonka.ci.us";
				newCustUser10.Email = "tfreeley@minnetonka.ci.us";
				newCustUser10.AdvantageNumber = "5009";
				newCustUser10.FirstName = "Tesa";
				newCustUser10.LastName = "Freeley";
				newCustUser10.MiddleInitial = "P";
				newCustUser10.DOB = DOB10;
				newCustUser10.Address = "4448 Fairview Ave.";
				newCustUser10.City = "Minnetonka";
				newCustUser10.State = "MN";
				newCustUser10.ZipCode = "55343";
				newCustUser10.PhoneNumber = "6123255687";
				newCustUser10.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser10, "raiders");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser10 = _db.Users.FirstOrDefault(u => u.UserName == "tfreeley@minnetonka.ci.us");
			}
			if (await _userManager.IsInRoleAsync(newCustUser10, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser10, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser11 = _db.Users.FirstOrDefault(u => u.Email == "mgarcia@gogle.com");

			var DOB11 = new DateTime(1991, 10, 2);

			if (newCustUser11 == null)
			{
				newCustUser11 = new AppUser();
				newCustUser11.UserName = "mgarcia@gogle.com";
				newCustUser11.Email = "mgarcia@gogle.com";
				newCustUser11.AdvantageNumber = "5010";
				newCustUser11.FirstName = "Margaret";
				newCustUser11.LastName = "Garcia";
				newCustUser11.MiddleInitial = "L";
				newCustUser11.DOB = DOB11;
				newCustUser11.Address = "594 Longview";
				newCustUser11.City = "Dallas";
				newCustUser11.State = "TX";
				newCustUser11.ZipCode = "75043";
				newCustUser11.PhoneNumber = "4696593544";
				newCustUser11.RewardMiles = 4000;

				var result = await _userManager.CreateAsync(newCustUser11, "mustangs");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser11 = _db.Users.FirstOrDefault(u => u.UserName == "mgarcia@gogle.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser11, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser11, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser12 = _db.Users.FirstOrDefault(u => u.Email == "chaley@thug.com");

			var DOB12 = new DateTime(1974, 7, 10);

			if (newCustUser12 == null)
			{
				newCustUser12 = new AppUser();
				newCustUser12.UserName = "chaley@thug.com";
				newCustUser12.Email = "chaley@thug.com";
				newCustUser12.AdvantageNumber = "5011";
				newCustUser12.FirstName = "Charles";
				newCustUser12.LastName = "Haley";
				newCustUser12.MiddleInitial = "E";
				newCustUser12.DOB = DOB12;
				newCustUser12.Address = "One Cowboy Pkwy";
				newCustUser12.City = "Dallas";
				newCustUser12.State = "TX";
				newCustUser12.ZipCode = "75032";
				newCustUser12.PhoneNumber = "4698475583";
				newCustUser12.RewardMiles = 7000;

				var result = await _userManager.CreateAsync(newCustUser12, "onetime");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser12 = _db.Users.FirstOrDefault(u => u.UserName == "chaley@thug.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser12, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser12, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser13 = _db.Users.FirstOrDefault(u => u.Email == "jeffh@sonic.com");

			var DOB13 = new DateTime(2014, 3, 10);

			if (newCustUser13 == null)
			{
				newCustUser13 = new AppUser();
				newCustUser13.UserName = "jeffh@sonic.com";
				newCustUser13.Email = "jeffh@sonic.com";
				newCustUser13.AdvantageNumber = "5012";
				newCustUser13.FirstName = "Jeffrey";
				newCustUser13.LastName = "Hampton";
				newCustUser13.MiddleInitial = "T";
				newCustUser13.DOB = DOB13;
				newCustUser13.Address = "337 38th St.";
				newCustUser13.City = "Dallas";
				newCustUser13.State = "TX";
				newCustUser13.ZipCode = "75209";
				newCustUser13.PhoneNumber = "4696978613";
				newCustUser13.RewardMiles = 5000;

				var result = await _userManager.CreateAsync(newCustUser13, "hampton1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser13 = _db.Users.FirstOrDefault(u => u.UserName == "jeffh@sonic.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser13, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser13, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser14 = _db.Users.FirstOrDefault(u => u.Email == "wjhearniii@umich.org");

			var DOB14 = new DateTime(1950, 8, 5);

			if (newCustUser14 == null)
			{
				newCustUser14 = new AppUser();
				newCustUser14.UserName = "wjhearniii@umich.org";
				newCustUser14.Email = "wjhearniii@umich.org";
				newCustUser14.AdvantageNumber = "5013";
				newCustUser14.FirstName = "John";
				newCustUser14.LastName = "Hearn";
				newCustUser14.MiddleInitial = "B";
				newCustUser14.DOB = DOB14;
				newCustUser14.Address = "4225 North First";
				newCustUser14.City = "Houston";
				newCustUser14.State = "TX";
				newCustUser14.ZipCode = "77010";
				newCustUser14.PhoneNumber = "2818965621";
				newCustUser14.RewardMiles = 7000;

				var result = await _userManager.CreateAsync(newCustUser14, "jhearn22");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser14 = _db.Users.FirstOrDefault(u => u.UserName == "wjhearniii@umich.org");
			}
			if (await _userManager.IsInRoleAsync(newCustUser14, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser14, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser15 = _db.Users.FirstOrDefault(u => u.Email == "ahick@yaho.com");

			var DOB15 = new DateTime(2005, 12, 8);

			if (newCustUser15 == null)
			{
				newCustUser15 = new AppUser();
				newCustUser15.UserName = "ahick@yaho.com";
				newCustUser15.Email = "ahick@yaho.com";
				newCustUser15.AdvantageNumber = "5014";
				newCustUser15.FirstName = "Anthony";
				newCustUser15.LastName = "Hicks";
				newCustUser15.MiddleInitial = "J";
				newCustUser15.DOB = DOB15;
				newCustUser15.Address = "32 NE Garden Ln., Ste 910";
				newCustUser15.City = "Houston";
				newCustUser15.State = "TX";
				newCustUser15.ZipCode = "77012";
				newCustUser15.PhoneNumber = "2815788965";
				newCustUser15.RewardMiles = 6000;

				var result = await _userManager.CreateAsync(newCustUser15, "hickhickup");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser15 = _db.Users.FirstOrDefault(u => u.UserName == "ahick@yaho.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser15, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser15, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser16 = _db.Users.FirstOrDefault(u => u.Email == "ingram@jack.com");

			var DOB16 = new DateTime(2016, 9, 5);

			if (newCustUser16 == null)
			{
				newCustUser16 = new AppUser();
				newCustUser16.UserName = "ingram@jack.com";
				newCustUser16.Email = "ingram@jack.com";
				newCustUser16.AdvantageNumber = "5015";
				newCustUser16.FirstName = "Brad";
				newCustUser16.LastName = "Ingram";
				newCustUser16.MiddleInitial = "S";
				newCustUser16.DOB = DOB16;
				newCustUser16.Address = "6548 La Posada Ct.";
				newCustUser16.City = "Austin";
				newCustUser16.State = "TX";
				newCustUser16.ZipCode = "78613";
				newCustUser16.PhoneNumber = "5124678821";
				newCustUser16.RewardMiles = 8000;

				var result = await _userManager.CreateAsync(newCustUser16, "ingram2015");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser16 = _db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser16, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser16, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser17 = _db.Users.FirstOrDefault(u => u.Email == "toddj@yourmom.com");

			var DOB17 = new DateTime(1999, 1, 20);

			if (newCustUser17 == null)
			{
				newCustUser17 = new AppUser();
				newCustUser17.UserName = "toddj@yourmom.com";
				newCustUser17.Email = "toddj@yourmom.com";
				newCustUser17.AdvantageNumber = "5016";
				newCustUser17.FirstName = "Todd";
				newCustUser17.LastName = "Jacobs";
				newCustUser17.MiddleInitial = "L";
				newCustUser17.DOB = DOB17;
				newCustUser17.Address = "4564 Elm St.";
				newCustUser17.City = "El Paso";
				newCustUser17.State = "TX";
				newCustUser17.ZipCode = "79991";
				newCustUser17.PhoneNumber = "9154653365";
				newCustUser17.RewardMiles = 5000;

				var result = await _userManager.CreateAsync(newCustUser17, "toddy25");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser17 = _db.Users.FirstOrDefault(u => u.UserName == "toddj@yourmom.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser17, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser17, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser18 = _db.Users.FirstOrDefault(u => u.Email == "thequeen@aska.net");

			var DOB18 = new DateTime(2000, 4, 14);

			if (newCustUser18 == null)
			{
				newCustUser18 = new AppUser();
				newCustUser18.UserName = "thequeen@aska.net";
				newCustUser18.Email = "thequeen@aska.net";
				newCustUser18.AdvantageNumber = "5017";
				newCustUser18.FirstName = "Victoria";
				newCustUser18.LastName = "Lawrence";
				newCustUser18.MiddleInitial = "M";
				newCustUser18.DOB = DOB18;
				newCustUser18.Address = "6639 Butterfly Ln.";
				newCustUser18.City = "El Paso";
				newCustUser18.State = "TX";
				newCustUser18.ZipCode = "79930";
				newCustUser18.PhoneNumber = "9159457399";
				newCustUser18.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser18, "something");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser18 = _db.Users.FirstOrDefault(u => u.UserName == "thequeen@aska.net");
			}
			if (await _userManager.IsInRoleAsync(newCustUser18, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser18, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser19 = _db.Users.FirstOrDefault(u => u.Email == "linebacker@gogle.com");

			var DOB19 = new DateTime(2013, 12, 2);

			if (newCustUser19 == null)
			{
				newCustUser19 = new AppUser();
				newCustUser19.UserName = "linebacker@gogle.com";
				newCustUser19.Email = "linebacker@gogle.com";
				newCustUser19.AdvantageNumber = "5018";
				newCustUser19.FirstName = "Erik";
				newCustUser19.LastName = "Lineback";
				newCustUser19.MiddleInitial = "W";
				newCustUser19.DOB = DOB19;
				newCustUser19.Address = "1300 Netherland St";
				newCustUser19.City = "Austin";
				newCustUser19.State = "TX";
				newCustUser19.ZipCode = "78613";
				newCustUser19.PhoneNumber = "5122449976";
				newCustUser19.RewardMiles = 6000;

				var result = await _userManager.CreateAsync(newCustUser19, "Password1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser19 = _db.Users.FirstOrDefault(u => u.UserName == "linebacker@gogle.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser19, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser19, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser20 = _db.Users.FirstOrDefault(u => u.Email == "elowe@netscare.net");

			var DOB20 = new DateTime(1977, 12, 7);

			if (newCustUser20 == null)
			{
				newCustUser20 = new AppUser();
				newCustUser20.UserName = "elowe@netscare.net";
				newCustUser20.Email = "elowe@netscare.net";
				newCustUser20.AdvantageNumber = "5019";
				newCustUser20.FirstName = "Ernest";
				newCustUser20.LastName = "Lowe";
				newCustUser20.MiddleInitial = "S";
				newCustUser20.DOB = DOB20;
				newCustUser20.Address = "3201 Pine Drive";
				newCustUser20.City = "Dallas";
				newCustUser20.State = "TX";
				newCustUser20.ZipCode = "75039";
				newCustUser20.PhoneNumber = "4695344627";
				newCustUser20.RewardMiles = 2000;

				var result = await _userManager.CreateAsync(newCustUser20, "aclfest2017");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser20 = _db.Users.FirstOrDefault(u => u.UserName == "elowe@netscare.net");
			}
			if (await _userManager.IsInRoleAsync(newCustUser20, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser20, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser21 = _db.Users.FirstOrDefault(u => u.Email == "cluce@gogle.com");

			var DOB21 = new DateTime(1949, 3, 16);

			if (newCustUser21 == null)
			{
				newCustUser21 = new AppUser();
				newCustUser21.UserName = "cluce@gogle.com";
				newCustUser21.Email = "cluce@gogle.com";
				newCustUser21.AdvantageNumber = "5020";
				newCustUser21.FirstName = "Chuck";
				newCustUser21.LastName = "Luce";
				newCustUser21.MiddleInitial = "B";
				newCustUser21.DOB = DOB21;
				newCustUser21.Address = "2345 Rolling Clouds";
				newCustUser21.City = "Austin";
				newCustUser21.State = "TX";
				newCustUser21.ZipCode = "78712";
				newCustUser21.PhoneNumber = "5126983548";
				newCustUser21.RewardMiles = 8000;

				var result = await _userManager.CreateAsync(newCustUser21, "nothinggood");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser21 = _db.Users.FirstOrDefault(u => u.UserName == "cluce@gogle.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser21, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser21, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser22 = _db.Users.FirstOrDefault(u => u.Email == "mackcloud@george.com");

			var DOB22 = new DateTime(1947, 2, 21);

			if (newCustUser22 == null)
			{
				newCustUser22 = new AppUser();
				newCustUser22.UserName = "mackcloud@george.com";
				newCustUser22.Email = "mackcloud@george.com";
				newCustUser22.AdvantageNumber = "5021";
				newCustUser22.FirstName = "Jennifer";
				newCustUser22.LastName = "MacLeod";
				newCustUser22.MiddleInitial = "D";
				newCustUser22.DOB = DOB22;
				newCustUser22.Address = "2504 Far West Blvd.";
				newCustUser22.City = "Houston";
				newCustUser22.State = "TX";
				newCustUser22.ZipCode = "77012";
				newCustUser22.PhoneNumber = "2814748138";
				newCustUser22.RewardMiles = 5000;

				var result = await _userManager.CreateAsync(newCustUser22, "whatever");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser22 = _db.Users.FirstOrDefault(u => u.UserName == "mackcloud@george.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser22, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser22, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser23 = _db.Users.FirstOrDefault(u => u.Email == "cmartin@beets.com");

			var DOB23 = new DateTime(1972, 3, 20);

			if (newCustUser23 == null)
			{
				newCustUser23 = new AppUser();
				newCustUser23.UserName = "cmartin@beets.com";
				newCustUser23.Email = "cmartin@beets.com";
				newCustUser23.AdvantageNumber = "5022";
				newCustUser23.FirstName = "Elizabeth";
				newCustUser23.LastName = "Markham";
				newCustUser23.MiddleInitial = "P";
				newCustUser23.DOB = DOB23;
				newCustUser23.Address = "7861 Chevy Chase";
				newCustUser23.City = "Dallas";
				newCustUser23.State = "TX";
				newCustUser23.ZipCode = "75249";
				newCustUser23.PhoneNumber = "4694579845";
				newCustUser23.RewardMiles = 7000;

				var result = await _userManager.CreateAsync(newCustUser23, "whocares");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser23 = _db.Users.FirstOrDefault(u => u.UserName == "cmartin@beets.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser23, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser23, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser24 = _db.Users.FirstOrDefault(u => u.Email == "clarence@yoho.com");

			var DOB24 = new DateTime(1992, 7, 19);

			if (newCustUser24 == null)
			{
				newCustUser24 = new AppUser();
				newCustUser24.UserName = "clarence@yoho.com";
				newCustUser24.Email = "clarence@yoho.com";
				newCustUser24.AdvantageNumber = "5023";
				newCustUser24.FirstName = "Clarence";
				newCustUser24.LastName = "Martin";
				newCustUser24.MiddleInitial = "A";
				newCustUser24.DOB = DOB24;
				newCustUser24.Address = "87 Alcedo St.";
				newCustUser24.City = "San Diego";
				newCustUser24.State = "CA";
				newCustUser24.ZipCode = "82448";
				newCustUser24.PhoneNumber = "9204955201";
				newCustUser24.RewardMiles = 2000;

				var result = await _userManager.CreateAsync(newCustUser24, "xcellent");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser24 = _db.Users.FirstOrDefault(u => u.UserName == "clarence@yoho.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser24, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser24, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser25 = _db.Users.FirstOrDefault(u => u.Email == "gregmartinez@drdre.com");

			var DOB25 = new DateTime(1947, 5, 28);

			if (newCustUser25 == null)
			{
				newCustUser25 = new AppUser();
				newCustUser25.UserName = "gregmartinez@drdre.com";
				newCustUser25.Email = "gregmartinez@drdre.com";
				newCustUser25.AdvantageNumber = "5024";
				newCustUser25.FirstName = "Gregory";
				newCustUser25.LastName = "Martinez";
				newCustUser25.MiddleInitial = "R";
				newCustUser25.DOB = DOB25;
				newCustUser25.Address = "8295 Sunset Blvd.";
				newCustUser25.City = "Austin";
				newCustUser25.State = "TX";
				newCustUser25.ZipCode = "78708";
				newCustUser25.PhoneNumber = "5128746718";
				newCustUser25.RewardMiles = 1000;

				var result = await _userManager.CreateAsync(newCustUser25, "snowsnow");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser25 = _db.Users.FirstOrDefault(u => u.UserName == "gregmartinez@drdre.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser25, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser25, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser26 = _db.Users.FirstOrDefault(u => u.Email == "cmiller@bob.com");

			var DOB26 = new DateTime(1990, 10, 15);

			if (newCustUser26 == null)
			{
				newCustUser26 = new AppUser();
				newCustUser26.UserName = "cmiller@bob.com";
				newCustUser26.Email = "cmiller@bob.com";
				newCustUser26.AdvantageNumber = "5025";
				newCustUser26.FirstName = "Charles";
				newCustUser26.LastName = "Miller";
				newCustUser26.MiddleInitial = "R";
				newCustUser26.DOB = DOB26;
				newCustUser26.Address = "8962 Main St.";
				newCustUser26.City = "Dallas";
				newCustUser26.State = "TX";
				newCustUser26.ZipCode = "75215";
				newCustUser26.PhoneNumber = "4697458615";
				newCustUser26.RewardMiles = 2000;

				var result = await _userManager.CreateAsync(newCustUser26, "mydogspot");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser26 = _db.Users.FirstOrDefault(u => u.UserName == "cmiller@bob.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser26, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser26, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser27 = _db.Users.FirstOrDefault(u => u.Email == "knelson@aoll.com");

			var DOB27 = new DateTime(1971, 7, 13);

			if (newCustUser27 == null)
			{
				newCustUser27 = new AppUser();
				newCustUser27.UserName = "knelson@aoll.com";
				newCustUser27.Email = "knelson@aoll.com";
				newCustUser27.AdvantageNumber = "5026";
				newCustUser27.FirstName = "Kelly";
				newCustUser27.LastName = "Nelson";
				newCustUser27.MiddleInitial = "T";
				newCustUser27.DOB = DOB27;
				newCustUser27.Address = "2601 Red River";
				newCustUser27.City = "Dallas";
				newCustUser27.State = "TX";
				newCustUser27.ZipCode = "75252";
				newCustUser27.PhoneNumber = "4692926966";
				newCustUser27.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser27, "spotmydog");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser27 = _db.Users.FirstOrDefault(u => u.UserName == "knelson@aoll.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser27, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser27, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser28 = _db.Users.FirstOrDefault(u => u.Email == "joewin@xfactor.com");

			var DOB28 = new DateTime(2008, 3, 17);

			if (newCustUser28 == null)
			{
				newCustUser28 = new AppUser();
				newCustUser28.UserName = "joewin@xfactor.com";
				newCustUser28.Email = "joewin@xfactor.com";
				newCustUser28.AdvantageNumber = "5027";
				newCustUser28.FirstName = "Joe";
				newCustUser28.LastName = "Nguyen";
				newCustUser28.MiddleInitial = "C";
				newCustUser28.DOB = DOB28;
				newCustUser28.Address = "1249 4th SW St.";
				newCustUser28.City = "Dallas";
				newCustUser28.State = "TX";
				newCustUser28.ZipCode = "75263";
				newCustUser28.PhoneNumber = "4693125897";
				newCustUser28.RewardMiles = 9000;

				var result = await _userManager.CreateAsync(newCustUser28, "joejoejoe");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser28 = _db.Users.FirstOrDefault(u => u.UserName == "joewin@xfactor.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser28, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser28, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser29 = _db.Users.FirstOrDefault(u => u.Email == "orielly@foxnews.cnn");

			var DOB29 = new DateTime(1959, 7, 8);

			if (newCustUser29 == null)
			{
				newCustUser29 = new AppUser();
				newCustUser29.UserName = "orielly@foxnews.cnn";
				newCustUser29.Email = "orielly@foxnews.cnn";
				newCustUser29.AdvantageNumber = "5028";
				newCustUser29.FirstName = "Bill";
				newCustUser29.LastName = "O'Reilly";
				newCustUser29.MiddleInitial = "T";
				newCustUser29.DOB = DOB29;
				newCustUser29.Address = "8800 Gringo Drive";
				newCustUser29.City = "Dallas";
				newCustUser29.State = "TX";
				newCustUser29.ZipCode = "75263";
				newCustUser29.PhoneNumber = "4693450925";
				newCustUser29.RewardMiles = 5000;

				var result = await _userManager.CreateAsync(newCustUser29, "billyboy");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser29 = _db.Users.FirstOrDefault(u => u.UserName == "orielly@foxnews.cnn");
			}
			if (await _userManager.IsInRoleAsync(newCustUser29, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser29, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser30 = _db.Users.FirstOrDefault(u => u.Email == "ankaisrad@gogle.com");

			var DOB30 = new DateTime(1966, 5, 19);

			if (newCustUser30 == null)
			{
				newCustUser30 = new AppUser();
				newCustUser30.UserName = "ankaisrad@gogle.com";
				newCustUser30.Email = "ankaisrad@gogle.com";
				newCustUser30.AdvantageNumber = "5029";
				newCustUser30.FirstName = "Anka";
				newCustUser30.LastName = "Radkovich";
				newCustUser30.MiddleInitial = "L";
				newCustUser30.DOB = DOB30;
				newCustUser30.Address = "1300 Elliott Pl";
				newCustUser30.City = "Houston";
				newCustUser30.State = "TX";
				newCustUser30.ZipCode = "77010";
				newCustUser30.PhoneNumber = "2812345566";
				newCustUser30.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser30, "radgirl");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser30 = _db.Users.FirstOrDefault(u => u.UserName == "ankaisrad@gogle.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser30, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser30, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser31 = _db.Users.FirstOrDefault(u => u.Email == "megrhodes@freserve.co.uk");

			var DOB31 = new DateTime(1965, 3, 12);

			if (newCustUser31 == null)
			{
				newCustUser31 = new AppUser();
				newCustUser31.UserName = "megrhodes@freserve.co.uk";
				newCustUser31.Email = "megrhodes@freserve.co.uk";
				newCustUser31.AdvantageNumber = "5030";
				newCustUser31.FirstName = "Megan";
				newCustUser31.LastName = "Rhodes";
				newCustUser31.MiddleInitial = "C";
				newCustUser31.DOB = DOB31;
				newCustUser31.Address = "4587 Enfield Rd.";
				newCustUser31.City = "Houston";
				newCustUser31.State = "TX";
				newCustUser31.ZipCode = "77013";
				newCustUser31.PhoneNumber = "2813744746";
				newCustUser31.RewardMiles = 6000;

				var result = await _userManager.CreateAsync(newCustUser31, "meganr34");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser31 = _db.Users.FirstOrDefault(u => u.UserName == "megrhodes@freserve.co.uk");
			}
			if (await _userManager.IsInRoleAsync(newCustUser31, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser31, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser32 = _db.Users.FirstOrDefault(u => u.Email == "erynrice@aoll.com");

			var DOB32 = new DateTime(1975, 4, 28);

			if (newCustUser32 == null)
			{
				newCustUser32 = new AppUser();
				newCustUser32.UserName = "erynrice@aoll.com";
				newCustUser32.Email = "erynrice@aoll.com";
				newCustUser32.AdvantageNumber = "5031";
				newCustUser32.FirstName = "Eryn";
				newCustUser32.LastName = "Rice";
				newCustUser32.MiddleInitial = "M";
				newCustUser32.DOB = DOB32;
				newCustUser32.Address = "3405 Rio Grande";
				newCustUser32.City = "Houston";
				newCustUser32.State = "TX";
				newCustUser32.ZipCode = "77015";
				newCustUser32.PhoneNumber = "2813876657";
				newCustUser32.RewardMiles = 3000;

				var result = await _userManager.CreateAsync(newCustUser32, "ricearoni");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser32 = _db.Users.FirstOrDefault(u => u.UserName == "erynrice@aoll.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser32, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser32, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser33 = _db.Users.FirstOrDefault(u => u.Email == "jorge@noclue.com");

			var DOB33 = new DateTime(1953, 12, 8);

			if (newCustUser33 == null)
			{
				newCustUser33 = new AppUser();
				newCustUser33.UserName = "jorge@noclue.com";
				newCustUser33.Email = "jorge@noclue.com";
				newCustUser33.AdvantageNumber = "5032";
				newCustUser33.FirstName = "Jorge";
				newCustUser33.LastName = "Rodriguez";
				newCustUser33.MiddleInitial = "";
				newCustUser33.DOB = DOB33;
				newCustUser33.Address = "6788 Cotter Street";
				newCustUser33.City = "Houston";
				newCustUser33.State = "TX";
				newCustUser33.ZipCode = "77000";
				newCustUser33.PhoneNumber = "2818904374";
				newCustUser33.RewardMiles = 5000;

				var result = await _userManager.CreateAsync(newCustUser33, "jrod2017");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser33 = _db.Users.FirstOrDefault(u => u.UserName == "jorge@noclue.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser33, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser33, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser34 = _db.Users.FirstOrDefault(u => u.Email == "mrrogers@lovelyday.com");

			var DOB34 = new DateTime(1973, 4, 22);

			if (newCustUser34 == null)
			{
				newCustUser34 = new AppUser();
				newCustUser34.UserName = "mrrogers@lovelyday.com";
				newCustUser34.Email = "mrrogers@lovelyday.com";
				newCustUser34.AdvantageNumber = "5033";
				newCustUser34.FirstName = "Allen";
				newCustUser34.LastName = "Rogers";
				newCustUser34.MiddleInitial = "B";
				newCustUser34.DOB = DOB34;
				newCustUser34.Address = "4965 Oak Hill";
				newCustUser34.City = "Houston";
				newCustUser34.State = "TX";
				newCustUser34.ZipCode = "77010";
				newCustUser34.PhoneNumber = "2818752943";
				newCustUser34.RewardMiles = 8000;

				var result = await _userManager.CreateAsync(newCustUser34, "rogerthat");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser34 = _db.Users.FirstOrDefault(u => u.UserName == "mrrogers@lovelyday.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser34, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser34, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser35 = _db.Users.FirstOrDefault(u => u.Email == "stjean@athome.com");

			var DOB35 = new DateTime(1995, 2, 19);

			if (newCustUser35 == null)
			{
				newCustUser35 = new AppUser();
				newCustUser35.UserName = "stjean@athome.com";
				newCustUser35.Email = "stjean@athome.com";
				newCustUser35.AdvantageNumber = "5034";
				newCustUser35.FirstName = "Olivier";
				newCustUser35.LastName = "Saint-Jean";
				newCustUser35.MiddleInitial = "M";
				newCustUser35.DOB = DOB35;
				newCustUser35.Address = "255 Toncray Dr.";
				newCustUser35.City = "Blacksburg";
				newCustUser35.State = "VA";
				newCustUser35.ZipCode = "24060";
				newCustUser35.PhoneNumber = "3434145678";
				newCustUser35.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser35, "bunnyhop");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser35 = _db.Users.FirstOrDefault(u => u.UserName == "stjean@athome.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser35, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser35, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser36 = _db.Users.FirstOrDefault(u => u.Email == "saunders@pen.com");

			var DOB36 = new DateTime(1978, 2, 19);

			if (newCustUser36 == null)
			{
				newCustUser36 = new AppUser();
				newCustUser36.UserName = "saunders@pen.com";
				newCustUser36.Email = "saunders@pen.com";
				newCustUser36.AdvantageNumber = "5035";
				newCustUser36.FirstName = "Sarah";
				newCustUser36.LastName = "Saunders";
				newCustUser36.MiddleInitial = "J";
				newCustUser36.DOB = DOB36;
				newCustUser36.Address = "332 Avenue C";
				newCustUser36.City = "El Paso";
				newCustUser36.State = "TX";
				newCustUser36.ZipCode = "79945";
				newCustUser36.PhoneNumber = "9153497810";
				newCustUser36.RewardMiles = 8000;

				var result = await _userManager.CreateAsync(newCustUser36, "penguin12");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser36 = _db.Users.FirstOrDefault(u => u.UserName == "saunders@pen.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser36, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser36, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser37 = _db.Users.FirstOrDefault(u => u.Email == "willsheff@email.com");

			var DOB37 = new DateTime(2014, 12, 23);

			if (newCustUser37 == null)
			{
				newCustUser37 = new AppUser();
				newCustUser37.UserName = "willsheff@email.com";
				newCustUser37.Email = "willsheff@email.com";
				newCustUser37.AdvantageNumber = "5036";
				newCustUser37.FirstName = "William";
				newCustUser37.LastName = "Sewell";
				newCustUser37.MiddleInitial = "T";
				newCustUser37.DOB = DOB37;
				newCustUser37.Address = "2365 51st St.";
				newCustUser37.City = "El Paso";
				newCustUser37.State = "TX";
				newCustUser37.ZipCode = "79946";
				newCustUser37.PhoneNumber = "9154510084";
				newCustUser37.RewardMiles = 8000;

				var result = await _userManager.CreateAsync(newCustUser37, "alaskaboy");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser37 = _db.Users.FirstOrDefault(u => u.UserName == "willsheff@email.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser37, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser37, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser38 = _db.Users.FirstOrDefault(u => u.Email == "sheffiled@gogle.com");

			var DOB38 = new DateTime(1960, 5, 8);

			if (newCustUser38 == null)
			{
				newCustUser38 = new AppUser();
				newCustUser38.UserName = "sheffiled@gogle.com";
				newCustUser38.Email = "sheffiled@gogle.com";
				newCustUser38.AdvantageNumber = "5037";
				newCustUser38.FirstName = "Martin";
				newCustUser38.LastName = "Sheffield";
				newCustUser38.MiddleInitial = "J";
				newCustUser38.DOB = DOB38;
				newCustUser38.Address = "3886 Avenue A";
				newCustUser38.City = "El Paso";
				newCustUser38.State = "TX";
				newCustUser38.ZipCode = "79950";
				newCustUser38.PhoneNumber = "9155479167";
				newCustUser38.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser38, "martin1234");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser38 = _db.Users.FirstOrDefault(u => u.UserName == "sheffiled@gogle.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser38, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser38, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser39 = _db.Users.FirstOrDefault(u => u.Email == "johnsmith187@aoll.com");

			var DOB39 = new DateTime(1955, 6, 25);

			if (newCustUser39 == null)
			{
				newCustUser39 = new AppUser();
				newCustUser39.UserName = "johnsmith187@aoll.com";
				newCustUser39.Email = "johnsmith187@aoll.com";
				newCustUser39.AdvantageNumber = "5038";
				newCustUser39.FirstName = "John";
				newCustUser39.LastName = "Smith";
				newCustUser39.MiddleInitial = "A";
				newCustUser39.DOB = DOB39;
				newCustUser39.Address = "23 Hidden Forge Dr.";
				newCustUser39.City = "Fayetteville";
				newCustUser39.State = "NC";
				newCustUser39.ZipCode = "28304";
				newCustUser39.PhoneNumber = "2838321888";
				newCustUser39.RewardMiles = 3000;

				var result = await _userManager.CreateAsync(newCustUser39, "smitty444");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser39 = _db.Users.FirstOrDefault(u => u.UserName == "johnsmith187@aoll.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser39, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser39, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser40 = _db.Users.FirstOrDefault(u => u.Email == "dustroud@mail.com");

			var DOB40 = new DateTime(1967, 7, 26);

			if (newCustUser40 == null)
			{
				newCustUser40 = new AppUser();
				newCustUser40.UserName = "dustroud@mail.com";
				newCustUser40.Email = "dustroud@mail.com";
				newCustUser40.AdvantageNumber = "5039";
				newCustUser40.FirstName = "Dustin";
				newCustUser40.LastName = "Stroud";
				newCustUser40.MiddleInitial = "P";
				newCustUser40.DOB = DOB40;
				newCustUser40.Address = "1212 Rita Rd";
				newCustUser40.City = "Springfield";
				newCustUser40.State = "IL";
				newCustUser40.ZipCode = "62707";
				newCustUser40.PhoneNumber = "2172346667";
				newCustUser40.RewardMiles = 6000;

				var result = await _userManager.CreateAsync(newCustUser40, "dustydusty");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser40 = _db.Users.FirstOrDefault(u => u.UserName == "dustroud@mail.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser40, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser40, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser41 = _db.Users.FirstOrDefault(u => u.Email == "estuart@mail.net");

			var DOB41 = new DateTime(1947, 12, 4);

			if (newCustUser41 == null)
			{
				newCustUser41 = new AppUser();
				newCustUser41.UserName = "estuart@mail.net";
				newCustUser41.Email = "estuart@mail.net";
				newCustUser41.AdvantageNumber = "5040";
				newCustUser41.FirstName = "Eric";
				newCustUser41.LastName = "Stuart";
				newCustUser41.MiddleInitial = "D";
				newCustUser41.DOB = DOB41;
				newCustUser41.Address = "5576 Toro Ring";
				newCustUser41.City = "Austin";
				newCustUser41.State = "TX";
				newCustUser41.ZipCode = "78720";
				newCustUser41.PhoneNumber = "5128178335";
				newCustUser41.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser41, "stewball");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser41 = _db.Users.FirstOrDefault(u => u.UserName == "estuart@mail.net");
			}
			if (await _userManager.IsInRoleAsync(newCustUser41, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser41, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser42 = _db.Users.FirstOrDefault(u => u.Email == "peterstump@noclue.com");

			var DOB42 = new DateTime(1974, 7, 10);

			if (newCustUser42 == null)
			{
				newCustUser42 = new AppUser();
				newCustUser42.UserName = "peterstump@noclue.com";
				newCustUser42.Email = "peterstump@noclue.com";
				newCustUser42.AdvantageNumber = "5041";
				newCustUser42.FirstName = "Peter";
				newCustUser42.LastName = "Stump";
				newCustUser42.MiddleInitial = "L";
				newCustUser42.DOB = DOB42;
				newCustUser42.Address = "1300 Kellen Circle";
				newCustUser42.City = "Austin";
				newCustUser42.State = "TX";
				newCustUser42.ZipCode = "78721";
				newCustUser42.PhoneNumber = "5124560903";
				newCustUser42.RewardMiles = 2000;

				var result = await _userManager.CreateAsync(newCustUser42, "slowwind");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser42 = _db.Users.FirstOrDefault(u => u.UserName == "peterstump@noclue.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser42, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser42, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser43 = _db.Users.FirstOrDefault(u => u.Email == "jtanner@mustang.net");

			var DOB43 = new DateTime(1944, 1, 11);

			if (newCustUser43 == null)
			{
				newCustUser43 = new AppUser();
				newCustUser43.UserName = "jtanner@mustang.net";
				newCustUser43.Email = "jtanner@mustang.net";
				newCustUser43.AdvantageNumber = "5042";
				newCustUser43.FirstName = "Jeremy";
				newCustUser43.LastName = "Tanner";
				newCustUser43.MiddleInitial = "S";
				newCustUser43.DOB = DOB43;
				newCustUser43.Address = "4347 Almstead";
				newCustUser43.City = "Austin";
				newCustUser43.State = "TX";
				newCustUser43.ZipCode = "78735";
				newCustUser43.PhoneNumber = "5124590929";
				newCustUser43.RewardMiles = 5000;

				var result = await _userManager.CreateAsync(newCustUser43, "tanner5454");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser43 = _db.Users.FirstOrDefault(u => u.UserName == "jtanner@mustang.net");
			}
			if (await _userManager.IsInRoleAsync(newCustUser43, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser43, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser44 = _db.Users.FirstOrDefault(u => u.Email == "taylordjay@aoll.com");

			var DOB44 = new DateTime(1990, 11, 14);

			if (newCustUser44 == null)
			{
				newCustUser44 = new AppUser();
				newCustUser44.UserName = "taylordjay@aoll.com";
				newCustUser44.Email = "taylordjay@aoll.com";
				newCustUser44.AdvantageNumber = "5043";
				newCustUser44.FirstName = "Allison";
				newCustUser44.LastName = "Taylor";
				newCustUser44.MiddleInitial = "R";
				newCustUser44.DOB = DOB44;
				newCustUser44.Address = "467 Nueces St.";
				newCustUser44.City = "Austin";
				newCustUser44.State = "TX";
				newCustUser44.ZipCode = "78710";
				newCustUser44.PhoneNumber = "5124748452";
				newCustUser44.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser44, "allyrally");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser44 = _db.Users.FirstOrDefault(u => u.UserName == "taylordjay@aoll.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser44, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser44, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser45 = _db.Users.FirstOrDefault(u => u.Email == "rtaylor@gogle.com");

			var DOB45 = new DateTime(1976, 1, 18);

			if (newCustUser45 == null)
			{
				newCustUser45 = new AppUser();
				newCustUser45.UserName = "rtaylor@gogle.com";
				newCustUser45.Email = "rtaylor@gogle.com";
				newCustUser45.AdvantageNumber = "5044";
				newCustUser45.FirstName = "Rachel";
				newCustUser45.LastName = "Taylor";
				newCustUser45.MiddleInitial = "K";
				newCustUser45.DOB = DOB45;
				newCustUser45.Address = "345 Longview Dr.";
				newCustUser45.City = "Dallas";
				newCustUser45.State = "TX";
				newCustUser45.ZipCode = "75001";
				newCustUser45.PhoneNumber = "4694907631";
				newCustUser45.RewardMiles = 10000;

				var result = await _userManager.CreateAsync(newCustUser45, "taylorbaylor");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser45 = _db.Users.FirstOrDefault(u => u.UserName == "rtaylor@gogle.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser45, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser45, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser46 = _db.Users.FirstOrDefault(u => u.Email == "teefrank@noclue.com");

			var DOB46 = new DateTime(1998, 9, 6);

			if (newCustUser46 == null)
			{
				newCustUser46 = new AppUser();
				newCustUser46.UserName = "teefrank@noclue.com";
				newCustUser46.Email = "teefrank@noclue.com";
				newCustUser46.AdvantageNumber = "5045";
				newCustUser46.FirstName = "Frank";
				newCustUser46.LastName = "Tee";
				newCustUser46.MiddleInitial = "J";
				newCustUser46.DOB = DOB46;
				newCustUser46.Address = "5590 Lavell Dr";
				newCustUser46.City = "Dallas";
				newCustUser46.State = "TX";
				newCustUser46.ZipCode = "75063";
				newCustUser46.PhoneNumber = "4698765543";
				newCustUser46.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser46, "teeoff22");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser46 = _db.Users.FirstOrDefault(u => u.UserName == "teefrank@noclue.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser46, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser46, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser47 = _db.Users.FirstOrDefault(u => u.Email == "ctucker@alphabet.co.uk");

			var DOB47 = new DateTime(1943, 2, 25);

			if (newCustUser47 == null)
			{
				newCustUser47 = new AppUser();
				newCustUser47.UserName = "ctucker@alphabet.co.uk";
				newCustUser47.Email = "ctucker@alphabet.co.uk";
				newCustUser47.AdvantageNumber = "5046";
				newCustUser47.FirstName = "Clent";
				newCustUser47.LastName = "Tucker";
				newCustUser47.MiddleInitial = "J";
				newCustUser47.DOB = DOB47;
				newCustUser47.Address = "312 Main St.";
				newCustUser47.City = "Dallas";
				newCustUser47.State = "TX";
				newCustUser47.ZipCode = "75206";
				newCustUser47.PhoneNumber = "4698471154";
				newCustUser47.RewardMiles = 7000;

				var result = await _userManager.CreateAsync(newCustUser47, "tucksack1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser47 = _db.Users.FirstOrDefault(u => u.UserName == "ctucker@alphabet.co.uk");
			}
			if (await _userManager.IsInRoleAsync(newCustUser47, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser47, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser48 = _db.Users.FirstOrDefault(u => u.Email == "avelasco@yoho.com");

			var DOB48 = new DateTime(1985, 9, 10);

			if (newCustUser48 == null)
			{
				newCustUser48 = new AppUser();
				newCustUser48.UserName = "avelasco@yoho.com";
				newCustUser48.Email = "avelasco@yoho.com";
				newCustUser48.AdvantageNumber = "5047";
				newCustUser48.FirstName = "Allen";
				newCustUser48.LastName = "Velasco";
				newCustUser48.MiddleInitial = "G";
				newCustUser48.DOB = DOB48;
				newCustUser48.Address = "679 W. 4th";
				newCustUser48.City = "Dallas";
				newCustUser48.State = "TX";
				newCustUser48.ZipCode = "75215";
				newCustUser48.PhoneNumber = "4693985638";
				newCustUser48.RewardMiles = 8000;

				var result = await _userManager.CreateAsync(newCustUser48, "meow88");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser48 = _db.Users.FirstOrDefault(u => u.UserName == "avelasco@yoho.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser48, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser48, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser49 = _db.Users.FirstOrDefault(u => u.Email == "vinovino@grapes.com");

			var DOB49 = new DateTime(1985, 2, 7);

			if (newCustUser49 == null)
			{
				newCustUser49 = new AppUser();
				newCustUser49.UserName = "vinovino@grapes.com";
				newCustUser49.Email = "vinovino@grapes.com";
				newCustUser49.AdvantageNumber = "5048";
				newCustUser49.FirstName = "Janet";
				newCustUser49.LastName = "Vino";
				newCustUser49.MiddleInitial = "E";
				newCustUser49.DOB = DOB49;
				newCustUser49.Address = "189 Grape Road";
				newCustUser49.City = "Houston";
				newCustUser49.State = "TX";
				newCustUser49.ZipCode = "77010";
				newCustUser49.PhoneNumber = "2815643832";
				newCustUser49.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser49, "vinovino");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser49 = _db.Users.FirstOrDefault(u => u.UserName == "vinovino@grapes.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser49, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser49, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser50 = _db.Users.FirstOrDefault(u => u.Email == "westj@pioneer.net");

			var DOB50 = new DateTime(1976, 1, 9);

			if (newCustUser50 == null)
			{
				newCustUser50 = new AppUser();
				newCustUser50.UserName = "westj@pioneer.net";
				newCustUser50.Email = "westj@pioneer.net";
				newCustUser50.AdvantageNumber = "5049";
				newCustUser50.FirstName = "Jake";
				newCustUser50.LastName = "West";
				newCustUser50.MiddleInitial = "T";
				newCustUser50.DOB = DOB50;
				newCustUser50.Address = "RR 3287";
				newCustUser50.City = "Houston";
				newCustUser50.State = "TX";
				newCustUser50.ZipCode = "77025";
				newCustUser50.PhoneNumber = "2818475244";
				newCustUser50.RewardMiles = 8000;

				var result = await _userManager.CreateAsync(newCustUser50, "gowest");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser50 = _db.Users.FirstOrDefault(u => u.UserName == "westj@pioneer.net");
			}
			if (await _userManager.IsInRoleAsync(newCustUser50, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser50, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser51 = _db.Users.FirstOrDefault(u => u.Email == "winner@hootmail.com");

			var DOB51 = new DateTime(1953, 4, 19);

			if (newCustUser51 == null)
			{
				newCustUser51 = new AppUser();
				newCustUser51.UserName = "winner@hootmail.com";
				newCustUser51.Email = "winner@hootmail.com";
				newCustUser51.AdvantageNumber = "5050";
				newCustUser51.FirstName = "Louis";
				newCustUser51.LastName = "Winthorpe";
				newCustUser51.MiddleInitial = "L";
				newCustUser51.DOB = DOB51;
				newCustUser51.Address = "2500 Padre Blvd";
				newCustUser51.City = "Houston";
				newCustUser51.State = "TX";
				newCustUser51.ZipCode = "77010";
				newCustUser51.PhoneNumber = "2815650098";
				newCustUser51.RewardMiles = 6000;

				var result = await _userManager.CreateAsync(newCustUser51, "louielouie");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser51 = _db.Users.FirstOrDefault(u => u.UserName == "winner@hootmail.com");
			}
			if (await _userManager.IsInRoleAsync(newCustUser51, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser51, "Customer");
			}
			_db.SaveChanges();


			AppUser newCustUser52 = _db.Users.FirstOrDefault(u => u.Email == "rwood@voyager.net");

			var DOB52 = new DateTime(2002, 12, 28);

			if (newCustUser52 == null)
			{
				newCustUser52 = new AppUser();
				newCustUser52.UserName = "rwood@voyager.net";
				newCustUser52.Email = "rwood@voyager.net";
				newCustUser52.AdvantageNumber = "5051";
				newCustUser52.FirstName = "Reagan";
				newCustUser52.LastName = "Wood";
				newCustUser52.MiddleInitial = "B";
				newCustUser52.DOB = DOB52;
				newCustUser52.Address = "447 Westlake Dr.";
				newCustUser52.City = "Houston";
				newCustUser52.State = "TX";
				newCustUser52.ZipCode = "77010";
				newCustUser52.PhoneNumber = "2814545242";
				newCustUser52.RewardMiles = 0;

				var result = await _userManager.CreateAsync(newCustUser52, "woodyman1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}
				_db.SaveChanges();
				newCustUser52 = _db.Users.FirstOrDefault(u => u.UserName == "rwood@voyager.net");
			}
			if (await _userManager.IsInRoleAsync(newCustUser52, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newCustUser52, "Customer");
			}
			_db.SaveChanges();

		}
	}
}


