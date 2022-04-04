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
             var user1 = new UserLogin( "John", "John@123");
             var user2 = new  UserLogin("John" , "John@123");

            user1.Id = 10;
            user2.Id = 10;
        
             var result = user1.Equals(user2);
             Assert.That(result ,Is.True );
          }


        [Test]
        public void Login_WillNotEmpty()
          {
            var Patient = new UserLogin("Hani", "HaniHani");
            Assert.That(Patient, Is.Not.Null);
          }






            [TestCase("khan", "")]
            [TestCase("",null )]
            [TestCase("", "khan1234")]
            [TestCase(null, "khan1234")]
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









    
