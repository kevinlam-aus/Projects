using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sp20team15finalproject.Models.ViewModels
{

    public class UserListViewModel
    {
        [Display(Name = "Users:")]
        public List<AppUser> Users { get; set; }

        [Display(Name = "Please enter the email of the user you wish to add to this flight:")]
        public String UserEmail { get; set; }
    }
}
