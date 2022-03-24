using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SecuringApplication.Models
{

    public class AppContext : IdentityDbContext<ApplicationUser>
    {
        
        
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            

        }
        public virtual DbSet<RegistrationModel> Registry { get; set; }

    }
}
