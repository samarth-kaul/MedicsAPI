namespace MedicsAPI.Models
{
    public class AppointmentStatus
    {
        public int id { get; set; }
        public required string description { get; set; }
        public required string code { get; set; }
    }
}
