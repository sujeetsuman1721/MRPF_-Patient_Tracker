using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecuringApplication.Models;
using SecuringApplication.Models.Registration;
using SecuringApplication.Reposetory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecuringApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecuringApplication : ControllerBase
    {
      


        private readonly IReposetory<Patient> patientsRepository;
        private readonly IReposetory<Doctor> doctorsRepository;
        private readonly IReposetory<Clerk> clerksRepository;


        public SecuringApplication(
       
          IReposetory<Patient> patientsRepository,
          IReposetory<Doctor> doctorsRepository,
          IReposetory<Clerk> clerksRepository)

        {
            this.patientsRepository = patientsRepository;
            this.doctorsRepository = doctorsRepository;
            this.clerksRepository = clerksRepository;
        }


        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<DoctorModel>))]

        //public async Task<IActionResult> GetPatients()
        //{
        //    IEnumerable<DoctorModel> doctor = await doctorsRepository.GetAsync();

        //    var DTOs = mapper.Map<List<DoctorModel>>(DoctorModel);

        //    return Ok(DTOs);
        //}

        //public async Task<IActionResult> GetDoctors()
        //{
        //    IEnumerable<DoctorModel> hospital = await hospitalRepository.GetAsync();

        //    var DTOs = mapper.Map<List<DoctorModel>>(hospital);
        //    return Ok(DTOs);
        //}




    }
}
