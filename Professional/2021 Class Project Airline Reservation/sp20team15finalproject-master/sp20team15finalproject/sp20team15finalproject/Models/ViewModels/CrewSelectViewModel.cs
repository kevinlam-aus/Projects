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

    public class CrewSearchViewModel
    {
        [Display(Name = "Pilots:")]
        public List<AppUser> Pilots { get; set; }
        
        [Display(Name = "Please enter the email of the pilot you wish to add to this flight:")]
        public String PilotEmail { get; set; }

        public Int32 FlightDetailID { get; set; }

        public FlightDetail flightdetail { get; set; }

        public List<Ticket> tickets { get; set; }
    }
}
