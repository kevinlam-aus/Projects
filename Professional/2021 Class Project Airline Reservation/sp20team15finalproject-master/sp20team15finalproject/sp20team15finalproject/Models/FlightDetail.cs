using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//stores flight details 

public enum Status { Departed, Not_Departed, Deactivated }

namespace sp20team15finalproject.Models
{
    public class FlightDetail
    {
        public Int32 FlightDetailID { get; set; }

        [Display(Name = "Date and Time Departing")]
        public DateTime Date { get; set; }

        [Display(Name = "Status")]
        public Status FlightStatus { get; set; }

        [Display(Name = "People on this flight")]
        public List<Ticket> Tickets { get; set; }

        [Display(Name = "FlightInformation")]
        public Flight Flight { get; set; }

    }
}