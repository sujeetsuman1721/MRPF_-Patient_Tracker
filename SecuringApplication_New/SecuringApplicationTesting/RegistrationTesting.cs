using NUnit.Framework;
using SecuringApplication.Models;
using SecuringApplication.Models.Registration; 
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuringApplicationTesting
{
    [TestFixture]
   public  class RegistrationTesting
    {
        
           [Test]
           public void patientRegistry_WillNotEmpty()
           {
               var Patient = new PatientModel("RamJog", "Ram@2323" , "Ram", "male", "hyderabad", "8899787878","Ram@2323");
               Assert.That(Patient, Is.Not.Null);
           }



        [Test]
        [TestCase( "sara", "Sararahu", "sara", "", "hyderabad", "9878978776","")]
        [TestCase( "", "Sararahu", "rahu", "" ,"chennai", "","Sararahu")]
        [TestCase( "sara", "", "sara", "", "hyderabad", "","")]
        public void Throw_ArgumentException_For_Invalid_Input(string userName, string password, string firstName,string gender, string address, string contactNumber,string conformPassword)
        {
            Assert.Throws<ArgumentException>(() => new PatientModel(userName, password, firstName, gender, address, contactNumber, conformPassword));
        }





        [Test]
        public void Changes_UserName_To_NewUserName()
        {
            var patient = new PatientModel("varma", "Varma123", "varma", "male", "hyderabad", "9988979078","Varma123");
            patient.ChangeUserName("sarma");
            Assert.That(patient.UserName, Is.EqualTo("sarma"));
        }





        [Test]
        public void ConfirmPassword_matchesToThe_Password()
        {
            var patient = new PatientModel("sara", "Samsunder", "saru", "female", "hyderabad", "7878786767", "Samsunder");
            patient.ConfirmsNewPassword("Samsunder");
            Assert.That(patient.ConfirmPassword, Is.EqualTo("Samsunder"));
        }
    }
}



