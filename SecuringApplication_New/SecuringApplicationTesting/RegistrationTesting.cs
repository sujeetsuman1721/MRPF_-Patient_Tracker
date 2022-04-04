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
               var Patient = new PatientModel("sam", "Sahaaaaa" , "saru", "female", "hyd", "1234567890","Sahaaaaa");
               Assert.That(Patient, Is.Not.Null);
           }




        [Test]
        [TestCase( "sara", "Sararahu", "saru", "female", "hyd", "1234567890","")]
        [TestCase( "", "Sararahu", "rahu", "", "chennai", "","Sararahu")]
        [TestCase( "", null, null, null, "hyd", "1234567890",null)]
        public void Throw_ArgumentException_For_Invalid_Input(string userName, string password, string firstName,string gender, string address, string contactNumber,string conformPassword)
        {
            Assert.Throws<ArgumentException>(() => new PatientModel(userName, password, firstName, gender, address, contactNumber, conformPassword));
        }





        [Test]
        public void Changes_UserName_To_NewUserName()
        {
            var patient = new PatientModel("sara", "Sararahu", "saru", "female", "hyd", "1234567890","Sararahu");
            patient.ChangeUserName("rama");
            Assert.That(patient.UserName, Is.EqualTo("rama"));
        }





        [Test]
        public void ConfirmPassword_matchesToThe_Password()
        {
            var patient = new PatientModel("sara", "Sararahu", "saru", "female", "hyd", "1234567890", "Sararahu");
            patient.ConfirmsNewPassword("Sararahu");
            Assert.That(patient.ConfirmPassword, Is.EqualTo("Sararahu"));
        }
    }
}


}
