using ClinicAppointmentBLLibrary.CustomException;
using ClinicAppointmentDALLibrary;
using ClinicAppointmentDALLibrary.Model;
//using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClinicAppointmentBLLibrary
{
    public class PatientBL :IPatientServices
    {
        readonly IRepository<int, Patient> _patientRepository;
        public PatientBL(IRepository<int, Patient> patientRepository)
        {
            //_doctorRepository=new DoctorRepository();
            _patientRepository = patientRepository;
        }

        public int AddPatient(Patient patient)
        {
            var result = _patientRepository.Add(patient);
            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicatePatientException();
        }

        public Patient DeletePatientById(int id)
        {
            var deletedPatient = _patientRepository.Delete(id);
            if (deletedPatient != null)
            {
                return deletedPatient;

            }
            throw new PatientNotFoundException();
        }

        public List<Patient> GetAllPatient()
        {
            var patients = _patientRepository.GetAll();
            if (patients != null)
            {
                return patients;
            }
            throw new PatientNotFoundException();
        }


        public Patient GetPatientByAdmitDate(DateTime admitDate)
        {
            var patients = _patientRepository.GetAll();
            for (int i = 0; i < patients.Count; i++)
                if (patients[i].Admitdate == admitDate)
                    return patients[i];
            throw new PatientNotFoundException();
        }

        public Patient GetPatientById(int id)
        {
            var patients = _patientRepository.GetAll();
            for (int i = 0; i < patients.Count; i++)
                if (patients[i].Id == id)
                    return patients[i];
            throw new PatientNotFoundException();
        }

        public Patient GetPatientByName(string name)
        {
            var patients = _patientRepository.GetAll();
            for (int i = 0; i < patients.Count; i++)
                if (patients[i].Name == name)
                    return patients[i];
            throw new PatientNotFoundException();
        }


        public Patient GetPatientByPurpose(string purpose)
        {
            var patients = _patientRepository.GetAll();
            for (int i = 0; i < patients.Count; i++)
                if (patients[i].Purpose == purpose)
                    return patients[i];
            throw new PatientNotFoundException();
        }

        public Patient UpdatePatientName(string patientOldName, string patientNewName)
        {
            var doctor = _patientRepository.GetAll().Find(d => d.Name == patientOldName);
            if (doctor != null)
            {
                doctor.Name = patientNewName;
                _patientRepository.Update(doctor);
                return doctor;
            }
            throw new PatientNotFoundException();
        }
    }
}
