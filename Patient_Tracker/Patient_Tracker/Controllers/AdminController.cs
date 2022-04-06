using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Patient_Tracker.Models.DTOs;
using Patient_Tracker.Models.DTOs.HospitalServicesDTOs;
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

        private readonly BillingServices billingServices;


        public AdminController(UserServices userServices, PatientServices patientServices, HospitalServices hospitalServices, BillingServices billingServices)

        {
            this.patientServices = patientServices;
            this.userServices = userServices;
            this.hospitalServices = hospitalServices;
            this.billingServices = billingServices;

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

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(PatientRegistory model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Priscription = "Yet to update By doctor";
            model.ExerciseOrDiet = "Yet to add by the doctor";

            var IsAdded = await patientServices.AppointPatient(model);


            return RedirectToAction("Appointed");

        }

        public async Task<IActionResult> Appointed()
        {
            var pat = await patientServices.GetAppointedDoctor();

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
            TempData["Success"] = "Facility is added to the Appointment Id " + facilities.AppointmentId + " successfully";
            return RedirectToAction("Appointed");

        }
        public async Task<IActionResult> Billing()
        {
            var pat = await patientServices.GetAppointedDoctor();

            return View(pat);

        }

        public async Task<IActionResult> GenerateBill(int id)
        {

            ViewBag.Id = id;

            var facility = await hospitalServices.GetFacilityByAppontmentId(id);

            var labId = facility.LabTestId;
            var consId = facility.ConsultationId;
            var roomId = facility.RoomId;


            var room = await hospitalServices.GetRoomById(roomId);
            var cons = await hospitalServices.GetConsultationById(consId);
            var Lab = await hospitalServices.GetLabTestById(consId);

            ViewBag.LabCharge = Lab.Charge;
            ViewBag.conCharge = cons.Charge;
            ViewBag.RoomCharge = room.Charge;

            ViewBag.totalCharge = Lab.Charge + cons.Charge + room.Charge;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateBill(Billing billing)
        {

            var facility = await hospitalServices.GetFacilityByAppontmentId(billing.AppointmentId);
            var labId = facility.LabTestId;
            var consId = facility.ConsultationId;
            var roomId = facility.RoomId;


            var room = await hospitalServices.GetRoomById(roomId);
            var cons = await hospitalServices.GetRoomById(consId);
            var Lab = await hospitalServices.GetLabTestById(consId);

            billing.LabTestCharges = Lab.Charge;
            billing.RoomCharges = room.Charge;
            billing.ConsultationCharges = cons.Charge;

            billing.TotalAmount = Lab.Charge + room.Charge + cons.Charge;
            var total = Lab.Charge + room.Charge + cons.Charge;

            await billingServices.GenerateBill(billing);


            TempData["Success"] = "Bill is Genarated for Appointment Id " + billing.AppointmentId;
            TempData["Success"] = "Bill is Genarated for Appointment Id " + billing.AppointmentId;
            return RedirectToAction("Billing");

        }

        public async Task<IActionResult> Approval()
        {
            var newRegistration = await userServices.GetAllRegistration();

            List<ApplicationUserDto> users = new List<ApplicationUserDto>();

            ApplicationUserDto user;

            foreach (ApplicationUserDto userItem in newRegistration)
            {
                user = new ApplicationUserDto();

                user.UserName = userItem.UserName;
                user.RegistratioStatus = userItem.RegistratioStatus;
                user.FirstName = userItem.FirstName;
                user.LastName = userItem.LastName;
                user.DateOfBirth = userItem.DateOfBirth;
                user.RegistratioStatus = userItem.RegistratioStatus;
                user.Address = userItem.Address;
                user.Gender = userItem.Gender;


                users.Add(user);

            }


            return View(users);
        }
       
        public async Task<IActionResult> Accept(string username, string registrationStatus)
        {
            var val = await userServices.Approve(username, registrationStatus);
            if (val == true)
            {
                TempData["Approve"] ="The Stutus of "+username+" Accepted";
                return RedirectToAction("Approval");

            }
            else
            {
                TempData["Approve"] = "The Stutus of " + username +" Denied";
                return RedirectToAction("Approval");
            }






        }
        
        public async Task<IActionResult> Deny(string username, string registrationStatus)
        {
            var val = await userServices.Approve(username, registrationStatus);
            if (val == true)
            {
                TempData["Success"] = "The Stutus is chaged TO" + registrationStatus + " successfully";
                return RedirectToAction("Approval");

            }
            else
            {
                TempData["Success"] = "The Stutus is No chaged TO" + registrationStatus;
                return RedirectToAction("Approval");
            }

        }


    }
}
