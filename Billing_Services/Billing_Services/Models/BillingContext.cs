using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing_Services.Models
{
    public class BillingContext:DbContext
    {
        public BillingContext(DbContextOptions<BillingContext> options) : base(options)
        {

        }
        public virtual DbSet<BillingServices> BillingServices { get; set; }
    }
}
