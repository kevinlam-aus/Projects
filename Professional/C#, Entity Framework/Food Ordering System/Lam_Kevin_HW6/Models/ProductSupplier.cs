using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lam_Kevin_HW6.Models
{
    public class ProductSupplier
    {
        [Display(Name = "Product Supplier ID")]
        public Int32 ProductSupplierID { get; set; }



        public Product Product { get; set; }
        public Supplier Supplier { get; set; }

    }
}

