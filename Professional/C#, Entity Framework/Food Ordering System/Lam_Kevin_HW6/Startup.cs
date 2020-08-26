using System;
using Lam_Kevin_HW6.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


using Lam_Kevin_HW6.DAL;

namespace Lam_Kevin_HW6
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            String connectionString = "Server=tcp:mis333ksp20.database.windows.net,1433;Initial Catalog=MIS333kSP20-44;Persist Security Info=False;User ID=MIS333kSP2044user;Password=!333Ksp206913;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            ////NOTE: This is where you would change your password requirements
            services.AddIdentity<AppUser, IdentityRole>(opts => {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
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

            //Seeding.SeedIdentity.AddAdmin(service).Wait();
        }

    }
}
