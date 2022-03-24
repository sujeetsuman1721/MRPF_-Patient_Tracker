using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SecuringApplication.Models;
using System.Threading.Tasks;

namespace SecuringApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;



        public PatientAuthController(UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(PatienntRegistrationModel model)
        {
            
           ApplicationUser appUser = new ApplicationUser
            {
               UserName = model.FirstName,
               FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Gender = model.Gender,
                ContactNumber = model.ContactNumber,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                SecretQuestions = model.SecretQuestions,
                Answer = model.Answer

            };


            IdentityResult result = await userManager.CreateAsync(appUser, model.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            if (!await roleManager.RoleExistsAsync("Patient"))
                await roleManager.CreateAsync(new IdentityRole { Name = "Patient" });

            result = await userManager.AddToRoleAsync(appUser, "Patient");

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }


        }
}
