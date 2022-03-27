using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientTracker.Models.DTOs
{
    public class LoginResponse
    {
        public string jwt { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }
}
