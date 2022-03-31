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
        private readonly IReposetory<Patient> patientsRepository;
        private readonly IReposetory<Doctor> doctorsRepository;
        private readonly IReposetory<Clerk> clerksRepository;


        public AccessUsersController(
       
          IReposetory<Patient> patientsRepository,
          IReposetory<Doctor> doctorsRepository,
          ApplicationContext context,
          IReposetory<Clerk> clerksRepository)

        {
            this.context = context;
            this.patientsRepository = patientsRepository;
            this.doctorsRepository = doctorsRepository;
            this.clerksRepository = clerksRepository;
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
            IEnumerable<Patient> patients = await context.Patiennt.Include(x => x.ApplicationUser).ToListAsync();


            return Ok(patients);
        }


    }
}
