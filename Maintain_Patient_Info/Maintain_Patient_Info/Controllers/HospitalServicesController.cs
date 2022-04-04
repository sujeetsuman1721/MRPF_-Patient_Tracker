using AutoMapper;
using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.HospitalServices;
using Maintain_Patient_Info.Infrastructure;
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
    public class HospitalServicesController : Controller
    {
        private readonly PatientManagementContext context;
        private readonly IRepository<LabTests> labtestsrepository;
        private readonly IRepository<Consultation> consultationRepository;
        private readonly IRepository<Room> roomRepository;
        private readonly IMapper mapper;

        public HospitalServicesController(PatientManagementContext context,IMapper mapper,
            IRepository<LabTests> labtestsrepository,
            IRepository<Consultation> consultationRepository,
            IRepository<Room> roomRepository)

        {
            this.context = context;
            this.labtestsrepository = labtestsrepository;
            this.consultationRepository = consultationRepository;
            this.roomRepository = roomRepository;
            this.mapper = mapper;
        }
        [HttpGet("LabTests")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LabTestsDTO>))]
        public async Task<IActionResult> GetLabTests()
        {
            IEnumerable<LabTests> labTests = await labtestsrepository.GetAsync();

            var DTOs = mapper.Map<List<LabTestsDTO>>(labTests);
            return Ok(DTOs);
        }
        [HttpGet("RoomDetails")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RoomDTO>))]
        public async Task<IActionResult> GetRoomDetails()
        {
            IEnumerable<Room> rooms = await roomRepository.GetAsync();

            var DTO = mapper.Map<List<RoomDTO>>(rooms);
            return Ok(DTO);
        }
        [HttpGet("ConsultationDetails")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ConsultationDTO>))]
        public async Task<IActionResult> GetConsultationDetails()
        {
            IEnumerable<Consultation> consultants = await consultationRepository.GetAsync();

            var dto = mapper.Map<List<ConsultationDTO>>(consultants);
            return Ok(dto);
        }

        [HttpGet("GetByRoomId")]
        [ProducesResponseType(200, Type = typeof(RoomDTO))]

        public async Task<IActionResult> GetRoomById(int roomId)
        {

            IEnumerable<Room> rooms = await roomRepository.GetAsync();

            var room = rooms
                   .Where(r => r.RoomId == roomId);


            return Ok(room);
        }

        [HttpGet("GetByLabId")]
        [ProducesResponseType(200, Type = typeof(LabTestsDTO))]

        public async Task<IActionResult> GetByLabId(int LabTestId)
        {

            IEnumerable<LabTests> labTests = await labtestsrepository.GetAsync();

            var labTest = labTests
                   .Where(l => l.LabTestId == LabTestId);


            return Ok(labTest);
        }

        [HttpGet("GetConsultationById")]
        [ProducesResponseType(200, Type = typeof(ConsultationDTO))]

        public async Task<IActionResult> GetConsultationById(int consultationId)
        {

            IEnumerable<Consultation> consultants = await consultationRepository.GetAsync();

            var consultant = consultants
                   .Where(co => co.ConsultationId == consultationId);


            return Ok(consultant);
        }





    }
}
