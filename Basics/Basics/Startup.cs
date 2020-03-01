using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Basics
{
    public class Startup
    {
        private const string CookieAuthenticationName = "CookieAuth";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Added to create Cookie Authentication
            services.AddAuthentication(CookieAuthenticationName)
                .AddCookie(CookieAuthenticationName, options =>
                {
                    options.Cookie.Name = "Grandmas.Cookie";
                    options.LoginPath = "/Home/Authenticate";
                });

            // Added as an example to show how you could override authorization add claims validation will get access denied 
            //services.AddAuthorization(options =>
            //{
            //    var defaultAuthBuilder = new AuthorizationPolicyBuilder();
            //    var defaultAuthPolicy = defaultAuthBuilder
            //    .RequireAuthenticatedUser()
            //    .RequireClaim(ClaimTypes.DateOfBirth)
            //    .Build();
            //    options.DefaultPolicy = defaultAuthPolicy;
            //});

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
