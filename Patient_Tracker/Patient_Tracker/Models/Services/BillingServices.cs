using Newtonsoft.Json;
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
    public class BillingServices
    {
        private readonly HttpClient client;
        public BillingServices(IHttpClientFactory factory)
        {
            client = factory.CreateClient("GenerateBill");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<Billing> GetBillDetailsyAppoimentId(int id)
        {
            var response = await client.GetAsync($"/api/Billing/GetChargesFromAppointMentId/{id}");
            response.EnsureSuccessStatusCode();
            var json = response.Content.ReadAsStringAsync().Result;

            var bill = JsonConvert.DeserializeObject<Billing>(json);

            return bill;
        }

        //
        public async Task<bool> GenerateBill(Billing billing)
        {

            var Json = JsonConvert.SerializeObject(billing);

            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/billing/charges", Content);


            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;

        }
    }
}
