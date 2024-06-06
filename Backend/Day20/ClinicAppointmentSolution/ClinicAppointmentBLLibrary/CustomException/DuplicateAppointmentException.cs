using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary.CustomException
{
    public class DuplicateAppointmentException : Exception
    {
        string message;
        public DuplicateAppointmentException()
        {
            message = "Already an Appointment exists with such details";
        }
        public override string Message => message;
    }
}
