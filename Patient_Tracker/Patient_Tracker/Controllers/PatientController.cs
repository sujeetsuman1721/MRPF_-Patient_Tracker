using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Patient_Tracker.Controllers
{
    public class PatientController : Controller
    { 

        public int ? patientId;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            //trainerService.SetBearerToken(HttpContext.Session.GetString("token"));
            ViewBag.FirstName = HttpContext.Session.GetString("firstname");
            //ViewBag.PatientId=HttpContext.Session.GetInt32()
            var Role = HttpContext.Session.GetString("role");
            patientId=HttpContext.Session.GetInt32("Id");
            
            ViewBag.Role = Role;
            if (!Role.Equals("Patient"))
                context.Result = new RedirectToActionResult("Logout", "Auth", null);
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetDetails()
        {
            return View();

        }



    }
}
