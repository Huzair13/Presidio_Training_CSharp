using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary.CustomException
{
    public class DuplicatePatientException :Exception
    {
        string message;
        public DuplicatePatientException()
        {
            message = "Already a paient exists with such details";
        }
        public DuplicatePatientException(string name)
        {
            message = "Already a patient Exists with such {name}";
        }
        public override string Message => message;
    }
}
