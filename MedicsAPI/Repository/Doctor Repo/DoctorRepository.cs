using Dapper;
using MedicsAPI.Models;
using Npgsql;
using System.Data;

namespace MedicsAPI.Repository.Doctor_Repo
{
    public class DoctorRepository : IDoctorRepository
    {

        private readonly IConfiguration _config;
        public DoctorRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<int> CreateDoctor(Doctor doctor)
        {
            using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            string query = "INSERT INTO doctor (refuser) VALUES (@refuser)";
            return await connection.ExecuteAsync(query, doctor);
        }
    }
}

































// Get the prefix based on the user type
// Extract a portion of the user ID (for example, the last 3 digits)
// Combine the prefix and the extracted portion of the user ID to form the unique code
