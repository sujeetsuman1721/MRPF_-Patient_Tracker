using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintain_Patient_Info.Base;

namespace Maintain_Patient_Info.Infrastructure
{
    public class PatientManagementContext : DbContext

    {
        public PatientManagementContext(DbContextOptions<PatientManagementContext> options) : base(options)
        {

        }
        public virtual DbSet<patient_info> patient_infos { get; set; }
            

    }
}
