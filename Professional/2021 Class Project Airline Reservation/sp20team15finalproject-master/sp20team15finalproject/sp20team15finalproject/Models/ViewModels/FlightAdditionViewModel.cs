using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace sp20team15finalproject.Models.ViewModels
{
    public class FlightAdditionViewModel
    {

            [Display(Name = "Departing Time")]
            public String DepTime { get; set; }

            [Display(Name = "Flies Sunday")]
            public Boolean FlySun { get; set; }

            [Display(Name = "Flies Monday")]
            public Boolean FlyMon { get; set; }

            [Display(Name = "Flies Tuesday")]
            public Boolean FlyTue { get; set; }

            [Display(Name = "Flies Wednesday")]
            public Boolean FlyWed { get; set; }

            [Display(Name = "Flies Thursday")]
            public Boolean FlyThu { get; set; }

            [Display(Name = "Flies Friday")]
            public Boolean FlyFri { get; set; }

            [Display(Name = "Flies Saturday")]
            public Boolean FlySat { get; set; }

            [Display(Name = "Base Fare")]
            [DisplayFormat(DataFormatString = "{0:C}")]
            public Int32 BaseFare { get; set; }

            [Display(Name = "Departing City")]
            public Int32 DepartingCityID { get; set; }

            [Display(Name = "Arrival City")]
            public Int32 ArrivingCityID { get; set; }

        
    }

}

