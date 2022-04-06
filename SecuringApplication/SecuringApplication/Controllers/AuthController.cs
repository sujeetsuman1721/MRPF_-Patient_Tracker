using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SecuringApplication.Models;
using SecuringApplication.Models.DTOs;
using SecuringApplication.Models.Login;
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
        public async Task<Response> Register(DoctorModel model)
        {
            Response response = new Response();

            try
            {
                var userExists = await userManager.FindByNameAsync(model.UserName);


                if (userExists != null)
                {

                    if (userExists.RegistratioStatus == RegistrationStatus.DENIED)
                    {
                        response.Status = RegistrationStatus.DENIED;
                        response.Message = "You cannot register again as your previous registration request with this credentials is denied by admin";

                        return response;
                    }

                    response.Status = "ERROR";
                    response.Message = "User already exists";

                    return response;
                }
                else
                {
                    ApplicationUser appUser = new ApplicationUser
                    {


                        UserName = model.UserName,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Address,
                        Gender = model.Gender,
                        PhoneNumber = model.ContactNumber,
                        PasswordHash = model.Password,
                        SecretQuestions = model.SecretQuestions,
                        Answer = model.Answer,
                        RegistratioStatus = RegistrationStatus.INPROGRESS
                    };


                    IdentityResult result = await userManager.CreateAsync(appUser, model.Password);

                    if (result.Succeeded)
                    {
                        if (!await roleManager.RoleExistsAsync("Doctor"))
                            await roleManager.CreateAsync(new IdentityRole { Name = "Doctor" });


                        result = await userManager.AddToRoleAsync(appUser, "Doctor");


                        Doctor doctor = new Doctor();


                        doctor.ApplicationUser = appUser;

                        doctor.Qualification = model.Qualification;
                        doctor.Specialization = model.Specialization;


                        doctorsRepository.Add(doctor);
                        await doctorsRepository.SaveAsync();


                        response.Status = "SUCCESS";
                        response.Message = "Your registration is completed!";

                        return response;
                    }
                    else
                    {
                        response.Status = "ERROR";
                        response.Message = "Your registration is failed!";

                        return response;
                    }

                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }




        [HttpPost("PatientRegister")]
        public async Task<Response> Register(PatientModel model)
        {


            Response response = new Response();

            try
            {
                var userExists = await userManager.FindByNameAsync(model.UserName);


                if (userExists != null)
                {

                    if (userExists.RegistratioStatus == RegistrationStatus.DENIED)
                    {
                        response.Status = RegistrationStatus.DENIED;
                        response.Message = "You cannot register again as your previous registration request with this credentials is denied by admin";

                        return response;
                    }

                    response.Status = "ERROR";
                    response.Message = "User already exists";

                    return response;
                }
                else
                {
                    ApplicationUser appUser = new ApplicationUser
                    {


                        UserName = model.UserName,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Address,
                        Gender = model.Gender,
                        PhoneNumber = model.ContactNumber,
                        PasswordHash = model.Password,
                        SecretQuestions = model.SecretQuestions,
                        Answer = model.Answer,
                        RegistratioStatus = RegistrationStatus.INPROGRESS
                    };


                    IdentityResult result = await userManager.CreateAsync(appUser, model.Password);

                    if (result.Succeeded)
                    {

                        if (!await roleManager.RoleExistsAsync("Patient"))
                            await roleManager.CreateAsync(new IdentityRole { Name = "Patient" });

                        result = await userManager.AddToRoleAsync(appUser, "Patient");


                        Patient patient = new Patient();

                        patient.ApplicationUser = appUser;

                        patientsRepository.Add(patient);
                        await patientsRepository.SaveAsync();

                        response.Status = "SUCCESS";
                        response.Message = "Your registration is completed!";

                        return response;
                    }
                    else
                    {
                        response.Status = "ERROR";
                        response.Message = "Your registration is failed!";

                        return response;
                    }

                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }



        [HttpPost("ClerkRegister")]
        public async Task<Response> Register(ClerkModel model)
        {

            Response response = new Response();

            try
            {
                var userExists = await userManager.FindByNameAsync(model.UserName);


                if (userExists != null)
                {

                    if (userExists.RegistratioStatus == RegistrationStatus.DENIED)
                    {
                        response.Status = RegistrationStatus.DENIED;
                        response.Message = "You cannot register again as your previous registration request with this credentials is denied by admin";

                        return response;
                    }

                    response.Status = "ERROR";
                    response.Message = "User already exists";

                    return response;
                }
                else
                {
                    ApplicationUser appUser = new ApplicationUser
                    {


                        UserName = model.UserName,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Address,
                        Gender = model.Gender,
                        PhoneNumber = model.ContactNumber,
                        PasswordHash = model.Password,
                        SecretQuestions = model.SecretQuestions,
                        Answer = model.Answer,
                        RegistratioStatus = RegistrationStatus.INPROGRESS
                    };


                    IdentityResult result = await userManager.CreateAsync(appUser, model.Password);

                    if (result.Succeeded)
                    {

                        if (!await roleManager.RoleExistsAsync("Clerk"))
                            await roleManager.CreateAsync(new IdentityRole { Name = "Clerk" });

                        result = await userManager.AddToRoleAsync(appUser, "Clerk");


                        Clerk clerk = new Clerk();

                        clerk.ApplicationUser = appUser;

                        clerksRepository.Add(clerk);
                        await clerksRepository.SaveAsync();

                        response.Status = "SUCCESS";
                        response.Message = "Your registration is completed!";

                        return response;
                    }
                    else
                    {
                        response.Status = "ERROR";
                        response.Message = "Your registration is failed!";

                        return response;
                    }

                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }




        [HttpPost("login")]
        public async Task<Response> Login(UserLogin model)
        {

            Response response = new Response();

            try
            {
                var user = await userManager.FindByNameAsync(model.UserName);

                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await userManager.GetRolesAsync(user);



                    if (user.RegistratioStatus == RegistrationStatus.DENIED)
                    {
                        response.Status = RegistrationStatus.DENIED;
                        response.Message = "You cannot login with your credentials as your registration request is denied by admin";

                        return response;
                    }

                    if (user.RegistratioStatus == RegistrationStatus.INPROGRESS)
                    {
                        response.Status = RegistrationStatus.INPROGRESS;
                        response.Message = "You can login with your credentials if and only if your registration request is accepted by admin";

                        return response;
                    }
                }


                string key = configuration["JwtSettings:Key"];
                string issuer = configuration["JwtSettings:Issuer"];
                string audience = configuration["JwtSettings:Audience"];
                int durationInMinutes = int.Parse(configuration["JwtSettings:DurationInMinutes"]);

                IList<Claim> userClaims = await userManager.GetClaimsAsync(user);

                userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserName));

                var roles = await userManager.GetRolesAsync(user);

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
                var Auth = new LoginResponse { Jwt = token, UserName = user.UserName, UserRole = roles.First(), UserId = 0 };


                if (Auth.UserRole == "Patient")
                {
                    Auth.UserId = await patientsRepository.GetByUserId(user.Id);
                }
                if (Auth.UserRole == "Doctor")
                {
                    Auth.UserId = await doctorsRepository.GetByUserId(user.Id);
                }

                response.AuthData = Auth;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = "Not able to Login";
            }
            return response;
        }
            
    }
}
