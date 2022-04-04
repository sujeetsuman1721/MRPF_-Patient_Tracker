using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using SecuringApplication.Models.Login;
using Microsoft.EntityFrameworkCore.Internal;

namespace SecuringApplication.Models
{
    public class UserLogin : BaseEntity, IAggergateService
    {
        public virtual string UserName { get; set; }
        public virtual  string Password { get; set; }


        public UserLogin(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException($"Invalid value for : ${nameof(userName)}");


            if (string.IsNullOrEmpty(password) && !password.StartsWith("uppercase letter") && ! password.Contains("lowercase letter")|| !password.Length.Equals(8)) 
            throw new ArgumentException($"Invalid value for : ${nameof(password)}");


            this.UserName = userName;
            this.Password = password;

         }
       

           public class Loginsuccessful : IAggergateService
           {
                public bool DoLogin(string userName, string password)
                   {
                      if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                         return false;

                         return true;
                    }

            }

      }
}


      
    





