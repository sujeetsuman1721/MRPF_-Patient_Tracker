using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using SecuringApplication;
using System.Net;
using System.Net.Http;

namespace AccessUserController.Test
{
    [TestFixture]
    public class AccesUserTest
    {
        HttpClient SUT;
        WebApplicationFactory<Startup> server;

        [OneTimeSetUp]
        public void SetUp()
        {
            server = new WebApplicationFactory<Startup>();
            SUT = server.CreateClient();

        }

        [Test]
        public void GetDoctors()
        {
            var res = SUT.GetAsync("api/AccessUsers/GetDoctors").Result;
            Assert.AreEqual(res.StatusCode,HttpStatusCode.OK);
        }

        [Test]
        public void GetPatients()
        {
            var res = SUT.GetAsync("api/AccessUsers/GetPatients").Result;
            Assert.AreEqual(res.StatusCode, HttpStatusCode.OK);
        }



    }
}
