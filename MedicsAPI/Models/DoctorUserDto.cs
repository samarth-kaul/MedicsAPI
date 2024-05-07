namespace MedicsAPI.Models
{
    public class DoctorUserDto
    {
        public int doctorId { get; set; }
        public int userId { get; set; }
        public required string firstname { get; set; }
        public required string lastname { get; set; }
        public required string email { get; set; }
        public required string phone { get; set; }
        public DateTime? dob { get; set; }
        public required int refgender { get; set; }
        public string address { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string zipcode { get; set; } = string.Empty;
        public DateTime regdate { get; set; } = DateTime.Now;
        public string picture { get; set; } = string.Empty;
        public string education { get; set; } = string.Empty;
        public int refdoctordepartment { get; set; }
        public decimal consultationfee { get; set; }
        public short experience { get; set; }
        public bool isonduty { get; set; }
        public int refavailability { get; set; }
        public string bio { get; set; } = string.Empty;
        public decimal rating { get; set; }
    }
}
