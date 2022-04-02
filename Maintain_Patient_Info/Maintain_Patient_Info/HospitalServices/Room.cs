using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.HospitalServices
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int Charge { get; set; }
        public string RoomType { get; set; }
       
    }
}
