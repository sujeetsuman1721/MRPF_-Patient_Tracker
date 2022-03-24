using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models.DTOs
{
    public class DoctorRegistrationModel:RegistrationModel
    {
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string Specialization { get; set; }
    }
}
