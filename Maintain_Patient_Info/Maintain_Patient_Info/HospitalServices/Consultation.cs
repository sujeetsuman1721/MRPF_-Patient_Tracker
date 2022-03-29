using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Models
{
    public class Consultation
    {
        public int DocId { get; set; }
        public string DocName { get; set; }
        public string Purpose { get; set; }
        public string Prescription { get; set; }
        public string Diet { get; set; }
        public long Charges { get; set; }

    }
}
