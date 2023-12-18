using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace sp20team15finalproject.Models.ViewModels
{

    public enum enumTripType { round_trip, one_way };
    public class FlightTripTypeSearchViewModel
    {

        [Display(Name = "Search Movie Title:")]
        public enumTripType SearchTripType { get; set; }

        public string customeremail { get; set; }
    }   
}
