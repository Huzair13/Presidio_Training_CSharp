using System;
using System.Collections.Generic;

namespace ClinicAppointmentDALLibrary.Model
{
    public partial class Appointment
    {
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime? AppointmentDateTime { get; set; }
        public string? Purpose { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
