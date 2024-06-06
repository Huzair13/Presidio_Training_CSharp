using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary.CustomException
{
    public class DuplicateDoctorException : Exception
    {
        string message;
        public DuplicateDoctorException()
        {
            message = "Already a Doctor exists with such details";
        }
        public DuplicateDoctorException(string name)
        {
            message = "Already a Doctor Exists with such {name}";
        }
        public override string Message => message;

    }
}
