using System;
using System.ComponentModel.DataAnnotations;

namespace Lam_Kevin_HW6.Models
{
    public class OrderDetail
    {
        [Display(Name = "Order Detail ID")]
        public Int32 OrderDetailID { get; set; }

        [Required(ErrorMessage = "You must specify a number of products to purchase")]
        [Display(Name = "Quantity of Items to Buy")]
        [Range(1, 1000)]
        public Int32 ProductQuantity { get; set; }

        [Display(Name = "Product Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ProductPrice { get; set; }

        [Display(Name = "Extended Product Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ExtendedProductPrice { get; set; }


        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}