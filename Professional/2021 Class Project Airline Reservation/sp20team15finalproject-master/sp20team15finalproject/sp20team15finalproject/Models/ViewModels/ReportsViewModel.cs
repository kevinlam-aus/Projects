using sp20team15finalproject.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sp20team15finalproject.Models.ViewModels
{
    public class ReportsViewModel
    {
        private const Int32 SEATS = 16; //total seats you can have on a single flight 

        [Display(Name = "Specify the report type")]
        [Required(ErrorMessage = "You must select a report type")]
        public ReportType ReportType { get; set; }

        
        [Display(Name = "Search for flights after:")]
        [DataType(DataType.Date)]
        public DateTime DateOne { get; set; } //search after this date

        [Display(Name = "Search for flights before:")] //search before this date
        [DataType(DataType.Date)]
        public DateTime DateTwo { get; set; } 

        [Display(Name = "Limit based on departing city")] //limit based on departing city
        public Int32 DepSearchID  { get; set; }

        [Display(Name = "Limit based on arriving city")] //limit based on arriving city 
        public Int32 ArrSearchID { get; set; }

        [Display(Name = "Limit based on seat class")]
        [Required(ErrorMessage = "You must select a class")]
        public ClassSearch ClassSearch { get; set; }

        public List<Ticket> tickets { get; set; }

        public List<FlightDetail> flightdetails { get; set; }

    }


}
