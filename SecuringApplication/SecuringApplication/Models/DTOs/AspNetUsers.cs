using System.ComponentModel.DataAnnotations;

namespace SecuringApplication.Models
{
    public class AspNetUsers
    {
        [Key]

        public int PatientId { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
   
}
