using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentModelLibrary
{
    public class Appointment
    {
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public int AppointmentID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Purpose { get; set; }

        public Appointment() { 
            DoctorID = 0;
            PatientID = 0;
            AppointmentID = 0;
            AppointmentDateTime = DateTime.Now;
            Purpose = string.Empty;
        }

        public Appointment(int doctorID, int patientID, int appointmentID, DateTime dateTime,string purpose)
        {
            DoctorID = doctorID;
            PatientID = patientID;
            AppointmentID = appointmentID;
            AppointmentDateTime = dateTime;
            Purpose = purpose;
        }
    }
}
