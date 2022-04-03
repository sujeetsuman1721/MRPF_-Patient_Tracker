using Newtonsoft.Json;
using Patient_Tracker.Models.HospitalServices;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using System.Collections.Generic;

using Patient_Tracker.Models.DTOs.HospitalServicesDTOs;

using Patient_Tracker.Models.DTOs;


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

        public async Task<IReadOnlyCollection<PatientRegistory>> GetAppointedDoctor()
        {
            var Response = await client.GetAsync("/api/Patient/PatientInfo");

            Response.EnsureSuccessStatusCode();

            var Json = await Response.Content.ReadAsStringAsync();
            var patients = JsonConvert.DeserializeObject<List<PatientRegistory>>(Json);


            return patients;
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
        public async Task<List<Facilities>> GetFacilities()
        {
            var facilities = new List<Facilities>();
            var Response = await client.GetAsync("api/facilities/facilitiesinfo");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            facilities = JsonConvert.DeserializeObject<List<Facilities>>(Json);
            return facilities;


        }
        public async Task<PatientRegistory> GetAppointmentById(int id)
        {
            var appointmentdetail = new PatientRegistory();
            var response = await client.GetAsync($"/api/Facilities/GetByAppontmentById/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            appointmentdetail = JsonConvert.DeserializeObject<PatientRegistory>(json);
            return appointmentdetail;

        }
        public async Task<LabTests> GetLabById(int id)
        {
            var labid = new LabTests();
            var response = await client.GetAsync($"/api/Facilities/getbylabid");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            labid = JsonConvert.DeserializeObject<LabTests>(json);
            return labid;

        }
        public async Task<Consultation> GetConsultantId(int id)
        {
            var consultantid = new Consultation();
            var response = await client.GetAsync($"/api/Facilities/ConsltationId");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            consultantid = JsonConvert.DeserializeObject<Consultation>(json);
            return consultantid;

        }
        public async Task<RoomDetails> GetRoomById(int id)
        {
            var roomid = new RoomDetails();
            var response = await client.GetAsync($"/api/Facilities/GetRoomById");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            roomid = JsonConvert.DeserializeObject<RoomDetails>(json);
            return roomid;

        }
    }

   
}
