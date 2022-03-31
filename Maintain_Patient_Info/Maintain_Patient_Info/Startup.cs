
using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.HospitalServices;
using Maintain_Patient_Info.Infrastructure;
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

namespace Maintain_Patient_Info
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
            var connectionstring = Configuration.GetConnectionString("PM_Connection");
            services.AddDbContext<PatientManagementContext>(setup => setup.UseSqlServer(connectionstring));
            services.AddScoped<IRepository<PatientsRegistory>, GenericRepository<PatientsRegistory>>();
            services.AddScoped<IRepository<LabTests>, GenericRepository<LabTests>>();
            services.AddScoped<IRepository<Consultation>, GenericRepository<Consultation>>();
            services.AddScoped<IRepository<Room>, GenericRepository<Room>>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // adding the seed service for the
           

            //services.AddScoped(typeof(AppSeed));
            services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Patient Management",
                Description = " Maintain patients information"

            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(setup => setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Patient Data Management"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(setup => setup.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
