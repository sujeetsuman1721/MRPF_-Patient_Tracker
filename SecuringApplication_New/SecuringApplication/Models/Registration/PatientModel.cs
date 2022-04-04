using SecuringApplication.Models.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SecuringApplication.Models.Registration
{
    public class PatientModel : BaseEntity
    {
       
       [Required]
        public   string UserName { get; set; }


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





        public  PatientModel(string userName, string password,string firstName,string gender,string address, string contactNumber,string conformPassword)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException($"Invalid value for : ${nameof(userName)}");

            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException($"Invalid value for : ${nameof(firstName)}");

          //  if ( DateTime.IsNullorEmpty(dateOfBirth))
         //      throw new ArgumentException($"Invalid value for : ${nameof(dateOfBirth)}");

            if (string.IsNullOrEmpty(gender))
                throw new ArgumentException($"Invalid value for : ${nameof(gender)}");

            if (string.IsNullOrEmpty(address))
                throw new ArgumentException($"Invalid value for : ${nameof(address)}");

            if (string.IsNullOrEmpty(contactNumber) || !contactNumber.Length.Equals(10)) 
                 throw new ArgumentException($"Invalid value for : ${nameof(contactNumber)}");

            if (string.IsNullOrEmpty(password)|| !password.StartsWith("uppercase letter") || !password.Contains("lowercase letter") ||!password.Length.Equals(8)) 
                throw new ArgumentException($"Invalid value for : ${nameof(password)}");


            this.UserName       = userName;
            this.Password       = password;
            this.FirstName      = firstName;
            this.Gender         = gender;
            this.Address        = address;
            this.ContactNumber  = contactNumber;
            this.ConfirmPassword= conformPassword;
            


            public void ChangeUserName(string userName)
              {
                if (string.IsNullOrEmpty(userName))
                    throw new ArgumentException($"Invalid value for : ${nameof(userName)}");
                if (UserName == userName)
                    return;
                   UserName = userName;
               }

            public void ConfirmsNewPassword(string confirmPassword)
            {
                if (string.IsNullOrEmpty(conformPassword))
                    throw new ArgumentException($"Invalid value for : ${nameof(confirmPassword)}");
                if (ConfirmPassword == confirmPassword)
                    return;
                ConfirmPassword = confirmPassword;
            }


        }
    }
}

