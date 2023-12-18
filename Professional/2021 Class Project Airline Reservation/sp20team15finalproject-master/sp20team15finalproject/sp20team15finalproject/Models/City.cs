using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//This model stores the reservations that users have made on the site.

namespace sp20team15finalproject.Models
{
    public class City
    {
        [Display(Name = "City ID")]
        public Int32 CityID { get; set; }

        [Display(Name = "City Number")]
        public Int32 CityNumber { get; set; }

        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City Name is Required")]
        public String CityName { get; set; }

        [Display(Name = "Airport Code")]
        [Required(ErrorMessage = "Airport Code is Required")]
        public string AirportCode { get; set; }

        [InverseProperty("DepartingCity")]
        public List<Flight> DepFlights { get; set; }

        [InverseProperty("ArrivingCity")]
        public List<Flight> ArrFlights { get; set; }

    }
}
