using AutoMapper;
using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IRepository<PatientsRegistory> PatientRepository;
        private readonly IMapper mapper;
        public PatientController(IRepository<PatientsRegistory> PatientRepository , IMapper mapper)
        {
           this.PatientRepository = PatientRepository;
            this.mapper = mapper;
        }
        [HttpGet("PatientInfo")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<DTO_PM>))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<PatientsRegistory> patient = await PatientRepository.GetAsync();

            var DTOs = mapper.Map<List<DTO_PM>>(patient); 
            return Ok(DTOs);
        }
      
        [HttpPost("AddPatient")]
        [ProducesResponseType(200, Type = typeof(DTO_PM))]
        public async Task<IActionResult> Post(PatientsRegistory model)
        {
          
          PatientRepository.Add(model);
            await PatientRepository.SaveAsync();
            

            return  StatusCode(200,model);

        }
        [HttpPut("Update")]
        [ProducesResponseType(200, Type = typeof(DTO_PM))]
        public async Task<IActionResult> Put(DTO_PM model)
        {
            PatientsRegistory patient = mapper.Map<PatientsRegistory>(model);
            PatientRepository.Update(patient);
            await PatientRepository.SaveAsync();
            var dto = mapper.Map<DTO_PM>(patient);
            return Ok(dto);

        }


        [HttpGet]
        [Route("[action]/{patinetId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PatientsRegistory>))]

        public async Task<IActionResult> GetAppointmentByPatientId(int patinetId)
        {

            IEnumerable<PatientsRegistory> patients = await PatientRepository.GetAsync();

            var patientsList = patients.Where(p => p.PateintId == patinetId);

            return Ok(patientsList);
        }

        [HttpGet]
        [Route("[action]/{appointmentId}")]
        [ProducesResponseType(200, Type = typeof(PatientsRegistory))]

        public async Task<IActionResult> GetAppointmentById(int appointmentId)
        {

            IEnumerable<PatientsRegistory> patients = await PatientRepository.GetAsync();

            var patient = patients.Where(p => p.Id == appointmentId);

            return Ok(patient);
        }


        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PatientsRegistory>))]

        public async Task<IActionResult> GetAppointmentByDocotoId(int id)
        {

            IEnumerable<PatientsRegistory> patients = await PatientRepository.GetAsync();

            var patientsList = patients.Where(p => p.DoctorId == id);

            return Ok(patientsList);
        }



    }

}
    
