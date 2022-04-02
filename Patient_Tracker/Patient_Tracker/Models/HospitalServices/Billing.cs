﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Tracker.Models.HospitalServices
{
    public class Billing
    {
        [Key]
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int ConsultationCharges { get; set; }
        public int LabTestCharges { get; set; }
        public int RoomCharges { get; set; }
        public long TotalAmount { get; set; }
    }
}
