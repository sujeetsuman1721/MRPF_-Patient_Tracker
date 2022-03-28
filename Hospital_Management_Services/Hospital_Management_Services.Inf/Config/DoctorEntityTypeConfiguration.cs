using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Hospital_Management_Services;

namespace Hospital_Management_Services.Inf.Config
{
    public class DoctorEntityTypeConfiguration : IEntityTypeConfiguration<DoctorConsaltation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DoctorConsaltation> builder)
        {
            throw new NotImplementedException();
        }
    }

}
