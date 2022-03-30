using AutoMapper;
using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [HttpGet("{username}")]
        [ProducesResponseType(200,Type=typeof(DTO_PM))]
        public async Task<IActionResult> GetPatientByName(string username)
        {
           PatientsRegistory Patients = await PatientRepository.GetAsync(username);
            var DTO = mapper.Map<DTO_PM>(Patients);
            
            return Ok(DTO);

        }
        [HttpPost("AddPatient")]
        [ProducesResponseType(201, Type = typeof(DTO_PM))]
        public async Task<IActionResult> Post(DTO_PM model)
        {
          PatientsRegistory patient = mapper.Map<PatientsRegistory>(model);
            PatientRepository.Add(patient);
            await PatientRepository.SaveAsync();
            var dto = mapper.Map<DTO_PM>(patient);
            return  StatusCode(201,dto);

        }
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(DTO_PM))]
        public async Task<IActionResult> Put(DTO_PM model)
        {
            PatientsRegistory patient = mapper.Map<PatientsRegistory>(model);
            PatientRepository.Update(patient);
            await PatientRepository.SaveAsync();
            var dto = mapper.Map<DTO_PM>(patient);
            return Ok(dto);

        }

        [HttpDelete]
        [Route("{username}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(string username)
        {
            PatientsRegistory patient = new PatientsRegistory { Username= username };
            PatientRepository.Delete(patient);
            await PatientRepository.SaveAsync();
            return NoContent();

        }
    }
}
