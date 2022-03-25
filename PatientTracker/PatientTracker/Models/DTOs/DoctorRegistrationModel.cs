using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientTracker.Models.DTOs
{
    public class DoctorRegistrationModel:RegistrationModel
    {
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string Specialization { get; set; }
    }
}
