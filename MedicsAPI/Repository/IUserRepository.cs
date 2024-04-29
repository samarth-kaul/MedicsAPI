using MedicsAPI.Models;

namespace MedicsAPI.Repository
{
    public interface IUserRepository
    {
        public Task<Users> GetUserByUsername(string username);
        public Task<int> CreateUser(Users user);

    }
}
