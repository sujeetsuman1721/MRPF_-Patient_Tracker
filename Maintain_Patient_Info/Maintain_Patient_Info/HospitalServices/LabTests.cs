using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.HospitalServices
{
    public class LabTests
    {
        [Key]
        public int Id { get; set; }
        public string LabTestName { get; set; }
        public string LabTestResult { get; set; }

    }
}
