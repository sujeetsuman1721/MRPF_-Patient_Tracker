using Billing_Services.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing_Services
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
            services.AddCors();
            services.AddControllers();
            var connectionstring = Configuration.GetConnectionString("con");
            services.AddDbContext<BillingContext>(setup => setup.UseSqlServer(connectionstring));
            services.AddScoped<IRepository<BillingServices>, GenericRepository<BillingServices>>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo
            {
<<<<<<< HEAD
<<<<<<< HEAD
                Title = "User Manager API",
                Description = "Allow the User to Register and Login ",
                Contact = new OpenApiContact
                {
                    Email = "PatientTracker@outlook.com",
                    Name = "Patient Tracker"
                }
=======
                Title="BillingServices",
                Description="Charges",
                Contact=new OpenApiContact
=======

                Title = "Billing Services API",
                Description = "Allow to generate a bill ",
                Contact = new OpenApiContact
>>>>>>> 1a58f28f6d706dbf59a9f97e62ad6a7527a78f51
                {
                    Email = "PatientTracker@outlook.com",
                    Name = "Patient Tracker",

                }

>>>>>>> 164d104ed906bc6240e8ee104273a1b8f4ae08d0
            }));
        }
       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(setup => setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Billing Services"));
            app.UseCors(setup => setup.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
