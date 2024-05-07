namespace MedicsAPI.Models
{
    public class DoctorDetails
    {
        public string education { get; set; } = string.Empty;
        public int refdoctordepartment { get; set; }
        public string consultationfee { get; set; } = string.Empty;
        public string bio {get; set;}
        public int experience { get; set; }
        public byte[]? picture { get; set; }
        public int refuser {  get; set; }
    }
}
