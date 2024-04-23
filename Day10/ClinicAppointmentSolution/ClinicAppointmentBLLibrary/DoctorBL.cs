using ClinicAppointmentDALLibrary;
using ClinicAppointmentModelLibrary;
using ClinicAppointmentBLLibrary.CustomException;
namespace ClinicAppointmentBLLibrary
{
    public class DoctorBL : IDoctorServices
    {
        readonly IRepository<int, Doctor> _doctorRepository;
        public DoctorBL(IRepository<int, Doctor> doctorRepository)
        {
            //_doctorRepository=new DoctorRepository();
            _doctorRepository = doctorRepository;
        }

        public int AddDoctor(Doctor doctor)
        {
            var result = _doctorRepository.Add(doctor);
            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDoctorException();
        }

        public Doctor ChangeDoctorName(string doctorOldName, string doctorNewName)
        {
            var doctor = _doctorRepository.GetAll().Find(d => d.Name == doctorOldName);
            if (doctor != null)
            {
                doctor.Name = doctorNewName;
                _doctorRepository.Update(doctor);
                return doctor;
            }
            throw new DoctorNotFoundException();
        }

        public Doctor DeleteDoctorById(int doctorID)
        {
            var deletedDoctor = _doctorRepository.Delete(doctorID);
            if (deletedDoctor != null)
            {
                return deletedDoctor;
                 
            }
            throw new DoctorNotFoundException();

        }

        public List<Doctor> GetAllDoctors()
        {
            var doctors = _doctorRepository.GetAll();
            if (doctors != null)
            {
                return doctors;
            }
            throw new DoctorNotFoundException();
        }

        public List<Doctor> GetAvailableDoctors()
        {
            var doctors = _doctorRepository.GetAll();
            if (doctors != null)
            {
                return doctors.Where(d => d.IsAvailable).ToList();
            }
            throw new DoctorNotFoundException();
        }

        public bool GetDoctorAvailalityByID(int id)
        {
            var doctor = GetDoctorById(id);
            if (doctor != null)
            {
                return doctor.IsAvailable;
            }
            throw new DoctorNotFoundException();
        }

        public Doctor GetDoctorById(int id)
        {
            var doctors = _doctorRepository.GetAll();
            for (int i = 0; i < doctors.Count; i++)
                if (doctors[i].Id == id)
                    return doctors[i];
            throw new DoctorNotFoundException();
        }

        public Doctor GetDoctorByName(string doctorName)
        {
            var doctors = _doctorRepository.GetAll();
            for (int i = 0; i < doctors.Count; i++)
                if (doctors[i].Name == doctorName)
                    return doctors[i];
            throw new DoctorNotFoundException();
        }

        public Doctor GetDoctorBySpecialization(string specialization)
        {
            var doctors = _doctorRepository.GetAll();
            for (int i = 0; i < doctors.Count; i++)
                if (doctors[i].Specialization == specialization)
                    return doctors[i];
            throw new DoctorNotFoundException();
        }

    }
}
