namespace MedicsAPI.Models
{
    
        public class Doctor
        {
            public int id { get; set; }
        public string code { get; set; } = string.Empty;
            public required int refuser { get; set; } 
            public byte[] picture { get; set; }
            public string education { get; set; } = string.Empty;
            public int refdoctordepartment { get; set; }
            public decimal consultationfee { get; set; }
            public short experience { get; set; }
            public bool isonduty { get; set; }
            public int refavailability { get; set; }
            public string bio { get; set; } = string.Empty;
            public decimal rating { get; set; }

        // Navigation properties
            //public Users user { get; set; }
            //public DoctorDepartment doctorDepartment { get; set; }
            //public DoctorAvailability doctorAvailability { get; set; }
        }
}
