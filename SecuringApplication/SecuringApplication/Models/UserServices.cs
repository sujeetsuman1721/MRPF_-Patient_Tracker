using Microsoft.AspNetCore.Identity;
using SecuringApplication.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuringApplication.Models
{
    public class UserServices
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationContext context;

        public UserServices(UserManager<ApplicationUser> userManager,  ApplicationContext context)
            {
                _userManager = userManager;
            this.context = context;
            

               
            }

            public List<ApplicationUser> FetchNewRegistrations()
            {
                List<ApplicationUser> newRegistrations = new List<ApplicationUser>();

               newRegistrations = _userManager.Users.Where(user => user.RegistratioStatus == RegistrationStatus.INPROGRESS).ToList<ApplicationUser>();

               return newRegistrations;

            }

        public async Task<bool> ApproveUser(string username, string registrationStatus)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);

                user.RegistratioStatus = registrationStatus;
                context.SaveChanges();

                

                return true;
            }

            catch(Exception ex)
            {
                return false;
            }



        }




        }
    }
