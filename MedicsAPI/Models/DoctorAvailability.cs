namespace MedicsAPI.Models
{
    public class DoctorAvailability
    {
        public int id { get; set; }
        public int doctor_id { get; set; }
        public int dayofweek { get; set; }
        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }

        // Navigation property
        //public Doctor doctor { get; set; }
    }
}
