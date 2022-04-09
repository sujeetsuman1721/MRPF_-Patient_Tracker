using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Billing_Services;

namespace Billing
{
    [TestFixture]
   public class Billing
    {
        [Test]
        public void Patients_WithSame_AppointmentIds_MustBeEqual()
        {
            var patient1 = new Bill(1,1,200,300,350,850);
            var patient2 = new Bill(2,2,100,400,600,1100);

            patient1.Id = 101;
            patient2.Id = 102;

            var result = patient1.Equals(patient2);
            Assert.That(result, Is.True);
        }
        [Test]
        public void Create_New_Instance_Using_ValidValues()
        {
            var patient1 = new Bill(2,3,450,150,400,1000);
            Assert.That(patient1, Is.Not.Null);
        }
        [Test]
        [TestCase(-8,2,450,150,400,1000)]
        [TestCase(-1, 3,100,200,200,500)]
        [TestCase(1,2, -500,200,400,600)]
       
        public void Throw_ArgumentException_For_Invalid_Input(int Id,int AppointmentId,int ConsultationCharges,int LabTestCharges,int RoomCharges,long TotalAmount)
        {
            Assert.Throws<ArgumentException>(() => new Bill(Id,AppointmentId,ConsultationCharges,LabTestCharges,RoomCharges,TotalAmount));
        }
        [Test]
        public void Changes_AppointmentId_To_NewId()
        {
            var patient = new Bill(1,2,300,300,400,1000);
            patient.ChangeAppointmentId(5);
            Assert.That(patient.Id, Is.EqualTo(5));
        }
    }
}
