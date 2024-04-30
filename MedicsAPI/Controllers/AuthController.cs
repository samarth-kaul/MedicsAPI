using MedicsAPI.Models;
using MedicsAPI.Repository;
using MedicsAPI.Repository.Doctor_Repo;
using MedicsAPI.Repository.Patient_Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public AuthController(IUserRepository userRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository)
        {
            _userRepository = userRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest user)
        {
            try
            {
                var existingUsername = await _userRepository.GetUserByUsername(user.username);
                var existingEmail = await _userRepository.GetUserByUsername(user.username);
                var exisitngPhone = await _userRepository.GetUserByUsername(user.username);


                if (existingUsername != null || existingEmail != null || exisitngPhone != null)
                {
                    return BadRequest("A user with the same username already exists.");
                }
                else if(existingEmail != null)
                {
                    return BadRequest("A user with the same email already exists.");
                }
                else if(exisitngPhone != null)
                {
                    return BadRequest("A user with the same phone already exists.");
                }

                // generating password salt
                string passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();

                // hashing the password with the salt
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.password, passwordSalt);

                var newUser = new Users
                {
                    firstname = user.firstname,
                    lastname = user.lastname,
                    email = user.email,
                    username = user.username,
                    phone = user.phone,
                    passwordsalt = passwordSalt,
                    passwordhash = passwordHash,
                    refusertype = user.usertype,
                    refgender = user.gender,
                };

                var res = await _userRepository.CreateUser(newUser);    // res is the newUser
                if (res != null)
                {
                    if(res.refusertype == 1)
                    {
                        // this means the user is a patient
                        var addPatient = new Patient
                        {
                            refuser = res.id,
                            code = GenerateUniqueCode("Patient", res.id)
                        };
                        await _patientRepository.CreatePatient(addPatient);
                    }
                    else if (res.refusertype == 2)
                    {
                        // this means the user is a doctor
                        var addDoctor = new Doctor
                        {
                            refuser = res.id,
                            code = GenerateUniqueCode("Doctor", res.id)
                        };
                        await _doctorRepository.CreateDoctor(addDoctor);
                    }

                    return Ok("User created succefully");
                }
                else
                {
                    return BadRequest("Error creating user");
                }
            }catch (Exception ex)
            {
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest user)
        {
            try
            {
                var existingUsername = await _userRepository.GetUserByUsername(user.username);
                if (existingUsername == null)
                {
                    return BadRequest("This username does not exist.");
                }
                return Ok($"User logged in successfully, {existingUsername.username}");
            }catch (Exception ex)
            {
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
        }







        private string GenerateUniqueCode(string userType, int userId)
        {
            // Get the prefix based on the user type
            string prefix = userType == "Doctor" ? "MD" : "MP";

            // Extract a portion of the user ID (for example, the last 3 digits)
            string idSuffix = userId.ToString().Substring(Math.Max(0, userId.ToString().Length - 3));

            // Combine the prefix and the extracted portion of the user ID to form the unique code
            string uniqueCode = prefix + idSuffix.PadLeft(3, '0'); // Pad left with zeros to ensure consistent length

            return uniqueCode;
        }

    }
}