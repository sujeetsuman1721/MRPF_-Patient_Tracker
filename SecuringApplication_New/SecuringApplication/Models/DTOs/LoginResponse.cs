namespace SecuringApplication.Models.DTOs
{
    public class LoginResponse
    {
        public string jwt { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public int UserId { get; set; }
    }
}
