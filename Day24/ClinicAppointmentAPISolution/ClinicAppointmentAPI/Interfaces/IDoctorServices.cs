using ClinicAppointmentAPI.Models;

namespace ClinicAppointmentAPI.Interfaces
{
    public interface IDoctorServices
    {
        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task<Doctor> UpdateDoctorExperience(int doctorID,double experience);
        public Task<IEnumerable<Doctor>> GetDoctorBySpecilization(string specialization);
    }
}
