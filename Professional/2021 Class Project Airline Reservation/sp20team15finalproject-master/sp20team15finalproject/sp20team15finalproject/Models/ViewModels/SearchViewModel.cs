using sp20team15finalproject.Controllers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp20team15finalproject.Models
{

    public class SearchViewModel
    {
        [Display(Name = "RoundTrip")]
        public Boolean RoundTrip { get; set; }

        [Display(Name = "Departing City")]
        public String DepartingCity { get; set; }

        [Display(Name = "Departing Date")]
        [DataType(DataType.Date)]
        public String DepartingDate { get; set; }

        [Display(Name = "Arriving City")]
        public String ArrivingCity { get; set; }

        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public String ReturnDate { get; set; }

        [Display(Name = "Number of Fliers:")]
        public Int32 FlyerNum { get; set; }

    }
}