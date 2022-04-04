using AutoMapper;
using Billing_Services.DTO;
using Billing_Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : Controller
    {
        private readonly IRepository<BillingServices> BillingRepository;
        private readonly IMapper mapper;
        public BillingController(IRepository<BillingServices> BillingRepository, IMapper mapper)
        {
            this.BillingRepository = BillingRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("[action]/{appointmentId}")]
        [ProducesResponseType(200, Type = typeof(BillingDTO))]
        public async Task<IActionResult> GetChargesFromAppointMentId (int appointmentId)
        {
              var bill=await BillingRepository.GetBillyAppointId(appointmentId);

            
            return Ok(bill);
        }
        [HttpPost("Charges")]
        [ProducesResponseType(201, Type = typeof(BillingDTO))]
        public async Task<IActionResult> Post(BillingServices model)
        {
            
      
            BillingRepository.Add(model);
            await BillingRepository.SaveAsync();

            return StatusCode(201, model);

        }
    }
}