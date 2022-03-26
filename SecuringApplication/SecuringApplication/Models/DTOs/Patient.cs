using System.ComponentModel.DataAnnotations;

namespace SecuringApplication.Models
{
    public class Patient
    {
        [Key]

        public int PatientId { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
   
}
