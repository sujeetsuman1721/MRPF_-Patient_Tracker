using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Tracker.Models.DTOs
{
    public class LoginResponse
    {
        public string Jwt { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public int UserId { get; set; }
    }
}
