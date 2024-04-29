namespace MedicsAPI.Models
{
    public class DoctorAvailability
    {
        public int id { get; set; }
        public int doctorId { get; set; }
        public int dayOfWeek { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        // Navigation property
        public Doctor doctor { get; set; }
    }
}
