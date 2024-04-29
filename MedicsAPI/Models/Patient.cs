namespace MedicsAPI.Models
{
    public class Patient
    {
        public int id { get; set; }
        public required string code { get; set; }
        public int refbloodgroup { get; set; }
        public int refuser { get; set; }
        public decimal height_cm { get; set; }
        public decimal weight_kg { get; set; }
        public byte[] picture { get; set; } = new byte[0];
        public string medicalHistory { get; set; } = string.Empty;
        public string allergies { get; set; } = string.Empty;
        public string onGoingMedications { get; set; } = string.Empty;
        public required string emergencyContactName { get; set; }
        public required string emergencyContactNumber { get; set; }



        // foreign key references
        public BloodGroup refBloodGroup { get; set; }
        public Users refUser { get; set; }
    }
}
