using Dapper;
using MedicsAPI.Models;
using Npgsql;
using System.Data;
using System.Numerics;

namespace MedicsAPI.Repository.Patient_Repo
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IConfiguration _config;
        public PatientRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<int> CreatePatient(Patient patient)
        {
            using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            string query = "INSERT INTO patient (refuser) VALUES (@refuser)";
            return await connection.ExecuteAsync(query, patient);
        }
    }
}
