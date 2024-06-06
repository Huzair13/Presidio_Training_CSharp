using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary.CustomException
{
    public class AppointmentNotFoundException : Exception
    {
        string message;
        public AppointmentNotFoundException()
        {
            message = "Appointment Not Found";
        }
        public override string Message => message;
    }
}
