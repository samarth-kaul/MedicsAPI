using MedicsAPI.Models;
using MedicsAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest user)
        {
            var existingUser = await _userRepository.GetUserByUsername(user.username);
            if (existingUser != null)
            {
                return BadRequest("A user with the same username already exists.");
            }

            // generating password salt
            string passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();

            // hashing the password with the salt
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.password, passwordSalt);

            var newUser = new Users
            {
                firstname = user.firstname,
                lastname = user.lastname,
                email   = user.email,
                username = user.username,
                phone = user.phone,
                passwordSalt = passwordSalt,
                passwordHash = passwordHash,
                refusertype = user.userType,
                refgender = user.gender,
            };
            
            var res = await _userRepository.CreateUser(newUser);
            if (res> 0)
            {
                return Ok("User created successfully");
            }
            else
            {
                return BadRequest("error creating user");
            }
        }
    }
}