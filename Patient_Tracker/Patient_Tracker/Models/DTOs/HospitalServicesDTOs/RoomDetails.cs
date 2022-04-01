using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Tracker.Models.DTOs.HospitalServicesDTOs
{
    public class RoomDetails
    {
        [Key]
        public int RoomId { get; set; }
        public int charge { get; set; }
        public string RoomType { get; set; }
    }
}
