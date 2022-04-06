using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecuringApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string RegistratioStatus { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender has to be selected")]
        public string Gender { get; set; }
       
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }
      
        public string SecretQuestions { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}
