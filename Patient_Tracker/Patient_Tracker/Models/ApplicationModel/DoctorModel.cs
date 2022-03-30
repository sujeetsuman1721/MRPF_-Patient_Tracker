using System.ComponentModel.DataAnnotations;

namespace Patient_Tracker.Models.ApplicationModel
{
    public class DoctorModel
    {
        [Key]
        public int DoctorId { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
