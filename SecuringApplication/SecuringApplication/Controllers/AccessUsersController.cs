using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecuringApplication.Models;
using SecuringApplication.Models.Registration;
using SecuringApplication.Reposetory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecuringApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessUsersController : ControllerBase
    {


        private readonly ApplicationContext context;
  


        public AccessUsersController(ApplicationContext context  )

        {
            this.context = context;
      
        }

        [HttpGet("GetDoctors")]
        public async Task<IActionResult> GetDoctors()
        {
            IEnumerable<Doctor> doctor = await context.Doctor.Include(x => x.ApplicationUser).ToListAsync();


            return Ok(doctor);
        }

        [HttpGet("GetPatients")]

        public async Task<IActionResult> GetPatient()
        {
            IEnumerable<Patient> patients = await context.Patient.Include(x => x.ApplicationUser).ToListAsync();


            return Ok(patients);
        }




    }
}
