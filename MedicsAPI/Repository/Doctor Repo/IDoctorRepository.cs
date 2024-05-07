using MedicsAPI.Models;

namespace MedicsAPI.Repository.Doctor_Repo
{
    public interface IDoctorRepository
    {
        Task<int> CreateDoctor(Doctor doctor);
        //Task<int> UpdateDoctor(DoctorDetails doctorDetails);
        public Task<IEnumerable<dynamic>> GetAllDoctors();
        public Task<bool> UpdateDoctor(DoctorUserDto docDetails);
    }
}
