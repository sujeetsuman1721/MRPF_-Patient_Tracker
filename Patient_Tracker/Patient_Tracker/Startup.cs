using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Patient_Tracker.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Tracker
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
            var api1url = Configuration["ApiAddresses:Athentication"];
            var api2url = Configuration["ApiAddresses:PatientInfo"];
            var api3url = Configuration["ApiAddresses:GenerateBill"];

            services.AddHttpClient("Authentication", setup => setup.BaseAddress = new Uri(api1url));


            services.AddHttpClient("PatientInfo", setup => setup.BaseAddress = new Uri(api2url));
            services.AddHttpClient("GenerateBill", setup => setup.BaseAddress = new Uri(api3url));
            

            services.AddScoped(typeof(UserServices));
            services.AddScoped(typeof(PatientServices));
            services.AddScoped(typeof(BillingServices));
            services.AddScoped(typeof(HospitalServices));

            services.AddScoped(typeof(BillingServices));




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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}");
            });
        }
    }
}