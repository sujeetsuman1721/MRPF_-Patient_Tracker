using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecuringApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SecuringApplication.Reposetory;
using SecuringApplication.Models.Registration;
using Microsoft.OpenApi.Models;

namespace SecuringApplication
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
            services.AddDbContext<ApplicationContext>(setup => setup.UseSqlServer(Configuration.GetConnectionString("con")));

            services.AddScoped<IReposetory<Patient>, GenereicRepository<Patient>>();
            services.AddScoped<IReposetory<Doctor>, GenereicRepository<Doctor>>();
            services.AddScoped<IReposetory<Clerk>, GenereicRepository<Clerk>>();


            services.AddIdentity<ApplicationUser, IdentityRole>(setup =>
            {
                setup.Password.RequireDigit = true;
                //setup.SignIn.RequireConfirmedEmail = true;

                setup.Lockout.MaxFailedAccessAttempts = 5;
                setup.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddEntityFrameworkStores<ApplicationContext>();

            string key = Configuration["JwtSettings:Key"];
            string issuer = Configuration["JwtSettings:Issuer"];
            string audience = Configuration["JwtSettings:Audience"];
            int durationInMinutes = int.Parse(Configuration["JwtSettings:DurationInMinutes"]);

            byte[] keyBytes = System.Text.Encoding.ASCII.GetBytes(key);
            SecurityKey securityKey = new SymmetricSecurityKey(keyBytes);

            services.AddAuthentication(setup =>
            {
                setup.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                setup.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                setup.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                setup.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                setup.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(setup => setup.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = audience,
                ValidIssuer = issuer,
                IssuerSigningKey = securityKey
            });

            services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "User Manager API",
                Description = "Allow the User to Register and Login ",
                Contact = new OpenApiContact
                {
                    Email = "PatientTracker@outlook.com",
                    Name = "Patient Tracker"
                }
            }));

            // adding the seed service for the
            services.AddScoped(typeof(AppSeedUsers));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setup => setup.SwaggerEndpoint("/swagger/v1/swagger.json", "My APi"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(setup =>
            setup.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
