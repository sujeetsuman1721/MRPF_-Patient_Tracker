using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.models
{
    public class DTO_PM
    {
        [Key]
        public int Id { get; set; }


        public int PateintId { get; set; }

        public int DoctorId { get; set; }

        public DateTime DateOfRegi { get; set; }
        public string Status { get; set; }

    }
}
