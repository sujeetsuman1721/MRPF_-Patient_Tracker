﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Base
{
    public class Facilites
    {
        [Key]
        public int Id { get; set; }

        public int AppointmentId { get; set; }
        public int ConsultationId { get; set; }
        public int RoomId { get; set; }
        public int LabTestId { get; set; }

    }
}
