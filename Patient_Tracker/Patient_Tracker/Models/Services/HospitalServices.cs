﻿using Newtonsoft.Json;
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

        public async Task<Facilities> GetFacilityByAppontmentId(int appointmentId)
        {

            var facilities = new Facilities();


            var response = await client.GetAsync($"/api/Facilities/GetFacilityByAppontmentId/{appointmentId}");
            response.EnsureSuccessStatusCode();
            var json = response.Content.ReadAsStringAsync().Result;


            facilities = JsonConvert.DeserializeObject<Facilities>(json);


            return facilities;

        }

  
        public async Task<LabTests> GetLabTestById(int labtestId)
        {
            var labtests= new LabTests();

            var response = await client.GetAsync($"/api/hospitalservices/GetLabtestsById/{labtestId}");
            response.EnsureSuccessStatusCode();
            var json = response.Content.ReadAsStringAsync().Result;

            labtests = JsonConvert.DeserializeObject<LabTests>(json);

            return labtests;

        }
        public async Task<Consultation> GetConsultationById(int consultationId)
        {

            var consultation = new Consultation();

            

            var response = await client.GetAsync($"/api/hospitalservices/GetConsultationById/{consultationId}");
            response.EnsureSuccessStatusCode();
            var json = response.Content.ReadAsStringAsync().Result;

            consultation = JsonConvert.DeserializeObject<Consultation>(json);

            return consultation;

        }
        public async Task<RoomDetails> GetRoomById(int roomId)
        {
            var room= new RoomDetails();

            var response = await client.GetAsync($"/api/hospitalservices/GetRoomByRoomId/{roomId}");
            response.EnsureSuccessStatusCode();
            var json = response.Content.ReadAsStringAsync().Result;

           room = JsonConvert.DeserializeObject<RoomDetails>(json);

            return room;

        }




    }
}
