namespace MedicsAPI.Models
{
    public class UserLoginRequest
    {
        public int id { get; set; }
        public required string username { get; set; }
        public required string password { get; set; }
    }
}
