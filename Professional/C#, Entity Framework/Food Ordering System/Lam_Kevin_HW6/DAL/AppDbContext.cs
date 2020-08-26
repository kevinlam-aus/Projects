using System;
using Microsoft.EntityFrameworkCore;


using Lam_Kevin_HW6.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Lam_Kevin_HW6.DAL
{
    //NOTE: This class definition references the user class for this project.  
    //If your User class is called something other than AppUser, you will need
    //to change it in the line below
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
