using System;
using System.ComponentModel.DataAnnotations;

namespace Patient_Tracker.Models.ApplicationModel
{
    public class ApplicationUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender has to be selected")]
        public string Gender { get; set; }

        public string Status { get; set; } = "toBeAprooved";

        [MaxLength(10)]
        [Required(ErrorMessage = "Enter correct ContactNumber")]
        public int ContactNumber { get; set; }

        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }

        public string SecretQuestions { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}
