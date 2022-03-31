using Microsoft.AspNetCore.Mvc;
using Patient_Tracker.Models.Services;
using System.Threading.Tasks;

namespace Patient_Tracker.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserServices userServices;
        private readonly HospitalServices hospitalServices;

        public AdminController(UserServices userServices,HospitalServices hospitalServices)
        {
            this.userServices = userServices;
            this.hospitalServices = hospitalServices;
        }        

        public async Task<IActionResult> Register()
        {

            // getch the data of patients

            var patients = await userServices.GetPatients();

            var doctors = await userServices.GetDoctors();
            // fetch the data of doctor

            ViewData["patients"] = patients;
            ViewData["doctors"] = doctors;


            return View();
        }


    }
}
