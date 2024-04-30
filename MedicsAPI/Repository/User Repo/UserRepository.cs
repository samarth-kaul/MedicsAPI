using Dapper;
using MedicsAPI.Models;
using Npgsql;
using System.Data;

namespace MedicsAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<Users> GetUserByUsername(string username)
        {
            using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            return await connection.QueryFirstOrDefaultAsync<Users>("SELECT * FROM users WHERE username = @username", new { username = username });
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            return await connection.QueryFirstOrDefaultAsync<Users>("SELECT * FROM users WHERE email = @email", new { email = email });
        }

        public async Task<Users> GetUserByPhone(string phone)
        {
            using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            return await connection.QueryFirstOrDefaultAsync<Users>("SELECT * FROM users WHERE phone = @phone", new { phone = phone });
        }

        public async Task<Users> CreateUser(Users user)
        {
            try
            {
                using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
                string query = "INSERT INTO users (firstname, lastname, email, username, phone, passwordhash, passwordsalt, refusertype, refgender) VALUES (@firstname, @lastname, @email, @username, @phone, @passwordhash, @passwordsalt, @refusertype, @refgender) " +
                    "RETURNING id";
                var test = await connection.ExecuteScalarAsync(query, user);
                if (test != null) user.id = Convert.ToInt32(test);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateUser method: {ex.Message}");
                throw;
            }
        }
    }
}



//using BCrypt.Net;

//public class PasswordHasher
//{
//    public string HashPassword(string password)
//    {
//        // Generate a salt
//        string salt = BCrypt.Net.BCrypt.GenerateSalt();

//        // Hash the password with the salt
//        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

//        return hashedPassword;
//    }

//    public bool VerifyPassword(string password, string hashedPassword)
//    {
//        // Verify the password against the hashed password
//        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
//    }
//}
