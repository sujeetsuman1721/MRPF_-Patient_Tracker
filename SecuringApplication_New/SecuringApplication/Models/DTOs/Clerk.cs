using System.ComponentModel.DataAnnotations;

namespace SecuringApplication.Models.Registration
{
    public class Clerk
    {
        [Key]
        public int ClerkId { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
