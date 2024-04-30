using MedicsAPI.Models;

namespace MedicsAPI.Repository.Doctor_Repo
{
    public interface IDoctorRepository
    {
        Task<int> CreateDoctor(Doctor doctor);
    }
}
