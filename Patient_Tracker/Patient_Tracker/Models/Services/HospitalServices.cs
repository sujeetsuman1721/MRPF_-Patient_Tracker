using Newtonsoft.Json;
using Patient_Tracker.Models.DTOs;
using Patient_Tracker.Models.DTOs.HospitalServicesDTOs;
using Patient_Tracker.Models.HospitalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Tracker.Models.Services
{
    public class HospitalServices
    {
        private readonly HttpClient client;
        public  HospitalServices(IHttpClientFactory factory)
        {
            client = factory.CreateClient("PatientInfo");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<LabTests>> GetLabTests()
        {
            var labTests = new List<LabTests>();
            var Response = await client.GetAsync("/api/HospitalServices/LabTests");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            labTests = JsonConvert.DeserializeObject<List<LabTests>>(Json);
            return labTests;
        }
        public async Task<List<RoomDetails>> GetRoomDetails()
        {
            var roomDetails = new List<RoomDetails>();
            var Response = await client.GetAsync("/api/HospitalServices/RoomDetails");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            roomDetails = JsonConvert.DeserializeObject<List<RoomDetails>>(Json);
            return roomDetails;
        }
        public async Task<List<Consultation>> GetConsultationDetails()
        {
         
            var Response = await client.GetAsync("/api/HospitalServices/ConsultationDetails");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            var consultants = JsonConvert.DeserializeObject<List<Consultation>>(Json);
            return consultants;
        }

        public async Task<bool> AddFacility(Facilities facilities)
        {

            var Json = JsonConvert.SerializeObject(facilities);

            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/Facilities/AddFacility", Content);


            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;

        }

        public async Task<PatientRegistory> GetAppointmentById(int id)
        {

            var appointmentdetail = new PatientRegistory();

            var response = await client.GetAsync($"/api/Facilities/GetByAppontmentById/{id}");


            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            appointmentdetail=  JsonConvert.DeserializeObject< PatientRegistory>(json);

            return appointmentdetail;

        }


    }
}
