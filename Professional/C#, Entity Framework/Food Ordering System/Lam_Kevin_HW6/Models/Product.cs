using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Lam_Kevin_HW6.Models
{
    public class Product
    {
        [Display(Name = "Product ID")]
        public Int32 ProductID { get; set; }

        [Display(Name = "Product Name")]
        public String ProductName { get; set; }

        [Display(Name = "Product Description")]
        public String ProductDescription { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        [Display(Name = "Product Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ProductPrice { get; set; }


        public List<ProductSupplier> ProductSuppliers { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public Product()
        {
            if (ProductSuppliers == null)
            {
                ProductSuppliers = new List<ProductSupplier>();
            }

            if (OrderDetails == null)
            {
                OrderDetails = new List<OrderDetail>();
            }
        }
    }
}

