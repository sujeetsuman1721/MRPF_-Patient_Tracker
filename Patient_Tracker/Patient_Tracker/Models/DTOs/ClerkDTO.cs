﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Tracker.Models.DTOs
{
    public class ClerkDTO
    {
        [Key]
        public int ClerkId { get; set; }
        [Required(ErrorMessage = "FirstName can't be empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "FirstName can't be empty")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth cant be empty")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender has to be selected")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Enter correct ContactNumber")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }
       
        [DataType(DataType.Password)]
        [MinLength(6)]
        [Required(ErrorMessage = "Password should be minimum 6 letters with special character included")]

        public string Password { get; set; }

        [DataType(DataType.Password)]

        [Required(ErrorMessage = "Password should be minimum 6 letters with special character included")]
        [MinLength(6)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string SecretQuestions { get; set; }
        [Required]
        public string Answer { get; set; }

        public string Status { get; set; }= "UnAproove";
    }
}

