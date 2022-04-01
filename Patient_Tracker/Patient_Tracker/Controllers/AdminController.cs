using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Patient_Tracker.Models.DTOs;
using Patient_Tracker.Models.HospitalServices;
using Patient_Tracker.Models.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient_Tracker.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserServices userServices;

        private readonly PatientServices patientServices;

        private readonly HospitalServices hospitalServices;

    


        public AdminController(UserServices userServices, PatientServices patientServices,HospitalServices hospital)

        {
            this.patientServices = patientServices;
            this.userServices = userServices;
            this.hospitalServices = hospital;
       

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


           var doctorlist= new List<DoctorDTO>();
            //fetch data
            foreach (var dt in doctors)
            {
                var d= new DoctorDTO();

                d.DoctorId = dt.DoctorId;
                d.FirstName=dt.ApplicationUser.FirstName;
              
                d.LastName = dt.ApplicationUser.LastName;

                doctorlist.Add(d);
                
            }

            var patientlist = new List<PatientDTO>();

            foreach (var pt in patients)
            {
                var p = new PatientDTO();

                p.PateintId = pt.PatientId;
                p.FirstName = pt.ApplicationUser.FirstName;

                p.LastName = pt.ApplicationUser.LastName;

                patientlist.Add(p);

            }

            ViewBag.patientList = new SelectList(patientlist, "PateintId", "FirstName");

            ViewBag.DoctorList = new SelectList(doctorlist, "DoctorId", "FirstName");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(PatientRegistory model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var IsAdded = await patientServices.AppointPatient(model);

           
            return RedirectToAction("Appointed");

        }

        public async Task<IActionResult> Appointed()
        {
            var pat= await patientServices.GetAppointedDoctor();

            return View(pat);


        }
        public async Task<IActionResult> Update()
        {
            var patients = await userServices.GetPatients();


            var doctors = await userServices.GetDoctors();

            var doctorlist = new List<DoctorDTO>();
            //fetch data
            foreach (var dt in doctors)
            {
                var d = new DoctorDTO();

                d.DoctorId = dt.DoctorId;
                d.FirstName = dt.ApplicationUser.FirstName;

                d.LastName = dt.ApplicationUser.LastName;

                doctorlist.Add(d);

            }

            var patientlist = new List<PatientDTO>();

            foreach (var pt in patients)
            {
                var p = new PatientDTO();

                p.PateintId = pt.PatientId;
                p.FirstName = pt.ApplicationUser.FirstName;

                p.LastName = pt.ApplicationUser.LastName;

                patientlist.Add(p);

            }

            ViewBag.patientList = new SelectList(patientlist, "PateintId", "FirstName");

            ViewBag.DoctorList = new SelectList(doctorlist, "DoctorId", "FirstName");
            var labTests = await hospitalServices.GetLabTests();
            ViewBag.Labtests = new SelectList(labTests, "LabTestId", "LabTestName");
            var consultants = await hospitalServices.GetConsultationDetails();
            ViewBag.ConsultationPurpose = new SelectList(consultants, "ConsultationId", "Purpose");
            var rooms = await hospitalServices.GetRoomDetails();
            ViewBag.RoomDetails = new SelectList(rooms, "RoomId", "RoomType");
            return View();

        }


        public async Task<IActionResult> AddFacility(int id)
        {
            ViewBag.Id = id;
            var labTests = await hospitalServices.GetLabTests();
            ViewBag.Labtests = new SelectList(labTests, "LabTestId", "LabTestName");
            var consultants = await hospitalServices.GetConsultationDetails();
            ViewBag.ConsultationPurpose = new SelectList(consultants, "ConsultationId", "Purpose");
            var rooms = await hospitalServices.GetRoomDetails();
            ViewBag.RoomDetails = new SelectList(rooms, "RoomId", "RoomType");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddFacility(Facilities facilities)
        {
            
            await hospitalServices.AddFacility(facilities);
            return View();

        }



    }
}
