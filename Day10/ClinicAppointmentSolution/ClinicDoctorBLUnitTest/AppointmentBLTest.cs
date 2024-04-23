using ClinicAppointmentBLLibrary.CustomException;
using ClinicAppointmentBLLibrary;
using ClinicAppointmentDALLibrary;
using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDoctorBLUnitTest
{
    public class AppointmentBLTest
    {
        IRepository<int, Appointment> repository;
        IAppointmentServices appointmentServices;
        [SetUp]
        public void Setup()
        {
            repository = new AppointmentRepository();
            Appointment appointment = new Appointment()
            {
                AppointmentDateTime = DateTime.Parse("2024-05-04"),
                DoctorID = 100,
                PatientID = 10,
                Purpose = "Scan"
            };
            repository.Add(appointment);
            appointmentServices = new AppointmentBL(repository);
        }

        [TestCase(1)]
        public void GetAppointmentByIDSuccessTest(int id)
        {
            //Action
            var appointment = appointmentServices.GetApppointmentByID(id);
            //Assert
            Assert.AreEqual(appointment.AppointmentID,1);
        }

        [Test]
        public void GetAppointmentByIDExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentServices.GetApppointmentByID(2));
            //Assert
            Assert.AreEqual("Appointment Not Found", exception.Message);
        }


        [Test]
        public void AddAppointmentSuccessTest()
        {
            //Arrange
            Appointment newAppointment = new Appointment()
            {
                AppointmentDateTime = DateTime.Parse("2024-05-04"),
                DoctorID = 100,
                PatientID = 11,
                Purpose = "Scan"
            };
            //Action
            var result = appointmentServices.AddAppointment(newAppointment);

            //Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void AddAppointmentExceptionTest()
        {
            //Arrange
            Appointment newAppointment = new Appointment()
            {
                AppointmentDateTime = DateTime.Parse("2024-05-04"),
                DoctorID = 100,
                PatientID = 10,
                Purpose = "Scan"
            };

            //Action
            var exception = Assert.Throws<DuplicateAppointmentException>(() => appointmentServices.AddAppointment(newAppointment));

            //Assert
            Assert.AreEqual("Already an Appointment exists with such details", exception.Message);
        }

        [Test]
        public void DeleteAppointmentSuccessTest()
        {
            //Action
            var result = appointmentServices.DeleteAppointment(1);

            //Assert
            Assert.AreEqual(1, result.AppointmentID);
        }

        [Test]
        public void DeleteAppointmentExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentServices.DeleteAppointment(2));

            //Assert
            Assert.AreEqual("Appointment Not Found", exception.Message);
        }


        [Test]
        public void GetAllAppointmentSuccessTest()
        {
            //Action
            var result = appointmentServices.GetAllAppointments();

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetAllAppointmentExceptionTest()
        {
            //Action
            appointmentServices.DeleteAppointment(1);
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentServices.GetAllAppointments());
            //Assert
            Assert.AreEqual("Appointment Not Found", exception.Message);
        }

        [Test]
        public void GetAppointmentByDoctorIDSuccessTest()
        {
            //ACTION
            var result = appointmentServices.GetAppointmentByDoctorId(100);

            //Assert
            Assert.AreEqual(100, result.DoctorID);
        }
        [Test]
        public void GetAppointmentByDoctorIDExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentServices.GetAppointmentByDoctorId(101));
            //Assert
            Assert.AreEqual("Appointment Not Found", exception.Message);
        }

        [Test]
        public void GetAppointmentByPatientIDSuccessTest()
        {
            //ACTION
            var result = appointmentServices.GetAppointmentByPatientID(10);

            //Assert
            Assert.AreEqual(100, result.DoctorID);
        }
        [Test]
        public void GetAppointmentByPatientIDExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentServices.GetAppointmentByPatientID(11));
            //Assert
            Assert.AreEqual("Appointment Not Found", exception.Message);
        }

        [Test]
        public void UpdateAppointmentSuccessTest()
        {
            //Action
            Appointment newAppointment = new Appointment()
            {
                AppointmentDateTime = DateTime.Parse("2024-05-04"),
                AppointmentID=1,
                DoctorID = 200,
                PatientID = 20,
                Purpose = "Scan"
            };
            var results= appointmentServices.UpdateAppointment(newAppointment);

            //Assert
            Assert.AreEqual(results.DoctorID, newAppointment.DoctorID);

        }


        [Test]
        public void UpdateAppointmentExceptionTest()
        {
            //Action
            Appointment newAppointment = new Appointment()
            {
                AppointmentDateTime = DateTime.Parse("2024-05-04"),
                AppointmentID = 3,
                DoctorID = 200,
                PatientID = 20,
                Purpose = "Scan"
            };
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentServices.UpdateAppointment(newAppointment));
            
            //Assert
            Assert.AreEqual("Appointment Not Found", exception.Message);

        }

        [Test]
        public void CancelAppointmentSuccessTest()
        {
            //Action
            var result = appointmentServices.CancelAppointmentByID(1);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CancelAppointmentExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentServices.CancelAppointmentByID(2));

            //Assert
            Assert.AreEqual("Appointment Not Found", exception.Message);
        }

        [Test]
        public void RescheduleAppointmentByIDSuccessTest()
        {
            //Action
            var result = appointmentServices.RescheduleAppointmentByID(1,DateTime.Parse("2024-05-01"));

            //Assert
            Assert.AreEqual(result.AppointmentDateTime , DateTime.Parse("2024-05-01"));
        }

        [Test]
        public void RescheduleAppointmentByIDExceptionTest()
        {

            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentServices.RescheduleAppointmentByID(2, DateTime.Parse("2024-05-01")));

            //Assert
            Assert.AreEqual("Appointment Not Found", exception.Message);
        }

    }
}
