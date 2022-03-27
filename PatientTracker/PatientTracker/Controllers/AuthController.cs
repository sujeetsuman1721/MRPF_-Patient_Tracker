using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientTracker.Models.DTOs;
using PatientTracker.Models.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientTracker.Controllers
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
