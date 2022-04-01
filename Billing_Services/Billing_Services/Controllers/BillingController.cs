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
        [HttpGet("GetCharges")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BillingDTO>))]
        public async Task<IActionResult> GetCharges()
        {
            IEnumerable<BillingServices> billing = await BillingRepository.GetAsync();

            var DTOs = mapper.Map<List<BillingDTO>>(billing);
            return Ok(DTOs);
        }
        [HttpPost("Charges")]
        [ProducesResponseType(200, Type = typeof(BillingDTO))]
        public async Task<IActionResult> Post(BillingServices model)
        {
            BillingRepository.Add(model);
            await BillingRepository.SaveAsync();

            return StatusCode(200, model);

        }
    }
}
