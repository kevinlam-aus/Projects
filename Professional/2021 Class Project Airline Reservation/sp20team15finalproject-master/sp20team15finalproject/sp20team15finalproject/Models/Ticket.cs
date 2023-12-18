using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//This role stores information on tickets 


public enum Seats { Pilot, CoPilot, Attendant, OneA, OneB, TwoA, TwoB, ThreeA, ThreeB, ThreeC, ThreeD, FourA, FourB, FourC, FourD, FiveA, FiveB, FiveC, FiveD }

public enum SeatStatus { Checked_In, Not_Checked_In, Canceled }

namespace sp20team15finalproject.Models
{
    public class Ticket
    {
        //TODO: any fields required? if so add error
        
        [Display(Name = "Ticket ID")]
        public Int32 TicketID { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Price { get; set; }

        public SeatStatus seatStatus { get; set; }

        public Seats Seat { get; set; }

        [Display(Name = "Customer with this ticket")]
        public AppUser Name { get; set; }

        public FlightDetail Flightdetail { get; set; }

        public Reservation Reservation { get; set; }

    }
}
