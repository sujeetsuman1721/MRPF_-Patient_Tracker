﻿using Newtonsoft.Json;
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
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<bool> SaveClerk(Clerk register)
        {
            var Json = JsonConvert.SerializeObject(register);

            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/auth/ClerkRegister", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }
        public async Task<bool> SaveDoctor(Doctor register)
        {
            var Json = JsonConvert.SerializeObject(register);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/auth/doctorregister", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }
        public async Task<bool> SavePatient(Patient register)
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
    }
}