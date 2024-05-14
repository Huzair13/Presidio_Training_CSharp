using ClinicAppointmentAPI.contexts;
using ClinicAppointmentAPI.Exceptions;
using ClinicAppointmentAPI.Interfaces;
using ClinicAppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentAPI.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        public readonly ClinicAppointmentContext _context;

        public DoctorRepository(ClinicAppointmentContext context)
        {
            _context = context;
        }


        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Doctor> Delete(int key)
        {
            var doctor = await Get(key);
            if (doctor != null)
            {
                _context.Remove(doctor);
                await _context.SaveChangesAsync(true);
                return doctor;
            }
            throw new NoSuchDoctorFoundException();
        }

        public async Task<Doctor> Get(int key)
        {
            var doctors = await _context.Doctors.FirstOrDefaultAsync(e => e.Id == key);
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }

        public async Task<Doctor> Update(Doctor item)
        {
            var doctor = await Get(item.Id);
            if (doctor != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return doctor;
            }
            throw new NoSuchDoctorFoundException();
        }
    }
}
