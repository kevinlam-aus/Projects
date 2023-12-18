using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace sp20team15finalproject.Models.ViewModels
{
    public class ReservationSelectionViewModel
    {
        public string customeremail { get; set; }

        [Display(Name = "Choose your Departing Flight:")]
        [Required(ErrorMessage = "You Must Select a Departing Flight")]
        public Int32 departureFlightDetailID { get; set; }

        public List<FlightDetail> departingFlightDetails {get;set;}

        public List<FlightDetail> arrivingFlightDetails { get; set; }

        public Int32 ReservationID { get; set; }


        [Display(Name = "Choose your Arriving Flight:")]
        public Int32 arrivingFlightDetailID { get; set; }


        [Display(Name = "Trip Type:")]
        public enumTripType TripType { get; set; }

        [Display(Name = "How Many Passengers:")]
        [Range(minimum: 1, maximum: 16, ErrorMessage = "Number of passengers must be between 1 and 16")]
        [Required(ErrorMessage = "You Must Specify the amount of passengers you want to book for. Number must be between 1 and 16")]
        public Int32 NumberOfPassengers { get; set; }

        [Display(Name = "Choose your Departing City:")]
        [Required(ErrorMessage = "You Must Select a Departing City")]
        public Int32 departingCityID { get; set; }

        [Display(Name = "Choose your Arrival City:")]
        [Required(ErrorMessage = "You Must Select an Arrival City")]
        public Int32 arrivalCityID { get; set; }

        [Display(Name = "Enter the date you want to leave on:")]
        [Required(ErrorMessage = "You Must Select an earliest Departure Date")]
        [DisplayFormat(DataFormatString = "{0:MMMM d, yyyy}")]
        public DateTime departureDate { get; set; }

        [Display(Name = "Enter the date you want to get back on:")]
        [DisplayFormat(DataFormatString = "{0:MMMM d, yyyy}")]
        public DateTime arrivalDate { get; set; }

        public List<Seats> availableDepartureSeats { get; set; }

        public List<Seats> availableArrivalSeats { get; set; }

        public Seats selectedDepartureSeat { get; set; }

        public Seats selectedReturnSeat { get; set; }

    }
}