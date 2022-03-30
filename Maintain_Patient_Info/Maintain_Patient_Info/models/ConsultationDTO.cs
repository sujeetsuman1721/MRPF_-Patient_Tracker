﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.models
{
    public class ConsultationDTO
    {
        [Key]
        public int DocId { get; set; }
        public string DocName { get; set; }
        public string Purpose { get; set; }
    }
}