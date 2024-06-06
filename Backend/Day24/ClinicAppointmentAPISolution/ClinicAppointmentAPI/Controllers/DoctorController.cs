using ClinicAppointmentAPI.Exceptions;
using ClinicAppointmentAPI.Interfaces;
using ClinicAppointmentAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorServices _doctorServices;

        public DoctorController(IDoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
        }

        [HttpGet("GetAllDoctors")]
        public async Task<IList<Doctor>> Get()
        {
            var doctors = await _doctorServices.GetDoctors();
            return doctors.ToList();
        }

        [HttpPut("UpdateDoctorExp")]
        public async Task<ActionResult<Doctor>> Put(int id, double experience)
        {
            try
            {
                var doctor = await _doctorServices.UpdateDoctorExperience(id, experience);
                return Ok(doctor);
            }
            catch (NoSuchDoctorFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Route("GetDoctorBySpecilization")]
        [HttpPost]
        public async Task<ActionResult<Doctor>> Get([FromBody] string specialization)
        {
            try
            {
                var employee = await _doctorServices.GetDoctorBySpecilization(specialization);
                return Ok(employee);
            }
            catch (NoSuchDoctorFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
