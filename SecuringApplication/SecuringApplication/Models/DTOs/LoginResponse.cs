namespace SecuringApplication.Models.DTOs
{
    public class LoginResponse
    {
        public string Jwt { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public int UserId { get; set; }
    }
}
