using System.ComponentModel.DataAnnotations;

namespace Patient_Tracker.Models.ApplicationModel
{
    public class PatientModel
    {
        [Key]
        public int PatientId { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
