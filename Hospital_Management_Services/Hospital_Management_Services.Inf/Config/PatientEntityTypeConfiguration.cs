using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_Services.Inf.Config
{
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<PatientRegistry>
    {
        public void Configure(EntityTypeBuilder<PatientRegistry> builder)
        {
            throw new NotImplementedException();
        }
    }
}
