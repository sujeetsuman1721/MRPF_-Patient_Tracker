using System;
using System.ComponentModel.DataAnnotations;

namespace Patient_Tracker.Models.HospitalServices
{
    public class PatientRegistory
    {

        [Key]
        public string Id { get; set; }


        public int PateintId { get; set; }

        public int DoctorId { get; set; }
   
        public DateTime DateOfRegi { get; set; }
        public string Status { get; set; }
    }
}
