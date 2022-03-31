using Newtonsoft.Json;
using Patient_Tracker.Models.HospitalServices;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Patient_Tracker.Models.Services
{
    public class PatientServices
    {
        private readonly HttpClient client;
        public PatientServices(IHttpClientFactory factory)
        {
            client = factory.CreateClient("PatientInfo");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<bool> AppointPatient(PatientRegistory register)
        {

            var Json = JsonConvert.SerializeObject(register);

            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/Patient/AddPatient", Content);


            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;

        }
    }

   
}
