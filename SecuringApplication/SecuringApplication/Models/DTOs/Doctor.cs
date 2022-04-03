using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
    


}
