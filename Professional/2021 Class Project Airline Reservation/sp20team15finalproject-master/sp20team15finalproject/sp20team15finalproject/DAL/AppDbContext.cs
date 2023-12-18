using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


using sp20team15finalproject.Models;


namespace sp20team15finalproject.DAL
{
    //NOTE: This class definition references the user class for this project.  
    //If your User class is called something other than AppUser, you will need
    //to change it in the line below
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        //TODO: Add Dbsets here.  Products is included as an example.  

        //PLEASE REMEMBER THAT IDENTITY PROVIDES A DBSET FOR APPUSER
        //This DbSet is called Users.
        //If you add a second dbSet for AppUsers, YOU WILL GET ERRORS


           //Here are all of the DB Sets for our models. As we add more models, add DBSets here and then run another migration.
        public DbSet<City> Cities { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<FlightDetail> FlightDetails { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        //Note: I named this a bit differently so we don't accidentally override the "roles" from identity (admin, user, etc.)

        public DbSet<Ticket> Tickets { get; set; }

        //public DbSet<RouteInfo> RouteInformation { get; set; }




    }
}
