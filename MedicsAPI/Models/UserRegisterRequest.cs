namespace MedicsAPI.Models
{
    public class UserRegisterRequest
    {
        public required string firstname { get; set; }
        public required string lastname { get; set; }
        public required string email { get; set; }
        public required string username { get; set; }
        public required string phone { get; set; }
        public required string password { get; set; }
        public required int usertype { get; set; }
        public required int gender { get; set;}
    }
}
