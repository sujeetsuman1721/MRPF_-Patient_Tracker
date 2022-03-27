﻿using Newtonsoft.Json;
using PatientTracker.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PatientTracker.Models.Services
{
    public class DoctorRegistrationServices:BaseService
    {
        public DoctorRegistrationServices(IHttpClientFactory factory)
        {
            client = factory.CreateClient("PatientRegistrationServicesAPI");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<bool> SaveRegister(DoctorRegistrationModel register)
        {
            var Json = JsonConvert.SerializeObject(register);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/doctersauth", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.Created;
        }
    }
}
