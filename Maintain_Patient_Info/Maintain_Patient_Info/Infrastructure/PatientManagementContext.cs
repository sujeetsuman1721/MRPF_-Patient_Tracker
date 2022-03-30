using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.HospitalServices;

namespace Maintain_Patient_Info.Infrastructure
{
    public class PatientManagementContext : DbContext

    {
        public PatientManagementContext(DbContextOptions<PatientManagementContext> options) : base(options)
        {

        }
        public virtual DbSet<patient_info> patient_infos { get; set; }
        public virtual DbSet<LabTests> labTests { get; set; } 
        public virtual DbSet<PrescriptionDetails> prescriptionDetails { get; set; }
        public virtual DbSet<Consultation> consultation { get; set; }
        public virtual DbSet<Room> rooms { get; set; }
    }
}
