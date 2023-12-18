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

    public class ManagerReservationViewModel
    {
        [Display(Name = "Customers:")]
        public List<AppUser> Customers { get; set; }

        [Display(Name = "Customer Email:")]
        public String CustEmail { get; set; }

    }
}