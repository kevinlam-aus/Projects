using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//TODO: Once you have a database on Azure, you will need to uncomment this line 
//and make the name match your project name
using sp20team15finalproject.DAL;
using sp20team15finalproject.Models;
using Microsoft.AspNetCore.Identity;


namespace sp20team15finalproject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            String connectionString = "Server=tcp:mis333ksp20.database.windows.net,1433;Initial Catalog=MIS333kSP20-111;Persist Security Info=False;User ID=MIS333kSP20111user;Password=!333Ksp205613;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
           
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            //TODO: Uncomment these lines once you have added Identity to your project
            ////NOTE: This is where you would change your password requirements
            services.AddIdentity<AppUser, IdentityRole>(opts => {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 2;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider service)
        {
            //These lines allow you to see more detailed error messages
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseAuthentication();

            //This line allows you to use static pages like style sheets and images
            app.UseStaticFiles();

            //This line configures the routing for MVC
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });


            //I uncommented this because we don't have seeding yet for anything
            //Seeding.SeedIdentity.AddAdmin(service).Wait();
            //Seeding.SeedCustomerIdentity.AddCustomers(service).Wait();
            //Seeding.SeedFlightAttendantIdentity.AddFlightAttendants(service).Wait();
            //Seeding.SeedCoPilotIdentity.AddCoPilots(service).Wait();
            //Seeding.SeedPilotIdentity.AddPilots(service).Wait();
            //Seeding.SeedAgentIdentity.AddAgents(service).Wait();
            //Seeding.SeedManagerIdentity.AddManagers(service).Wait();
        }
    }
}