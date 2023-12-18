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

    public class CheckoutViewModel
    {
        [Display(Name = "Tickets:")]
        public List<Ticket> Tickets { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Subtotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Theft { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Total { get; set; }


        public Int32 ReservationID { get; set; }

        public Int32 MileageCost { get; set; }

        public AppUser user { get; set; }

    }
}
