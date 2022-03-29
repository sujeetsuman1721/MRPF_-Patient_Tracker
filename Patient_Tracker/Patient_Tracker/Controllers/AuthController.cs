using Microsoft.AspNetCore.Http;
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
        private readonly UserServices userServices;

        public AuthController(UserServices userServices)
        {
            this.userServices = userServices;
        }
       
       
        public IActionResult Patient()
        {
            return View();
        }
        [HttpPost("PatientRegister")]
        public async Task<IActionResult> PatientRegister(Patient model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var IsAdded = await userServices.SavePatient(model);
            if (IsAdded)
            {
                TempData["Success"] = model.UserName + " registered Successfully";

                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Failed to do registration");
            TempData["Failure"] = model.UserName + " You are not able  Successfully";
            return View(model);



        }
        public IActionResult Doctor()
        {
            return View();
        }
        [HttpPost("Doctor")]
        public async Task<IActionResult> DoctorRegister(Doctor model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var IsAdded = await userServices.SaveDoctor(model);
            if (IsAdded)
            {

                TempData["Success"] = model.UserName + " registered Successfully";
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Failed to do registration");
            TempData["Failure"] = model.UserName + " You are not able  Successfully";
            return View(model);


        }
        public IActionResult Clerk()
        {
            return View();
        }
        [HttpPost("Clerk")]
        public async Task<IActionResult> ClerkRegister(Clerk model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var IsAdded = await userServices.SaveClerk(model);
            if (IsAdded)
            {
                TempData["Success"] = model.UserName + " registered Successfully";

                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Failed to do registration");
            TempData["Failure"] = model.UserName + " You are not able  Successfully";
            return View(model);


        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            if (!ModelState.IsValid) return View(model);

            var Result = await userServices.Login(model);

            HttpContext.Session.SetString("token", Result.jwt);
            HttpContext.Session.SetString("name", Result.name);
            HttpContext.Session.SetString("role", Result.role);

            if (Result.role.Equals("Admin"))
                return RedirectToAction("Index", "Admin");
            else if (Result.role.Equals("Clerk"))
                return RedirectToAction("Index", "Clerk");
            else if (Result.role.Equals("Doctor"))
                return RedirectToAction("Index", "Doctor");
            else if (Result.role.Equals("Patient"))
                return RedirectToAction("Index", "Patient");

            ModelState.AddModelError("", "Cannot identify the user");
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
