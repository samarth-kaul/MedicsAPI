using MedicsAPI.Models;

namespace MedicsAPI.Repository
{
    public interface IUserRepository
    {
        public Task<Users> GetUserByUsername(string username);
        public Task<Users> GetUserByEmail(string email);
        public Task<Users> GetUserByPhone(string phone);
        public Task<Users> CreateUser(Users user);
        public Task<IEnumerable<Users>> GetUsersByUsertype(UserType userType);

    }
}
