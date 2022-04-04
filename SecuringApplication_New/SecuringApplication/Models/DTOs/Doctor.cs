using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecuringApplication.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
       
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string Specialization { get; set; }


        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
    


}
