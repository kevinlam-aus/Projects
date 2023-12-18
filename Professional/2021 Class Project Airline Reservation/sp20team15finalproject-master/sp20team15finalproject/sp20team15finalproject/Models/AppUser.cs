using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


//Namespace for our models.
namespace sp20team15finalproject.Models
{

    //make sure our appuser inherits from our identity user class so we can gain all that functionality.
    public class AppUser : IdentityUser
    {
        // GET: /<controller>/
        //ID is already stored by identityuser.
        //Email is already stored by identityuser.


        [Display(Name = "Customer Advantage Number")]
        [Range(5000, 9999999999999)]
        public String AdvantageNumber { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is Required")]
        public String LastName { get; set; }

        [Display(Name = "Middle Initial")]
        [MinLength(1)]
        [MaxLength(1)]
        public String MiddleInitial { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DOB { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public String Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is Required")]
        public String City { get; set; }

        [Display(Name = "State")]
        [MinLength(2)]
        [MaxLength(2)]
        [Required(ErrorMessage = "State is Required")]
        public String State { get; set; }


        [Display(Name = "Zip Code")]
        [MinLength(5)]
        [MaxLength(5)]
        [Required(ErrorMessage = "Zip Code is Required")]
        public String ZipCode { get; set; }

        //The phone number is inherited from identity user.

        [Display(Name = "Reward Miles")]
        public Int32 RewardMiles { get; set; }


        //The Reservation(s) that the user has.
        [Display(Name = "Reservations this User has made")]
        public List<Reservation> Reservations { get; set; }

        [Display(Name = "Tickets for this User")]
        public List<Ticket> Tickets { get; set; }


    }
}
