using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecuringApplication.Models.Registration
{
    public class Clerk
    {
        [Key]
        public int ClerkId { get; set; }

        public string  ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        
    }
}
