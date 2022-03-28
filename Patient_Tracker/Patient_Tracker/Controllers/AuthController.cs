using Microsoft.AspNetCore.Mvc;
using Patient_Tracker.Models.DTOs;
using Patient_Tracker.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Tracker.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserServices context;

        public AuthController(UserServices context) : base()
        {
            this.context = context;
        }
        public IActionResult PatientRegister()
        {
            return View();
        }
        [HttpPost("Patient")]
        public async Task<IActionResult> PatientRegister(Patient model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var IsAdded = await context.SavePatient(model);
            if (IsAdded)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Failed to do registration");
            return View(model);


        }
        public IActionResult DoctorRegister()
        {
            return View();
        }
        [HttpPost("Doctor")]
        public async Task<IActionResult> DoctorRegister(Doctor model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var IsAdded = await context.SaveDoctor(model);
            if (IsAdded)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Failed to do registration");
            return View(model);


        }
        public IActionResult ClerkRegister()
        {
            return View();
        }
        [HttpPost("Clerk")]
        public async Task<IActionResult> ClerkRegister(Clerk model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var IsAdded = await context.SaveClerk(model);
            if (IsAdded)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Failed to do registration");
            return View(model);


        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
