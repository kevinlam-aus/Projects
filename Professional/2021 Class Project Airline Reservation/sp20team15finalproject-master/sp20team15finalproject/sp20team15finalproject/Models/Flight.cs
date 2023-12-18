using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//stores flight  

namespace sp20team15finalproject.Models
{
    public class Flight
    {

        [Display(Name = "Flight ID")]
        public Int32 FlightID { get; set; }

        [Display(Name = "Flight Number")]
        public Int32 FlightNumber { get; set; }

        [Display(Name = "Departing Time")]
        public String DepTime { get; set; }

        [Display(Name = "Days Flown")]
        public String Days { get; set; }

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
        public City DepartingCity { get; set; }

        [Display(Name = "Is the Flight Activated?")]
        public Boolean Deactivated { get; set; }

        [Display(Name = "Arrival City")]
        public City ArrivingCity { get; set; }

        [Display(Name = "Mileage Between the two cities")]
        public Int32 Mileage { get; set; }

        [Display(Name = "Flight Time")]
        public TimeSpan FlightTime { get; set; }

        public List<FlightDetail> FlightDetails { get; set; }

    }
}
