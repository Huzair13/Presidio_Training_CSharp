using ClinicAppointmentBLLibrary.CustomException;
using ClinicAppointmentDALLibrary;
using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public class AppointmentBL : IAppointmentServices
    {
        readonly IRepository<int, Appointment> _appointmentRepository;
        public AppointmentBL(IRepository<int, Appointment> appointmentRepository)
        {
            //_appointmentRepository=new AppointmentRepository();
            _appointmentRepository = appointmentRepository;
        }

        public int AddAppointment(Appointment appointment)
        {
            var result = _appointmentRepository.Add(appointment);
            if (result != null)
            {
                return result.AppointmentID;
            }
            throw new DuplicateAppointmentException();
        }

        public bool CancelAppointmentByID(int AppointmentID)
        {
            var deletedAppointment = _appointmentRepository.Delete(AppointmentID);
            if (deletedAppointment != null)
            {
                return true;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointment DeleteAppointment(int AppointmentId)
        {
            var deletedAppointment = _appointmentRepository.Delete(AppointmentId);
            if (deletedAppointment != null)
            {
                return deletedAppointment;

            }
            throw new AppointmentNotFoundException();
        }

        public List<Appointment> GetAllAppointments()
        {
            var appointments = _appointmentRepository.GetAll();
            if (appointments != null)
            {
                return appointments;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointment GetAppointmentByDoctorId(int DoctorId)
        {
            var appointments = _appointmentRepository.GetAll().FirstOrDefault(appointment => appointment.DoctorID == DoctorId);
            if (appointments != null)
            {
                return appointments;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointment GetAppointmentByPatientID(int PatientId)
        {
            var appointments = _appointmentRepository.GetAll().FirstOrDefault(appointment => appointment.PatientID == PatientId);
            if (appointments != null)
            {
                return appointments;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointment GetApppointmentByID(int AppointmentId)
        {
            var appointment = _appointmentRepository.Get(AppointmentId);
            if (appointment != null)
            {
                return appointment;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointment RescheduleAppointmentByID(int appointmentID, DateTime newDateTime)
        {
            var existingAppointment = _appointmentRepository.Get(appointmentID);
            if (existingAppointment != null)
            {
                existingAppointment.AppointmentDateTime = newDateTime;
                var updatedAppointment = _appointmentRepository.Update(existingAppointment);
                return updatedAppointment;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            var result = _appointmentRepository.Update(appointment);
            if (result != null)
            {
                return result;
            }
            throw new AppointmentNotFoundException();
        }
    }
}
