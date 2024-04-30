using MedicsAPI.Models;

namespace MedicsAPI.Repository.Patient_Repo
{
    public interface IPatientRepository
    {
        Task<int> CreatePatient(Patient patient);
    }
}
