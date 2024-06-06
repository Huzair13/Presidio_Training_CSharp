using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicAppointmentModelLibrary;

namespace ClinicAppointmentDALLibrary
{
    public class AppointmentRepository : IRepository<int , Appointment>
    {
        public Dictionary<int, Appointment> _appointments; 
        public AppointmentRepository() { 
            _appointments = new Dictionary<int, Appointment>();
        }

        int GenerateId()
        {
            if (_appointments.Count == 0)
                return 100;
            int id = _appointments.Keys.Max();
            return ++id;
        }


        public Appointment Add(Appointment item)
        {
            if (_appointments.ContainsValue(item))
            {
                return null;
            }
            _appointments.Add(GenerateId(), item);
            return item;
        }

        public Appointment Delete(int key)
        {
            if (_appointments.ContainsKey(key))
            {
                var department = _appointments[key];
                _appointments.Remove(key);
                return department;
            }
            return null;
        }

        public Appointment Get(int key)
        {
            return _appointments.ContainsKey(key) ? _appointments[key] : null;
        }

        public List<Appointment> GetAll()
        {
            if (_appointments.Count == 0)
                return null;
            return _appointments.Values.ToList();
        }

        public Appointment Update(Appointment item)
        {
            if (_appointments.ContainsKey(item.AppointmentID))
            {
                _appointments[item.AppointmentID] = item;
                return item;
            }
            return null;
        }
    }
}
