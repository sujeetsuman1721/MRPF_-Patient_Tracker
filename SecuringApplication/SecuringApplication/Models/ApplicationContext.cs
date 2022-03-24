using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SecuringApplication.Models
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        //public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<DoctorRegistrationModel> DoctorRegistrationModels { get; set; }

        public virtual DbSet<PatienntRegistrationModel> PatienntRegistrationModels { get; set; }

    }
    
}
