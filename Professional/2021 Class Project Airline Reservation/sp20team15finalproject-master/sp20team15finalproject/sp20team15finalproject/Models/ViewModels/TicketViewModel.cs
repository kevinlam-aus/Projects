using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

//This is a simplified view model of the reservationselectionviewmodel. This way, we can start generating tickets super easily and selecting seats,
//It allows us to keep ONLY the things we need to generate the tickets on a specific reservationID. That way, we can make our code
//a lot easier to understand with this one small viewmodel.

namespace sp20team15finalproject.Models.ViewModels
{
    public class TicketViewModel
    {


        [Display(Name = "Departing Flight ID:")]
        [Required(ErrorMessage = "You Must Select a Departing Flight")]
        public Int32 departureFlightDetailID { get; set; }

        [Display(Name = "Reservation ID:")]
        public Int32 ReservationID { get; set; }


        [Display(Name = "Arriving Flight ID:")]
        public Int32 arrivingFlightDetailID { get; set; }


        [Display(Name = "Trip Type:")]
        public enumTripType TripType { get; set; }

        [Display(Name = "How Many Passengers:")]
        [Range(minimum: 1, maximum: 16, ErrorMessage = "Number of passengers must be between 1 and 16")]
        [Required(ErrorMessage = "You Must Specify the amount of passengers you want to book for. Number must be between 1 and 16")]
        public Int32 NumberOfPassengers { get; set; }

        public String CustomerEmail { get; set; }

        //We are going to need these for them to select what seat they want.

        public List<Seats> availableDepartureSeats { get; set; }

        public List<Seats> availableArrivalSeats { get; set; }
        
        public Seats selectedDepartureSeat { get; set; }

        public Seats selectedReturnSeat { get; set; }

        public AppUser personOnTicket { get; set; }

        public List<AppUser> allUsers { get; set; }

        public List<AppUser> Customers { get; set; }


    }
}