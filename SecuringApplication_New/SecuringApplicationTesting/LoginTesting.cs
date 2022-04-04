using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using SecuringApplication.Models;
using SecuringApplication.Models.Login;
using static SecuringApplication.Models.UserLogin;
using Microsoft.AspNetCore.Authentication;

namespace SecuringApplicationTesting
{
    [TestFixture]
    public class LoginTesting
    {
         [Test]
          public void  SameUsers_Login()
           {
             var user1 = new UserLogin( "vana", "Jhan");
             var user2 = new  UserLogin("vana" , "Jhan");

             user1.UserName= "vana";
             user2.UserName = "vana";
        
             var result = user1.Equals(user2);

             Assert.That(result ,Is.True );

            }
        
       



            [TestCase("khan", "")]
            [TestCase("khan", null)]
            [TestCase("", "khan123")]
            [TestCase(null, "khan123")]
            [TestCase("", "")]
            public void Throw_ArgumentException_For_Invalid_Input(string username, string password)
             {
                Assert.Throws<ArgumentException>(() => new UserLogin(username, password));
             }


            [Test]
            public void user_login_successfully()
            {
                var login = new Loginsuccessful();
                bool result = login.DoLogin("test", "test");
                Assert.IsTrue(result);
            }
       
        

        }

    }









    
