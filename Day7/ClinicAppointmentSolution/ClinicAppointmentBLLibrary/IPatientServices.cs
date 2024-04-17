using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAppointmentModelLibrary;

namespace ClinicAppointmentBLLibrary
{
    public interface IPatientServices
    {
        Patient GetPatientByName(string name);

        Patient GetPatientById(int id);

        List<Patient> GetAllPatient();

        int AddPatient(Patient patient);

        Patient UpdatePatient(Patient patient);

        void DeletePatientById(int id);

        Patient GetPatientByAdmitDate(DateTime admitDate);

        Patient GetPatientByPurpose(string purpose);

        List<Patient> SearchPatients();


    }
}
