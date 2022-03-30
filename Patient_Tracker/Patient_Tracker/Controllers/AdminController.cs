using Microsoft.AspNetCore.Mvc;
using Patient_Tracker.Models.Services;
using System.Threading.Tasks;

namespace Patient_Tracker.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserServices userServices;

        public AdminController(UserServices userServices)
        {
            this.userServices = userServices;
        }

        public IActionResult Index()
        {
           
            return View();
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
