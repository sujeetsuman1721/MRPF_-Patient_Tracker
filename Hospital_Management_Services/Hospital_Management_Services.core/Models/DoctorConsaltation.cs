using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_Services
{
    public class DoctorConsaltation : BaseEntity
    {    
        public int Id { get; set; }
        public string ConsaltentDoctor { get; set; }
        public int Prescription { get; set; }
        public string DietPlain { get; set; }
        public string Exercise { get; set; }
        public long PatientRegistryId { get; set; }
       

        
    }
}
