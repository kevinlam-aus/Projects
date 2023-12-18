using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


using sp20team15finalproject.DAL;
using sp20team15finalproject.Models;
using sp20team15finalproject.Models.ViewModels;
using System.Linq;
using System;

namespace sp20team15finalproject.Controllers
{
    //TODO: Uncomment this line once you have roles working correctly
    [Authorize(Roles = "Admin, Manager, Agent")]
    public class RoleAdminController : Controller
    {
        private readonly AppDbContext _db;
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public RoleAdminController(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        // GET: /RoleAdmin/
        public async Task<ActionResult> Index()
        {
            List<RoleEditModel> roles = new List<RoleEditModel>();
            
            foreach (IdentityRole role in _roleManager.Roles)
            {
                List<AppUser> members = new List<AppUser>();
                List<AppUser> nonMembers = new List<AppUser>();
                foreach (AppUser user in _userManager.Users)
                {
                    var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                    list.Add(user);
                }
                RoleEditModel re = new RoleEditModel();
                re.Role = role;
                re.Members = members;
                re.NonMembers = nonMembers;
                roles.Add(re);
            }
            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }

            //if code gets this far, we need to show an error
            return View(name);
        }

        public async Task<ActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<AppUser> members = new List<AppUser>();
            List<AppUser> nonMembers = new List<AppUser>();
            foreach (AppUser user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEditModel { Role = role, Members = members, NonMembers = nonMembers });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleModificationModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsToAdd ?? new string[] { })
                {
                    AppUser user = await _userManager.FindByIdAsync(userId);
                    result = await _userManager.AddToRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }

                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    AppUser user = await _userManager.FindByIdAsync(userId);
                    result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error", new string[] { "Role Not Found" });
        }




        private void AddErrorsFromResult(IdentityResult result)
        { 
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }


        public ActionResult UserList()
        {



            List<AppUser> userstopass = _db.Users.ToList();


            UserListViewModel ulvm = new UserListViewModel();

            ulvm.Users = userstopass;


            return View("UserList", ulvm);
        }

        public async Task<IActionResult> EditInfo(UserListViewModel ulvm)
        {

            AppUser user = await _userManager.FindByNameAsync(ulvm.UserEmail);


            AccountChangeViewModel acvm = new AccountChangeViewModel();

            acvm.persontochange = user;
            acvm.newEmail = ulvm.UserEmail;


            return View("EditUser", acvm);
        }

        public async Task<IActionResult> UpdateUser(AccountChangeViewModel viewmodel)
        {

            AppUser user = await _userManager.FindByNameAsync(viewmodel.newEmail);


            
            if(viewmodel.newEmail != null)
            {
                user.Email = viewmodel.newEmail;
            }


            if (viewmodel.newFirstName != null)
            {
                user.FirstName = viewmodel.newFirstName;
            }

            if (viewmodel.newMiddleInitial != null)
            {
                user.MiddleInitial = viewmodel.newMiddleInitial;
            }

            if (viewmodel.newLastName != null)
            {
                user.MiddleInitial = viewmodel.newMiddleInitial;
            }

            DateTime voiddate = new DateTime(0001, 1, 1);

            if (viewmodel.newDOB != voiddate)
            {
                user.DOB = viewmodel.newDOB;
            }

            if (viewmodel.newAddress != null)
            {
                user.Address = viewmodel.newAddress;
            }

            if (viewmodel.newCity != null)
            {
                user.City = viewmodel.newCity;
            }

            if (viewmodel.newState != null)
            {
                user.State = viewmodel.newState;
            }

            if (viewmodel.newZip != null)
            {
                user.ZipCode = viewmodel.newZip;
            }

            

            if (viewmodel.newPhoneNumber != null)
            {
                user.PhoneNumber = viewmodel.newPhoneNumber;
            }

            if (viewmodel.newRewardMiles != 0)
            {
                user.RewardMiles = viewmodel.newRewardMiles;
            }

            _db.SaveChanges();
   


            return RedirectToAction("Index");
        }
    }
}