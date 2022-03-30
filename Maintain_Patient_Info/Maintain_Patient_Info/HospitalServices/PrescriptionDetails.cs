﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.HospitalServices
{
    public class PrescriptionDetails
    {
        [Key]
        public int Id { get; set; }
        public string PrescriptionId { get; set; }
        public string MedicineDetails { get; set; }
        public int Quantity { get; set; }
    }
}