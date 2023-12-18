using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sp20team15finalproject.Models.ViewModels
{

    public class SeatReSelectionViewModel
    {
        [Display(Name = "Select a Seat:")]
        public Seats SelectedSeat { get; set; }

        [Display(Name = "Ticket ID:")]
        public Int32 TicketID { get; set; }

    }
}
