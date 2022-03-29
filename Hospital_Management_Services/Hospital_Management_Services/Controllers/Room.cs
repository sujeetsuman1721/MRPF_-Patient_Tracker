using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_Services.Controllers
{
    public class Room : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
