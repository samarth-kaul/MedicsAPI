using MedicsAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MedicsAPI.Models
{
    public class DoctorWorkingHours
    {
        public int id { get; set; }
        public int doctor_id { get; set; }
        public int dayofweek { get; set; }
        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }
    }
}