using System;
using System.Collections.Generic;

namespace ClinicAppointmentDALLibrary.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Exp { get; set; }
        public string? Qualification { get; set; }
        public string? Specialization { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
