using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientTracker.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var api1url = Configuration["ApiAddresses:PatientRegistrationServicesAPI"];
            services.AddHttpClient("PatientRegistrationServicesAPI", setup => setup.BaseAddress = new Uri(api1url));
           
            var api2url = Configuration["ApiAddresses:DoctorRegistrationServicesAPI"];
            services.AddHttpClient("DoctorRegistrationServicesAPI", setup => setup.BaseAddress = new Uri(api2url));
            var api3url = Configuration["ApiAddresses:ClerkRegistrationServicesAPI"];
            services.AddHttpClient("ClerkRegistrationServicesAPI", setup => setup.BaseAddress = new Uri(api3url));
            services.AddScoped(typeof(UserServices));
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth/Doctor}/{action=Create}/{id?}");
            });
        }
    }
}
