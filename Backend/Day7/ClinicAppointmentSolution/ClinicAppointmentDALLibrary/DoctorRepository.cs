using ClinicAppointmentModelLibrary;

namespace ClinicAppointmentDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly Dictionary<int, Doctor> _doctor;

        public DoctorRepository()
        {
            _doctor = new Dictionary<int, Doctor>();
        }

        int GenerateId()
        {
            if (_doctor.Count == 0)
                return 100;
            int id = _doctor.Keys.Max();
            return ++id;
        }

        public Doctor Add(Doctor item)
        {
            if (_doctor.ContainsValue(item))
            {
                return null;
            }
            _doctor.Add(GenerateId(), item);
            return item;
        }

        public Doctor Delete(int key)
        {
            if (_doctor.ContainsKey(key))
            {
                var department = _doctor[key];
                _doctor.Remove(key);
                return department;
            }
            return null;
        }

        public Doctor Get(int key)
        {
            return _doctor.ContainsKey(key) ? _doctor[key] : null;
        }

        public List<Doctor> GetAll()
        {
            if (_doctor.Count == 0)
                return null;
            return _doctor.Values.ToList();
        }

        public Doctor Update(Doctor item)
        {
            if (_doctor.ContainsKey(item.Id))
            {
                _doctor[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
