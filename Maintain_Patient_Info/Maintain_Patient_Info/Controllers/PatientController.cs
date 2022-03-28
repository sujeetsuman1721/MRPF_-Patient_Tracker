using AutoMapper;
using Maintain_Patient_Info.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IRepository<patient_info> PatientRepository;
        private readonly IMapper mapper;
        public PatientController(IRepository<patient_info> PatientRepository , IMapper mapper)
        {
           this.PatientRepository = PatientRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<DTO_PM>))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<patient_info> patient = await PatientRepository.GetAsync();

            var DTOs = mapper.Map<List<DTO_PM>>(patient); 
            return Ok(DTOs);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(DTO_PM))]
        public async Task<IActionResult> Post(patient_info model)
        {
          //  patient_info patient = mapper.Map<patient_info>(model);
            PatientRepository.add(model);
            await PatientRepository.SaveAsync();
           
            return  StatusCode(201);

        }
        [HttpPut]
        [ProducesResponseType(202, Type = typeof(DTO_PM))]
        public async Task<IActionResult> Put(DTO_PM model)
        {
            patient_info patient = mapper.Map<patient_info>(model);
            PatientRepository.update(patient);
            await PatientRepository.SaveAsync();
            var dto = mapper.Map<DTO_PM>(patient);
            return Ok(dto);

        }

        [HttpDelete]
        [Route("{patientId}")]
        [ProducesResponseType(203)]
        public async Task<IActionResult> Delete(int patientId)
        {
            patient_info patient = new patient_info { Id = patientId };
            PatientRepository.delete(patient);
            await PatientRepository.SaveAsync();
            return NoContent();

        }

    }
}
