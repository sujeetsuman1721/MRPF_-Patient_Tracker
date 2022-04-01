using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Tracker.Models.DTOs
{
    public class Facilities
    {
       
        
        public int AppointmentId { get; set; }
        public int ConsultationId { get; set; }
        public int RoomId { get; set; }
        public int LabTestId { get; set; }
    }
}
