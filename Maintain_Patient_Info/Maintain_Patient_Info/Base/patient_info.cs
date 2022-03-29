using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Base
{
    public class patient_info
    {
        [Key]
        public int Id { get; set; }
        public string Username {get; set;}
        
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Prescription { get; set; }
        public string Result { get; set; }
        

        
    }
}
