using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Patient_Tracker.Models.HospitalServices;
using Patient_Tracker.Models.Services;
using System.Threading.Tasks;

namespace Patient_Tracker.Controllers
{
    public class DoctorController : Controller
    {

        private readonly UserServices userServices;

        private readonly PatientServices patientServices;

        private readonly HospitalServices hospitalServices;

        private readonly BillingServices billingServices;

        public int? DoctorId;

        public string UserName;


        public DoctorController(UserServices userServices, PatientServices patientServices, HospitalServices hospitalServices, BillingServices billingServices)

        {
            this.patientServices = patientServices;
            this.userServices = userServices;
            this.hospitalServices = hospitalServices;
            this.billingServices = billingServices;

        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            //patientServices.SetBearerToken(HttpContext.Session.GetString("Jwt"));
            UserName = HttpContext.Session.GetString("UserName");

            var Role = HttpContext.Session.GetString("UserRole");
            DoctorId = HttpContext.Session.GetInt32("UserId");

            ViewBag.Role = Role;
            if (!Role.Equals("Doctor"))
                context.Result = new RedirectToActionResult("Logout", "Auth", null);
        }
        public async Task<IActionResult> Index()
        {
            var appointment = await patientServices.GetAppointmentByDoctorId(DoctorId);
            ViewBag.UserName = UserName;
            return View(appointment);
        }

        public async Task<IActionResult> Update(int id )
        {
            var appointment = await patientServices.GetAppointmentById(id);
            var p = appointment[0];
            ViewBag.UserName = UserName;
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PatientRegistory patientRegistory)
        {
            var appointment = await patientServices.UpdatePatient(patientRegistory);

            return RedirectToAction("Index");
        }


    }
}
