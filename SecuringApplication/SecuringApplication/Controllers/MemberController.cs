using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecuringApplication.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecuringApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
     
        private readonly UserServices _membersService;

        public MemberController(UserServices membersService)
        {

           
            _membersService = membersService;
        }

        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ApplicationUser>))]
        public IActionResult GetNewRegistrations()
        {
            try
            {
                var newRegistrations = _membersService.FetchNewRegistrations();

                if (newRegistrations != null)
                    return Ok(newRegistrations);

                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return BadRequest();
            }
        }
        [HttpPost("{username}/{registrationStatus}")]
        public async Task<IActionResult> ApproveUser(string username, string registrationStatus)
        {
            try
            {
                var val = await _membersService.ApproveUser(username, registrationStatus);


                if (val) return Ok(val);

                else return BadRequest();



            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        }
    }
