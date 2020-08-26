using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lam_Kevin_HW6.Models
{
    public class Supplier
    {
        [Display(Name = "Supplier ID")]
        public Int32 SupplierID { get; set; }

        [Display(Name = "Supplier Name")]
        public String SupplierName { get; set; }

        [Display(Name = "Supplier Email")]
        public virtual string SupplierEmail { get; set; }

        [Display(Name = "Supplier Phone Number")]
        public virtual string SupplierPhoneNumber { get; set; }



        public List<ProductSupplier> ProductSuppliers { get; set; }

        public Supplier()
        {
            if (ProductSuppliers == null)
            {
                ProductSuppliers = new List<ProductSupplier>();
            }
        }
    }
}
