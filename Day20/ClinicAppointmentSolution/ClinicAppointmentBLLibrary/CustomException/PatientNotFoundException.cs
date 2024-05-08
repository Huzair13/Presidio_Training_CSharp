using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary.CustomException
{
    public class PatientNotFoundException :Exception
    {
        string message;
        public  PatientNotFoundException()
        {
            message = "Patient Not Found";
        }
        public PatientNotFoundException(string name)
        {
            message = "Patient {name} not found";
        }
        public override string Message => message;
    }
}
