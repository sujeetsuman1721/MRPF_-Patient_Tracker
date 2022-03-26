using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SecuringApplication.Models;
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
    public class DoctersAuthController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;



        public DoctersAuthController(UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Patient model)
        {

            ApplicationUser appUser = new ApplicationUser
            {

                UserName = model.ApplicationUser.UserName,
                FirstName = model.ApplicationUser.FirstName,
                LastName = model.ApplicationUser.LastName,
                Address = model.ApplicationUser.Address,
                Gender = model.ApplicationUser.Gender,
                ContactNumber = model.ApplicationUser.ContactNumber,
                Password = model.ApplicationUser.Password,
                ConfirmPassword = model.ApplicationUser.ConfirmPassword,
                SecretQuestions = model.ApplicationUser.SecretQuestions,
                Answer = model.ApplicationUser.Answer

            };


            IdentityResult result = await userManager.CreateAsync(appUser, model.ApplicationUser.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            if (!await roleManager.RoleExistsAsync("Doctor"))
                await roleManager.CreateAsync(new IdentityRole { Name = "Doctor" });

            result = await userManager.AddToRoleAsync(appUser, "Doctor");



            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin model)
        {
            //IdentityUser appUser = await userManager.FindByNameAsync(model.Username);
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

