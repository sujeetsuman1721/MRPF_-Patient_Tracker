using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientTracker.Models.DTOs
{
    public class Doctor
    {
        [Required(ErrorMessage = "FirstName can't be empty")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth cant be empty")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender has to be selected")]
        public string Gender { get; set; }


        [MaxLength(10)]
        [Required(ErrorMessage = "Enter correct ContactNumber")]
        public string ContactNumber { get; set; }


        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "The type of password should be atleast minimum 8 characters atleast contain 1 capital letter,1 small letter,1 special character ")]

        [DataType(DataType.Password)]
        [MinLength(6)]

        public string Password { get; set; }
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
        [Required]
        public string SecretQuestions { get; set; }
        [Required]
        public string Answer { get; set; }

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
