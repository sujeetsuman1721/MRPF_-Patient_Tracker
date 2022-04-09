using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit;
using NUnit.Framework;
using SecuringApplication.Models;
using SecuringApplication.Models.Login;
using System.Linq;

namespace AccessUserController.Test
{
    [TestFixture]
    public class MemersServices
    {
        UserServices SUT;

        Mock<UserManager<ApplicationUser>> MockUserManager;

        Mock<ApplicationContext> MockAppContext;


        [SetUp]
        public void init()
        {
           // SUT = new UserServices(MockUserManager,Mo);

            MockUserManager = new Mock<UserManager<ApplicationUser>>();
            MockAppContext = new Mock<ApplicationContext>();
            SUT = new UserServices(MockUserManager.Object, MockAppContext.Object);
        }
        [TearDown]
        public void cleanUp()
        {
            MockUserManager= null;
            MockAppContext= null;
        }

        [Test]
        public void FetchNewRegistrationsTest()
        {

            var Admin = new ApplicationUser
            {
                UserName = "Sujeet@123",
                FirstName = "Sujeet",
                LastName = "Suman",
                Address = "Kolkata",
                Gender = "Male",
                PhoneNumber = "8340493413",
                PasswordHash = "Sujeet@123",
                SecretQuestions = "What is your Name ?",
                Answer = "Sujeet Suman",
                RegistratioStatus = RegistrationStatus.ACCEPTED



            };

            var newReg=SUT.FetchNewRegistrations();

            var model = (newReg) as List<ApplicationUser>;

            CollectionAssert.AreEqual(model, new List<ApplicationUser>());



        }

    }
}
