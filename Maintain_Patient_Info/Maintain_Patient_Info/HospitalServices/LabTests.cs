using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Models
{
    public class LabTests
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }

        public long Charges { get; set; }

    }
}
