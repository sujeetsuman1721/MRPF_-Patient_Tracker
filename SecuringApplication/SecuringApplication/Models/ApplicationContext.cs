using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        public virtual DbSet<Patient> Patient { get; set; }

        public virtual DbSet<Clerk>  Clerks { get; set; }

        public virtual DbSet<ApplicationUser> AspNetUsers { get; set; }

    }
    
}
