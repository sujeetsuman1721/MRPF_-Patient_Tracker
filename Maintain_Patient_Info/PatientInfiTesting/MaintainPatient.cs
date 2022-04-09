using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Maintain_Patient_Info;


namespace MaintainPatient
{
    [TestFixture]
    public class MaintainPatient
    {
        [Test]
        public void Patients_WithSame_AppointmentIds_MustBeEqual()
        {
            var patient1 = new MaintainPatientInfo(1,"fever","50",1,2,2,"pending",1,2,2,"blood test","Completed","Double");
            var patient2 = new MaintainPatientInfo(2, "stomach pain", "100", 3, 4, 1, "pending", 1, 2, 2, "blood test", "Completed", "Double");

            patient1.Id = 101;
            patient2.Id = 102;

            var result = patient1.Equals(patient2);
            Assert.That(result, Is.True);
        }
        [Test]
        public void Create_New_Instance_Using_ValidValues()
        {
            var patient1 = new MaintainPatientInfo(1,"fever","50",2,3,3,"pending",2,5,1,"blood test","completed","double");
            Assert.That(patient1, Is.Not.Null);
        }
        [Test]
        [TestCase(-8,"fever","applied",2,2,4,"pending",4,5,1,"blood test","completed","basic")]
        [TestCase(8, "", "applied", 2, 2, 4, "pending", 4, 5, 1, "blood test", "completed", "basic")]
        [TestCase(7, "fever", null, 3, 3, 6, "completed", 6, 2, 1, "blood test", "pending", "basic")]
        public void Throw_ArgumentException_For_Invalid_Input(int ConsultationId,string Purpose,string Charge,int Id,int PatientId,int DoctorId,string Status,int AppointmentId,int RoomId,int LabTestId,string LabTestName,string LabTestResult,string RoomType)
        {
            Assert.Throws<ArgumentException>(() => new MaintainPatientInfo(ConsultationId,Purpose,Charge,Id,PatientId,DoctorId,Status,AppointmentId,RoomId,LabTestId,LabTestName,LabTestResult,RoomType));
        }
        [Test]
        public void Change_PatientId_To_NewId()
        {
            var patient = new MaintainPatientInfo(1,"fever","applied",2,2,4,"pending",4,5,1,"blood test","completed","basic");
            patient.ChangePatientId(5);
            Assert.That(patient.Id, Is.EqualTo(5));
        }
        [Test]
        public void Throw_ArgumentException_When_Invalid_Name_Provided_To_ChangeLabTestName()
        {
            var patient = new MaintainPatientInfo(1, "fever", "applied", 2, 2, 4, "pending", 4, 5, 1, "blood test", "completed", "basic");
            Assert.Throws<ArgumentException>(() => patient.ChangeLabTestName(""));
            Assert.Throws<ArgumentException>(() => patient.ChangeLabTestName(null));
        }
        [Test]
        public void Throw_ArgumentException_When_Invalid_Name_Provided_To_ChangeLabTestResult()
        {
            var patient = new MaintainPatientInfo(1, "fever", "applied", 2, 2, 4, "pending", 4, 5, 1, "blood test", "completed", "basic");
            Assert.Throws<ArgumentException>(() => patient.ChangeLabTestResult(""));
            Assert.Throws<ArgumentException>(() => patient.ChangeLabTestResult(null));
        }
    }
}
