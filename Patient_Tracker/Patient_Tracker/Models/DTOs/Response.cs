namespace Patient_Tracker.Models.DTOs
{
    public class Response
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public LoginResponse AuthData { get; set; }
    }
}
