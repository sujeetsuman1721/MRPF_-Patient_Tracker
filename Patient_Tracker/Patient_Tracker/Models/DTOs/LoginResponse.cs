using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Tracker.Models.DTOs
{
    public class LoginResponse
    {
        public string jwt { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public int UserId { get; set; }
    }
}
