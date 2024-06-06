using ClinicAppointmentDALLibrary;
using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public class PatientBL
    {
        readonly IRepository<int, Patient> _patientRepository;
        public PatientBL()
        {
            _patientRepository = new PatientRepository();
        }
    }
}
