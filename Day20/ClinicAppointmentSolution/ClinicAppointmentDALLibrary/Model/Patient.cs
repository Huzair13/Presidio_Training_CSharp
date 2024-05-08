using System;
using System.Collections.Generic;

namespace ClinicAppointmentDALLibrary.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Contactnum { get; set; }
        public string? Purpose { get; set; }
        public int? Age { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public DateTime Admitdate { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
