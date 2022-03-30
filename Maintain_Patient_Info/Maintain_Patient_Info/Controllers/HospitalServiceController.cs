/*using AutoMapper;
using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.HospitalServices;
using Maintain_Patient_Info.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalServiceController : Controller
    {
        private readonly IRepository<LabTests> labtestsRepository;
        private readonly IRepository<PrescriptionDetails> prescriptionRepository;
        private readonly IRepository<Consultation> consultationRepository;
        private readonly IRepository<Room> roomRepository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        public HospitalServiceController(IRepository<LabTests> labtestsRepository, IRepository<PrescriptionDetails> prescriptionRepository,
            IRepository<Consultation> consultationRepository,IRepository<Room> roomRepository,IConfiguration configuration,
            IMapper mapper)
        {
            this.labtestsRepository= labtestsRepository;
            this.prescriptionRepository = prescriptionRepository;
            this.consultationRepository = consultationRepository;
            this.roomRepository = roomRepository;
            this.configuration = configuration;
            this.mapper = mapper;
        }
        [HttpGet("LabTests")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LabTestsDTO>))]
        public async Task<IActionResult> GetLabTestDetails()
        {
            IEnumerable<LabTests> labTests = await labtestsRepository.GetAsync();
            var DTOs = mapper.Map<List<LabTestsDTO>>(labTests);
            return Ok(DTOs);
        }
        [HttpPost("LabTests")]
        [ProducesResponseType(201, Type = typeof(LabTestsDTO))]
        public async Task<IActionResult> PostLabTestDetails(LabTestsDTO model)
        {
            LabTests labTests = mapper.Map<LabTests>(model);
            labtestsRepository.Add(labTests);
            await labtestsRepository.SaveAsync();
            var dto = mapper.Map<LabTestsDTO>(labTests);
            return StatusCode(201, dto);
        }
        [HttpGet("PrescriptionDetails")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PrescriptionDTO>))]
        public async Task<IActionResult> GetPrescriptionDetails()
        {
            IEnumerable<PrescriptionDetails> prescription = await prescriptionRepository.GetAsync();
            var DTOs = mapper.Map<List<PrescriptionDTO>>(prescription);
            return Ok(DTOs);
        }
        [HttpPost("PrescriptionDetails")]
        [ProducesResponseType(201, Type = typeof(PrescriptionDTO))]
        public async Task<IActionResult> PostPrescriptionDetails(PrescriptionDTO model)
        {
            PrescriptionDetails prescription = mapper.Map<PrescriptionDetails>(model);
            prescriptionRepository.Add(prescription);
            await prescriptionRepository.SaveAsync();
            var dto = mapper.Map<PrescriptionDetails>(prescription);
            return StatusCode(201, dto);
        }
        [HttpGet("ConsultationDetails")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ConsultationDTO>))]
        public async Task<IActionResult> GetConsultationDetails()
        {
            IEnumerable<Consultation> consultation = await consultationRepository.GetAsync();
            var DTOs = mapper.Map<List<ConsultationDTO>>(consultation);
            return Ok(DTOs);
        }
        [HttpPost("ConsultationDetails")]
        [ProducesResponseType(201, Type = typeof(ConsultationDTO))]
        public async Task<IActionResult> PostConsultationDetails(ConsultationDTO model)
        {
            Consultation consultation = mapper.Map<Consultation>(model);
            consultationRepository.Add(consultation);
            await prescriptionRepository.SaveAsync();
            var dto = mapper.Map<Consultation>(consultation);
            return StatusCode(201, dto);
        }
        [HttpGet("RoomDetails")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RoomDTO>))]
        public async Task<IActionResult> GetRoomDetails()
        {
            IEnumerable<Room> room = await roomRepository.GetAsync();
            var DTOs = mapper.Map<List<RoomDTO>>(room);
            return Ok(DTOs);
        }
        [HttpPost("RoomDetails")]
        [ProducesResponseType(201, Type = typeof(RoomDTO))]
        public async Task<IActionResult> PostRoomDetails(RoomDTO model)
        {
            Room room = mapper.Map<Room>(model);
            roomRepository.Add(room);
            await roomRepository.SaveAsync();
            var dto = mapper.Map<Room>(room);
            return StatusCode(201, dto);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}*/
