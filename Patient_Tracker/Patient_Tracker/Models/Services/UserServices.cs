using Newtonsoft.Json;
using Patient_Tracker.Models.ApplicationModel;
using Patient_Tracker.Models.DTOs;
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
    public class UserServices
    {
        private readonly HttpClient client;
        public UserServices(IHttpClientFactory factory)
        {
           
            client = factory.CreateClient("Authentication");

            
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



        }
        public async Task<bool> SaveClerk(ClerkDTO register)
        {
            var Json = JsonConvert.SerializeObject(register);

            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/auth/ClerkRegister", Content);


            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }
        public async Task<bool> SaveDoctor(DoctorDTO register)
        {
            var Json = JsonConvert.SerializeObject(register);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/auth/doctorregister", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }
        public async Task<bool> SavePatient(PatientDTO register)
        {
            var Json = JsonConvert.SerializeObject(register);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/auth/patientregister", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }
        public async Task<LoginResponse> Login(LoginRequest login)
        {
            var Json = JsonConvert.SerializeObject(login);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/auth/login", Content);
            Response.EnsureSuccessStatusCode();
            Json = await Response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoginResponse>(Json);
            return result;
        }



        public async Task<IReadOnlyCollection<DoctorModel>> GetDoctors()
        {

            var Response = await client.GetAsync("/api/AccessUsers/GetDoctors");

            Response.EnsureSuccessStatusCode();

            var Json = await Response.Content.ReadAsStringAsync();
            var doctor = JsonConvert.DeserializeObject<List<DoctorModel>>(Json);


            return doctor;
        }

        public async Task<IReadOnlyCollection<PatientModel>> GetPatients()
        {

            var Response = await client.GetAsync("/api/AccessUsers/GetPatients");

            Response.EnsureSuccessStatusCode();

            var Json = await Response.Content.ReadAsStringAsync();
            var patients = JsonConvert.DeserializeObject<List<PatientModel>>(Json);


            return patients;
        }

    }
}
