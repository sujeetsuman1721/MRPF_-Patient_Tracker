using System;
using System.ComponentModel.DataAnnotations;

namespace Patient_Tracker.Models.HospitalServices
{
    public class PatientRegistory
    {

        [Key]
        public int Id { get; set; }


        public int PateintId { get; set; }

        public int DoctorId { get; set; }
   
        public DateTime DateOfRegi { get; set; }
        public string Status { get; set; }

        public string Priscription { get; set; }

        public string ExerciseOrDiet { get; set; }
    }
}
