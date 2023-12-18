using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

//This model stores the reservations that users have made on the site.

namespace sp20team15finalproject.Models
{
    public class Reservation
    {
        [Display(Name = "Reservation ID")]
        public Int32 ReservationID { get; set; }

        [Display(Name = "Reservation Number")]
        public Int32 ReservationNumber { get; set; }

        [Display(Name = "Reservation Date")]
        public DateTime ReservationDate { get; set; }

        //We Want a Radio Button so we will enumerate
        [Display(Name = "Payment Method")]
        public Int32 PaymentMethod { get; set; }

        [Display(Name = "User that made this Reservation")]
        public AppUser User { get; set; }

        [Display(Name = "Reserved")]
        public List<Ticket> Tickets { get; set; }

        [Display(Name = "Total Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Subtotal { get; set; }

        [Display(Name = "Total Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Tax { get; set; }

        [Display(Name = "Total Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalPrice { get; set; }
    }
}
