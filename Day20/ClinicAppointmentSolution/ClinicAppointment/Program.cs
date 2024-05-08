using System;
using ClinicAppointmentModelLibrary;
using ClinicAppointmentDALLibrary;
using ClinicAppointmentBLLibrary.CustomException;
using System.Collections.Generic;
using ClinicAppointmentBLLibrary;
//using ClinicAppointmentModelLibrary;
using ClinicAppointmentDALLibrary.Model;

namespace ClinicAppointmentConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            checkDoctorRepos();
        }
        //static void checkPatientRepos()
        //{
        //    try
        //    {
        //        var dbContext = new dbClinicAppointmentContext();
        //        var patientRepository = new PatientRepository(dbContext);
        //        var PatientBL = new PatientBL(patientRepository);

        //        //Add Patients
        //        var patients1=new Patient { Name="Remo",Dateofbirth=new DateTime(2002-03-13),
        //            Contactnum= "9677381857",Purpose="Checkup",Admitdate=new DateTime(2024-04-29)};
        //        var patients2 = new Patient
        //        {
        //            Name = "Ramu",
        //            Dateofbirth = new DateTime(2004 - 05 - 03),
        //            Contactnum = "9898997645",
        //            Purpose = "Scan",
        //            Admitdate = new DateTime(2024 - 04 - 09)
        //        };
        //    }
        //    catch (PatientNotFoundException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    catch(DuplicatePatientException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        static void checkDoctorRepos()
        {
            try
            {
                var dbContext = new dbClinicAppointmentContext();
                var doctorRepository = new DoctorRepository(dbContext);
                var doctorBL = new DoctorBL(doctorRepository);

                //Add doctors
                var doctor1 = new ClinicAppointmentDALLibrary.Model.Doctor { Id=101,Name = "Dr. Huzair", Exp = 10, Qualification = "MD", Specialization = "Cardiology", DateOfBirth = new DateTime(2002, 3, 13) };
                var doctor2 = new ClinicAppointmentDALLibrary.Model.Doctor { Id=102,Name = "Dr. Ahmed", Exp = 15, Qualification = "MD", Specialization = "Neurology", DateOfBirth = new DateTime(2004, 9, 20) };
                doctorBL.AddDoctor(doctor1);
                doctorBL.AddDoctor(doctor2);

                // Get all doctors
                List<ClinicAppointmentDALLibrary.Model.Doctor> allDoctors = doctorBL.GetAllDoctors();
                Console.WriteLine("All Doctors:");
                PrintDoctors(allDoctors);

                //// Get doctor by ID
                //int doctorId = 1;
                //Doctor doctorById = doctorBL.GetDoctorById(doctorId);
                //Console.WriteLine($"Doctor with ID {doctorId}: {doctorById.Name}");

                //// Update doctor's name
                //doctorById.Name = "Dr. Johnson Smith";
                //doctorBL.ChangeDoctorName("Dr. Johnson", "Dr. Johnson Smith");
                //Console.WriteLine($"Updated doctor name: {doctorById.Name}");

                ////// Get doctors by specialization
                ////string specialization = "Cardiology";
                ////List<ClinicAppointmentDALLibrary.Model.Doctor> doctorsBySpecialization = doctorBL.GetDoctorBySpecialization(specialization);
                ////Console.WriteLine($"Doctors in {specialization}:");
                ////PrintDoctors(doctorsBySpecialization);

                // Delete a doctor
                //int deletedDoctorId = 4;
                //Doctor deletedDoctor = doctorBL.DeleteDoctorById(deletedDoctorId);
                //Console.WriteLine($"Deleted doctor with ID {deletedDoctorId}: {deletedDoctor.Name}");

                //deletedDoctorId = 3;
                //deletedDoctor = doctorBL.DeleteDoctorById(deletedDoctorId);
                //Console.WriteLine($"Deleted doctor with ID {deletedDoctorId}: {deletedDoctor.Name}");
            }
            catch (DuplicateDoctorException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (DoctorNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void PrintDoctors(List<ClinicAppointmentDALLibrary.Model.Doctor> doctors)
        {
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"ID: {doctor.Id}, Name: {doctor.Name}, Exp: {doctor.Exp}, Qualification: {doctor.Qualification}, Specialization: {doctor.Specialization}, Date of Birth: {doctor.DateOfBirth}, Age: {doctor.Age}");
            }
        }
    }
}
