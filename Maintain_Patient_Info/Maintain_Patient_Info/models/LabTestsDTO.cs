﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.models
{
    public class LabTestsDTO
    {
        [Key]
        public int LabTestId { get; set; }
        public string LabTestName { get; set; }
        public string LabTestResult { get; set; }
        public int Charge { get; set; }
    }
}
