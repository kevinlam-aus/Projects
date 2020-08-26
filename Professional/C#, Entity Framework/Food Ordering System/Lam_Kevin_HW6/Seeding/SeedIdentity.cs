using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

using Lam_Kevin_HW6.DAL;
using Lam_Kevin_HW6.Models;

namespace Lam_Kevin_HW6.Seeding
{
    //add identity data
    public static class SeedIdentity
    {
        public static async Task AddAdmin(IServiceProvider serviceProvider)
        {
            AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
            UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //if role doesn't exist, add it
            if (await _roleManager.RoleExistsAsync("Admin") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (await _roleManager.RoleExistsAsync("Customer") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            //check to see if the admin has been added
            AppUser newUser = _db.Users.FirstOrDefault(u => u.Email == "admin@example.com");

            //if admin hasn't been created, then add them
           
            if (newUser == null)
            {
                newUser = new AppUser();
                newUser.UserName = "admin@example.com";
                newUser.Email = "admin@example.com";
                newUser.FirstName = "Admin";
                newUser.LastName = "istrator";

                //NOTE: This creates the user - "Abc123!" is the password for this user
                var result = await _userManager.CreateAsync(newUser, "Abc123!");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                newUser = _db.Users.FirstOrDefault(u => u.UserName == "admin@example.com");
            }

            //Add the new user we just created to the Admin role
            if (await _userManager.IsInRoleAsync(newUser, "Admin") == false)
            {
                await _userManager.AddToRoleAsync(newUser, "Admin");
            }

            //save changes
            _db.SaveChanges();
        }

    }
}