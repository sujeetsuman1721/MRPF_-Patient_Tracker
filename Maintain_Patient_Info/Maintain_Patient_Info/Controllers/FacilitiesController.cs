using AutoMapper;
using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : Controller
    {
       
        private readonly IRepository<Facilites> facilitiesRepository;
        private readonly IMapper mapper;
        public FacilitiesController(IRepository<Facilites> facilitiesRepository, IMapper mapper)
        {
            this.facilitiesRepository = facilitiesRepository;
            this.mapper = mapper;
        }
        [HttpGet("FacilitiesInfo")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FacilitiesDTO>))]
        public async Task<IActionResult> GetFacilities()
        {
            IEnumerable<Facilites> facilities = await facilitiesRepository.GetAsync();

            var DTOs = mapper.Map<List<FacilitiesDTO>>(facilities);
            return Ok(DTOs);
        }
        [HttpPost("AddFacility")]
        [ProducesResponseType(200, Type = typeof(FacilitiesDTO))]
        public async Task<IActionResult> Post(FacilitiesDTO model)
        {
            Facilites facility = mapper.Map<Facilites>(model);
            facilitiesRepository.Add(facility);
            await facilitiesRepository.SaveAsync();
            var dto = mapper.Map<FacilitiesDTO>(facility);

            return StatusCode(200, dto);

        }
        [HttpGet]
        [Route("[action]/{appointmentId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FacilitiesDTO>))]

        public async Task<IActionResult> GetFacilityByAppontmentId(int appointmentId)
        {

            var facility = await facilitiesRepository.GetAsyncBYId(appointmentId);

            

         

            return Ok(facility);
        }



    }
}
