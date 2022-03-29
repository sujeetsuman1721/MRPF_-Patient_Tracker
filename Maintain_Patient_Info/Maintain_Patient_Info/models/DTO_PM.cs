using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info
{
    public class DTO_PM
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public DateTime Date { get; set; }
       
        public string Prescription { get; set; }
        public string Result { get; set; }

    }
}
