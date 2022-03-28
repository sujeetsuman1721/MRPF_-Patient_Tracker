using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SecuringApplication.Models;
using SecuringApplication.Models.Registration;
using SecuringApplication.Reposetory;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SecuringApplication.Controllers
{
    


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;


        private readonly IReposetory<Patient> patientsRepository;
        private readonly IReposetory<Doctor> doctorsRepository;
        private readonly IReposetory<Clerk> clerksRepository;


        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,

          IConfiguration configuration,
          IReposetory<Patient> patientsRepository,
          IReposetory<Doctor> doctorsRepository,
          IReposetory<Clerk> clerksRepository)

        {

        
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.patientsRepository = patientsRepository;
            this.doctorsRepository = doctorsRepository;
            this.clerksRepository = clerksRepository;
        }

        [HttpPost("DoctorRegister")]
        public async Task<IActionResult> Register(DoctorModel model)
        {

            ApplicationUser appUser = new ApplicationUser
            {

                UserName = model.FirstName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Gender = model.Gender,
                PhoneNumber = model.ContactNumber,
                PasswordHash = model.Password,
               SecretQuestions = model.SecretQuestions,
               Answer = model.Answer

           };


            IdentityResult result = await userManager.CreateAsync(appUser, model.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            if (!await roleManager.RoleExistsAsync("Doctor"))
                await roleManager.CreateAsync(new IdentityRole { Name = "Doctor" });

            result = await userManager.AddToRoleAsync(appUser, "Doctor");

             Doctor doctor= new Doctor();
            

            doctor.ApplicationUser = appUser;
            doctor.DoctorId = model.DoctorId;
            doctor.Qualification=model.Qualification;
            doctor.Specialization=model.Specialization;


            doctorsRepository.Add(doctor);
            await doctorsRepository.SaveAsync();



            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("PatientRegister")]
        public async Task<IActionResult> Register(PatientModel model)
        {

            ApplicationUser appUser = new ApplicationUser
            {

                UserName = model.FirstName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Gender = model.Gender,
                PhoneNumber = model.ContactNumber,
                PasswordHash = model.Password,
                SecretQuestions = model.SecretQuestions,
                Answer = model.Answer

            };


            IdentityResult result = await userManager.CreateAsync(appUser, model.Password);
            
            if (!result.Succeeded) return BadRequest(result.Errors);

            if (!await roleManager.RoleExistsAsync("Patient"))
                await roleManager.CreateAsync(new IdentityRole { Name = "Patient"});

            result = await userManager.AddToRoleAsync(appUser, "Patient");


            Patient  patient = new Patient();

            patient.ApplicationUser = appUser;
            patient.PatientId = model.PateintId;

            patientsRepository.Add(patient);
            await patientsRepository.SaveAsync();


            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }





        [HttpPost("ClerkRegister")]
        public async Task<IActionResult> Register(ClerkModel model)
        {

            ApplicationUser appUser = new ApplicationUser
            {
                UserName = model.FirstName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Gender = model.Gender,
                PhoneNumber = model.ContactNumber,
                PasswordHash = model.Password,
                SecretQuestions = model.SecretQuestions,
                Answer = model.Answer

            };


            IdentityResult result = await userManager.CreateAsync(appUser, model.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            if (!await roleManager.RoleExistsAsync("Clerk"))
                await roleManager.CreateAsync(new IdentityRole { Name = "Clerk" });

            result = await userManager.AddToRoleAsync(appUser, "Clerk");

            Clerk clerk = new Clerk();


            clerk.ApplicationUser = appUser;
            clerk.ClerkId = model.ClerkId;



            clerksRepository.Add(clerk);
            await clerksRepository.SaveAsync();


            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin model)
        {
            
            ApplicationUser appUser = await userManager.FindByNameAsync(model.UserName);



            if (appUser == null) return BadRequest("Invalid username/password");

            bool isValid = await userManager.CheckPasswordAsync(appUser, model.Password);

            if (!isValid) return BadRequest("Invalid username/password");


            string key = configuration["JwtSettings:Key"];
            string issuer = configuration["JwtSettings:Issuer"];
            string audience = configuration["JwtSettings:Audience"];
            int durationInMinutes = int.Parse(configuration["JwtSettings:DurationInMinutes"]);

            IList<Claim> userClaims = await userManager.GetClaimsAsync(appUser);

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, appUser.UserName));

            var roles = await userManager.GetRolesAsync(appUser);

            userClaims.Add(new Claim(ClaimTypes.Role, roles.First()));

            byte[] keyBytes = System.Text.Encoding.ASCII.GetBytes(key);
            SecurityKey securityKey = new SymmetricSecurityKey(keyBytes);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(durationInMinutes),
                signingCredentials: signingCredentials,
                claims: userClaims
                );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(jwtSecurityToken);
            var response = new { jwt = token, name = appUser.UserName, role = roles.First() };
            return Ok(response);
        }


    }
}
