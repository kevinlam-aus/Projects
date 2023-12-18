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

    public class CustomerSearchViewModel
    {
      

        [Display(Name = "First Name of the Customer:")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name of the Customer:")]
        public String LastName { get; set; }

        [Display(Name = "AdvantageNumber of the Customer:")]
        public String advantageNumber { get; set; }


    }
}
