namespace MedicsAPI.Models
{
    public class DoctorDepartment
    {
        public int id { get; set; }
        public required string description { get; set; }
        public required string code { get; set; }
    }
}
