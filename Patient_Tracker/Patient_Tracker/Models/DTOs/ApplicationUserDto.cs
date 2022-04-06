using System;

namespace Patient_Tracker.Models.DTOs
{
    public class ApplicationUserDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        


        public DateTime DateOfBirth { get; set; }
       
        public string Gender { get; set; }

     
        public string Address { get; set; }

        public string RegistratioStatus { get; set; }

    }
}
