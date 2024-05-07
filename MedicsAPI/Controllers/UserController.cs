using MedicsAPI.Repository.Doctor_Repo;
using MedicsAPI.Repository.Patient_Repo;
using MedicsAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicsAPI.Models;

namespace MedicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;

        public UserController(IDoctorRepository doctorRepository, IPatientRepository patientRepository, IUserRepository userRepository)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _userRepository = userRepository;
        }

        [HttpGet("get-doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            try
            {
                IEnumerable<dynamic> doctors = await _doctorRepository.GetAllDoctors();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("update-doctor")]
        public async Task<IActionResult> UpdateDoctor(DoctorUserDto docDetails)
        {
            try
            {
                bool res = await _doctorRepository.UpdateDoctor(docDetails);
                if (res)
                {
                    return Ok("Doctor successfully updated");
                }
                return BadRequest("Error updating the doctor details");
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
        }
    }
}
