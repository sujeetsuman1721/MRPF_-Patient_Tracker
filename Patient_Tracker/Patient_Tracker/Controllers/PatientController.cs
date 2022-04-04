using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Patient_Tracker.Models.Services;
using System.Threading.Tasks;

namespace Patient_Tracker.Controllers
{
    public class PatientController : Controller
    {

        
        private readonly UserServices userServices;

        private readonly PatientServices patientServices;

        private readonly HospitalServices hospitalServices;

        private readonly BillingServices billingServices;

        public int? patientId;

        public string UserName;


        public PatientController(UserServices userServices, PatientServices patientServices, HospitalServices hospitalServices, BillingServices billingServices)

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
            patientId = HttpContext.Session.GetInt32("UserId");

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

        public async Task<IActionResult> ViewRecord()
        {
            var appointment =await patientServices.GetAppointmentByPatientId(patientId);
            
            ViewBag.UserName = UserName;
       
            return View(appointment);

        }

        public async Task<IActionResult> ViewCharge()
        {
            var appointment = await patientServices.GetAppointmentByPatientId(patientId);

            ViewBag.UserName = UserName;

            return View(appointment);

        }
        public async Task<IActionResult> Details(int id)
        {
            var appointment= await patientServices.GetAppointmentById(id);


            var p = appointment[0];

            ViewBag.UserName = UserName;
            return View(p);

        }






    }
}
