using Newtonsoft.Json;
using Patient_Tracker.Models.DTOs.HospitalServicesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Patient_Tracker.Models.Services
{
    public class HospitalServices
    {
        private readonly HttpClient client;
        public  HospitalServices(IHttpClientFactory factory)
        {
            client = factory.CreateClient("Services");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<LabTests>> GetLabTests()
        {
            var labTests = new List<LabTests>();
            var Response = await client.GetAsync("/api/hospitalservices/labtests");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            labTests = JsonConvert.DeserializeObject<List<LabTests>>(Json);
            return labTests;
        }
        public async Task<List<RoomDetails>> GetRoomDetails()
        {
            var roomDetails = new List<RoomDetails>();
            var Response = await client.GetAsync("/api/hospitalservices/roomdetails");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            roomDetails = JsonConvert.DeserializeObject<List<RoomDetails>>(Json);
            return roomDetails;
        }
        public async Task<List<Consultation>> GetConsultationDetails()
        {
            var consultants = new List<Consultation>();
            var Response = await client.GetAsync("/api/hospitalservices/consultationdetails");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            consultants = JsonConvert.DeserializeObject<List<Consultation>>(Json);
            return consultants;
        }
    }
}
