using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicAppointmentDALLibrary.Model;

namespace ClinicAppointmentDALLibrary
{
    public class AppointmentRepository :IRepository<int,Appointment>
    {
        readonly dbClinicAppointmentContext _context;
        public AppointmentRepository(dbClinicAppointmentContext context)
        {
            _context = context;
        }

        public Appointment Add(Appointment item)
        {
            var results = _context.Appointments.FirstOrDefault(a => a.PatientId == item.PatientId);
            if (results != null)
            {
                return null;
            }
            _context.Appointments.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Appointment Delete(int key)
        {
            var appointment = _context.Appointments.FirstOrDefault(a=>a.AppointmentId==key);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
                return appointment;
            }
            return null;
        }

        public Appointment Get(int key)
        {
            if (_context.Appointments.Find(key) != null)
            {
                return _context.Appointments.Find(key);
            }
            return null;
        }

        public List<Appointment> GetAll()
        {
            if (_context.Appointments.ToList() != null)
            {
                return _context.Appointments.ToList();
            }
            return null;
        }

        public Appointment Update(Appointment item)
        {
            var appointment = _context.Appointments.Find(item.AppointmentId);
            if (appointment != null)
            {
                _context.Entry(appointment).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return appointment;
            }
            return null;
        }
    }
}
