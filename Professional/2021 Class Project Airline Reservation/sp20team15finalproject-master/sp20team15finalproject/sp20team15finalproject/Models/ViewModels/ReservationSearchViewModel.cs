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

    public class ReservationSearchViewModel
    {

        public string customeremail { get; set; }

        [Display(Name = "Trip Type:")]
        public enumTripType TripType { get; set; }

        [Display(Name = "How Many Passengers:")]
        [Range(minimum: 1, maximum: 16, ErrorMessage = "Number of passengers must be between 1 and 16")]
        [Required(ErrorMessage ="You Must Specify the amount of passengers you want to book for. Number must be between 1 and 16")]
        public Int32 NumberOfPassengers { get; set; }

        [Display(Name = "Choose your Departing City:")]
        [Required(ErrorMessage = "You Must Select a Departing City")]
        public Int32 departingCityID { get; set; }

        [Display(Name = "Choose your Arrival City:")]
        [Required(ErrorMessage = "You Must Select an Arrival City")]
        public Int32 arrivalCityID { get; set; }

        [Display(Name = "Enter the date you want to leave on:")]
        [Required(ErrorMessage = "You Must Select an earliest Departure Date")]
        [DataType(DataType.Date)]
        public DateTime departureDate { get; set; }

        [Display(Name = "Enter the date you want to get back on:")]
        [DataType(DataType.Date)]
        public DateTime arrivalDate{ get; set; }
        

    }
}
