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

        public async Task<IEnumerable<dynamic>> GetAllDoctors()
        {
            try
            {
                using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
                string query = @"SELECT u.firstname, u.lastname, d.picture, d.refdoctordepartment, d.experience, d.rating FROM Doctor d INNER JOIN users u ON d.refuser = u.id";
                return await connection.QueryAsync(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateUser method: {ex.Message}");
                throw;
            }
        }

        public async Task<int> CreateDoctor(Doctor doctor)
        {
            try
            {
                using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
                string query = "INSERT INTO doctor (refuser) VALUES (@refuser)";
                return await connection.ExecuteAsync(query, doctor);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error in UpdateUser method: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateDoctor(DoctorUserDto docDetails)
        {
            using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            try
            {
                string docqurey = "UPDATE doctor SET education = @education, consultationfee = @consultationfee, bio = @bio, experience = @experience, refdoctordepartment = @refdoctordepartment, isonduty = @isonduty WHERE id = @doctorId";
                var res1 = await connection.ExecuteAsync(docqurey, docDetails);

                string userQuery = "UPDATE users SET firstname = @firstname, lastname = @lastname, email = @email, phone = @phone, dob = @dob, refusertype = @refusertype, address = @address, city = @city, zipcode = @zipcode WHERE id = @userId";
                var res2 = await connection.ExecuteAsync(userQuery, docDetails);

                return res1 > 0 && res2 > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateUser method: {ex.Message}");
                throw;
            }
        }


        //public async Task<int> UpdateDoctor(DoctorDetails doctorDetails, int doctorId, int userId)
        //{
        //    using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
        //    string query = "UPDATE doctor SET picture = @picture, education = @education, consultationfee = @consultationfee, bio = @bio, experience = @experience, refdoctordepartment = @refdoctordepartment WHERE refuser = @refuser";
        //    return await connection.ExecuteAsync(query, new
        //    {
        //        doctorDetails.picture,
        //        doctorDetails.education,
        //        doctorDetails.consultationfee,
        //        doctorDetails.bio,
        //        doctorDetails.refdoctordepartment,
        //        doctorDetails.refuser
        //    });
        //}
    }
}

































// Get the prefix based on the user type
// Extract a portion of the user ID (for example, the last 3 digits)
// Combine the prefix and the extracted portion of the user ID to form the unique code
