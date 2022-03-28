using Microsoft.AspNetCore.Mvc;

namespace Patient_Tracker.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
