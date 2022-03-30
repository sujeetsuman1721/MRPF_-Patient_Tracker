using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.models
{
    public class RoomDTO
    {
        [Key]
        public int Id { get; set; }
        public int Num { get; set; }
        public string RoomType { get; set; }
        public int NoOfDays { get; set; }
    }
}
