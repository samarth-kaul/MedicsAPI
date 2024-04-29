namespace MedicsAPI.Models
{
    
        public class Doctor
        {
            public int id { get; set; }
            public required string code { get; set; }
            public int refUserId { get; set; }
            public byte[] picture { get; set; }
            public string education { get; set; }
            public int refDoctorDepartmentId { get; set; }
            public decimal consultationFee { get; set; }
            public short experience { get; set; }
            public bool isOnDuty { get; set; }
            public int iefAvailabilityId { get; set; }
            public string bio { get; set; } = string.Empty;
            public decimal rating { get; set; }

            // Navigation properties
            public Users user { get; set; }
            public DoctorDepartment doctorDepartment { get; set; }
            public DoctorAvailability doctorAvailability { get; set; }
        }

    
}
