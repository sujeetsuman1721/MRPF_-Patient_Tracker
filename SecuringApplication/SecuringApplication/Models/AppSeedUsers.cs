using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SecuringApplication.Models
{
    public class AppSeedUsers
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AppSeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedUsersAsync()
        {
            

           await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });



            

            if (!userManager.Users.Any())
            {
                var Admin = new ApplicationUser
                {
                    UserName = "Sujeet@12",
                    FirstName = "Sujeet",
                    LastName = "Suman",
                    Address = "Kolkata",
                    Gender = "Male",
                    PhoneNumber = "8340493413",
                    PasswordHash = "Sujeet@123",
                    SecretQuestions = "What is your Name ?",
                    Answer = "Sujeet Suman"



                };


                await userManager.CreateAsync(Admin, "Sujeet@123");
                await userManager.AddToRoleAsync(Admin, "Admin");

            }
        }
    }
}
