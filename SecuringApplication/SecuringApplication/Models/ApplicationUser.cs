using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuringApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
      

        public string FirstName { get; set; }
      
        public string LastName { get; set; }
     
        public DateTime DateOfBirth { get; set; }
  
        public string Gender { get; set; }
       
        public int ContactNumber { get; set; }
      
        public string Address { get; set; }
      
        public string Password { get; set; }
      
        public string ConfirmPassword { get; set; }

        public string SecretQuestions { get; set; }
      
        public string Answer { get; set; }
    }
}
