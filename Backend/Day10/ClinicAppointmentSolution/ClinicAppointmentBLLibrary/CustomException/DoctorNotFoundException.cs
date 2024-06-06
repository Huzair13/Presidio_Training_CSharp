using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary.CustomException
{
    public class DoctorNotFoundException : Exception
    {
        string message;
        public DoctorNotFoundException()
        {
            message = "No Doctor Found";
        }
        public DoctorNotFoundException(string name)
        {
            message = "No Doctor Found with : {name}";
        }
        public override string Message => message;

    }
}
