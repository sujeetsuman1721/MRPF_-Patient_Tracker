﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.HospitalServices
{
    public class Consultation
    {
        [Key]
        public int DocId { get; set; }
        public string DoctorName { get; set; }
        public string Purpose { get; set; }
        public int Charge { get; set; }


    }
}
