using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAppointmentModelLibrary;

namespace ClinicAppointmentBLLibrary
{
    public interface IAppointmentServices
    {
        Appointment GetApppointmentByID(int AppointmentId);

        List<Appointment> GetAllAppointments();

        Appointment GetAppointmentByDoctorId(int DoctorId);

        Appointment GetAppointmentByPatientID(int PatientId);

        int AddAppointment(Appointment appointmentBL);

        Appointment UpdateAppointment(Appointment appointmentBL);

        Appointment DeleteAppointment(int AppointmentId);

        bool CheckAppointmentAvailability(Appointment appointmentBL);

        bool CancelAppointmentByID(int AppointmentID);

        int RescheduleAppointmentByID(int AppointmentID);
    }
}
