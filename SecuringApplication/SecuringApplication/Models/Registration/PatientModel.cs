﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SecuringApplication.Models.Registration
{
    public class PatientModel
    {
       
        [Required]
        public string UserName { get; set; }


        [Required(ErrorMessage = "FirstName can't be empty")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth cant be empty")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender has to be selected")]
        public string Gender { get; set; }

        public string Status { get; set; }

      
        [Required(ErrorMessage = "Enter correct ContactNumber")]
        public string ContactNumber { get; set; }
       
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "The type of password should be atleast minimum 8 characters atleast contain 1 capital letter,1 small letter,1 special character ")]


        [DataType(DataType.Password)]
        [MinLength(6)]

        public string Password { get; set; }
        [DataType(DataType.Password)]

        [Compare("Password", ErrorMessage ="the password not mathing")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string SecretQuestions { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}
