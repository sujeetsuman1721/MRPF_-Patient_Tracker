using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Tracker.Models.DTOs.HospitalServicesDTOs
{
    public class LabTests
    {
        [Key]
        public int LabTestId { get; set; }
        public string LabTestName { get; set; }
        public string LabTestResult { get; set; }
        public int Charge { get; set; }
    }
}
