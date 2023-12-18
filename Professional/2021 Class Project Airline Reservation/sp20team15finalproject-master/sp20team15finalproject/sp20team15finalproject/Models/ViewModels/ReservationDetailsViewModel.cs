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

    public class ReservationDetailsViewModel
    {
        [Display(Name = "List of Tickets:")]
        public List<Ticket> Tickets { get; set; }

        [Display(Name = "Please enter the email of the pilot you wish to add to this flight:")]
        public Reservation reservation { get; set; }

        
    }
}
