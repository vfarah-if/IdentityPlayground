using System;
using System.Collections.Generic;
using Identity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Identity
{
    public class Startup
    {
        private const string CookieAuthenticationName = "CookieAuth";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Added to configure in memory database with entity framework
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("EphemeralDurability");
            });


            // Added to Configure identity
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4; // Configure password options ...
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Added to configure storage to cookie
            services.ConfigureApplicationCookie(options => 
            {
                options.Cookie.Name = "Identity.Cookie";
                options.LoginPath = "/Home/Login";
            });

            // Added to utilise views
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            // Added to Authenticate user
            //who are you?
            app.UseAuthentication();

            // Added authorise user
            // What are you allowed to see?
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                // Added to map default controllers
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
