using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PatientTracker.Models.DTOs;
using PatientTracker.Models.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientTracker.Controllers
{
    public class PatientsAuthController : Controller
    {
        private readonly PatientRegistrationServices context;

        public PatientsAuthController(PatientRegistrationServices context) : base()
        {
            this.context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext con)
        {
            base.OnActionExecuting(con);
            context.SetBearerToken(HttpContext.Session.GetString("token"));


        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PatientRegistrationModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var IsAdded = await context.SaveRegister(model);
            if (IsAdded)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Failed to add trainer");
            return View(model);


        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
