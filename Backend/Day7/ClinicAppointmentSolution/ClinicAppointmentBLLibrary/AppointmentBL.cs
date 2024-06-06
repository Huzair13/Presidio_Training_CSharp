using ClinicAppointmentDALLibrary;
using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public class AppointmentBL
    {
        readonly IRepository<int, Appointment> _appointmentRepository;
        public AppointmentBL()
        {
            _appointmentRepository = new AppointmentRepository();
        }
    }
}
