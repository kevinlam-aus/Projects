using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lam_Kevin_HW6.Models
{
    public class AppUser : IdentityUser
    {
        //Identity creates several of the important fields for you
        //First name is provided as an example
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Customer Name")]
        public String FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public List<Order> Orders { get; set; }
    }
}



