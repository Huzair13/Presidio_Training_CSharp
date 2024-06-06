using ClinicAppointmentDALLibrary;
using ClinicAppointmentDALLibrary.Model;

//using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public  interface IDoctorServices
    {
        int AddDoctor(Doctor doctor);

        Doctor GetDoctorBySpecialization(string specialization);

        Doctor ChangeDoctorName(string doctorOldName, string doctorNewName);

        Doctor GetDoctorById(int id);

        Doctor GetDoctorByName(string doctorName);

        Doctor DeleteDoctorById(int doctorID);

        List<Doctor> GetAllDoctors();

        
    }
}
