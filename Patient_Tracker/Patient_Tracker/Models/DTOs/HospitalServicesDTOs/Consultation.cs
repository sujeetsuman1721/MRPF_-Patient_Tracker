using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Tracker.Models.DTOs.HospitalServicesDTOs
{
    public class Consultation
    {
        [Key]
        public int ConsultationId { get; set; }
        public string Purpose { get; set; }
        public int Charge { get; set; }
    }
}
