﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecuringApplication.Models.Registration;

namespace SecuringApplication.Models
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public virtual DbSet<Doctor> Doctor { get; set; }

        public virtual DbSet<Patient> Patiennt { get; set; }

        public virtual DbSet<Clerk>  Clerks { get; set; }

    }
    
}