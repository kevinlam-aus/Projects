using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace Lam_Kevin_HW6.Models
{
    public class Order
    {
        [Display(Name = "Order ID")]
        public Int32 OrderID { get; set; }

        [Display(Name = "Order Number")]
        public Int32 OrderNumber { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Order Notes")]
        public String OrderNotes { get; set; }

        private const Decimal TAX_RATE = 0.0825m;


        public List<OrderDetail> OrderDetails { get; set; }
        public AppUser AppUser { get; set; }


        [Display(Name = "Order Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal OrderSubtotal
        {
            get { return OrderDetails.Sum(od => od.ExtendedProductPrice); }
        }

        [Display(Name = "Sales Tax (8.25%")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesTax
        {
            get { return OrderSubtotal * TAX_RATE; }
        }

        [Display(Name = "Order Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal OrderTotal
        {
            get { return OrderSubtotal + SalesTax; }
        }

        public Order()
        {
            if (OrderDetails == null)
            {
                OrderDetails = new List<OrderDetail>();
            }
        }
    }
}