using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientTracker.Models.DTOs
{
    public class RegistrationModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName cant be empty")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName cant be empty")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Date of birth cant be empty")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender has to be selected")]
        public gender Gender { get; set; }
        [RegularExpression("^[0-9]{8})|[0-9]+{12}|[0-9]{11}$", ErrorMessage = "Invalid phone")]
        public int ContactNumber { get; set; }
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "The type of password should be atleast minimum 8 characters atleast contain 1 capital letter,1 small letter,1 special character ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        public secretques SecretQuestions { get; set; }
        [Required]
        public string Answer { get; set; }
    }
    public enum gender
    {
        Male,
        Female

    }
    public enum secretques
    {
        FavouriteColor,
        FavouriteFood,
        FavouriteThing,
        DateOfBirth
    }

}
