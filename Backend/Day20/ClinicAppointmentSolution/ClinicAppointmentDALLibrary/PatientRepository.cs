
//using ClinicAppointmentModelLibrary;
using ClinicAppointmentDALLibrary.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClinicAppointmentDALLibrary
{
    public class PatientRepository :IRepository<int, Patient>
    {
        readonly dbClinicAppointmentContext _context;
        public PatientRepository(dbClinicAppointmentContext context)
        {
            _context = context;
        }


        public Patient Add(Patient item)
        {
            var results= _context.Patients.FirstOrDefault(a=>a.Id==item.Id);

            if (results!=null)
            {
                return null;
            }
            _context.Patients.Add(item);
            _context.SaveChanges();
            return item;

        }

        public Patient Delete(int key)
        {
            var patients = _context.Patients.Find(key);
            if (patients != null)
            {
                _context.Patients.Remove(patients);
                _context.SaveChanges();
                return patients;
            }
            return null;
        }

        public Patient Get(int key)
        {
            if (_context.Patients.Find(key) != null)
            {
                return _context.Patients.Find(key);
            }
            return null;
        }

        public List<Patient> GetAll()
        {
            if (_context.Patients.ToList() != null)
            {
                return _context.Patients.ToList();
            }
            return null;
        }

        public Patient Update(Patient item)
        {
            var patients = _context.Patients.Find(item.Id);
            if (patients != null)
            {
                _context.Entry(patients).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return patients;
            }
            return null;
        }
    }
}
