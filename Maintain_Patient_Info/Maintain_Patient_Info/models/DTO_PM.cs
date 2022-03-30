using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.models
{
    public class DTO_PM
    {
        [Key]
        public string Username { get; set; }
        [Required]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Status { get; set; }

    }
}
