using ClinicAppointmentAPI.Exceptions;
using ClinicAppointmentAPI.Interfaces;
using ClinicAppointmentAPI.Models;

namespace ClinicAppointmentAPI.Services
{
    public class DoctorBasicServices : IDoctorServices
    {
        private readonly IRepository<int, Doctor> _repository;

        public DoctorBasicServices(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Doctor>> GetDoctorBySpecilization(string specialization)
        {
            var doctors = (await _repository.Get()).Where(e => e.Specialization == specialization);
            if (doctors.Count()==0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _repository.Get();
            if (doctors.Count() == 0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<Doctor> UpdateDoctorExperience(int doctorID,double experience)
        {
            var employee = await _repository.Get(doctorID);
            if (employee == null)
                throw new NoSuchDoctorFoundException();
            employee.Exp = experience;
            employee = await _repository.Update(employee);
            return employee;
        }
    }
}
