using ClinicAppointmentBLLibrary.CustomException;
using ClinicAppointmentBLLibrary;
using ClinicAppointmentDALLibrary;
//using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAppointmentDALLibrary.Model;

namespace ClinicDoctorBLUnitTest
{
    public class AppointmentBLTest
    {
        IRepository<int, Appointment> repository;
        IAppointmentServices appointmentServices;
        [SetUp]
        public void Setup()
        {
            var dbContext = new dbClinicAppointmentContext();
            repository = new AppointmentRepository(dbContext);
            appointmentServices = new AppointmentBL(repository);
        }

        [TestCase(200)]
        public void GetAppointmentByIDSuccessTest(int id)
        {
            //Action
            var appointment = appointmentServices.GetApppointmentByID(id);
            //Assert
            Assert.AreEqual(appointment.AppointmentId, 200);
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
            ////Arrange
            //Appointment appointment = new Appointment()
            //{
            //    AppointmentId = 201,
            //    AppointmentDateTime = DateTime.Parse("2024-05-04"),
            //    DoctorId = 103,
            //    PatientId = 108,
            //    Purpose = "general",
            //};

            //Arrange
            Appointment appointment = new Appointment()
            {
                AppointmentId = 202,
                AppointmentDateTime = DateTime.Parse("2024-05-04"),
                DoctorId = 103,
                PatientId = 109,
                Purpose = "general",
            };

            //Action
            var result = appointmentServices.AddAppointment(appointment);

            //Assert
            Assert.AreEqual(202, result);
        }

        [Test]
        public void AddAppointmentExceptionTest()
        {
            //Arrange
            Appointment appointment = new Appointment()
            {
                AppointmentId = 200,
                AppointmentDateTime = DateTime.Parse("2024-05-04"),
                DoctorId = 102,
                PatientId = 108,
                Purpose = "general",
            };

            //Action
            var exception = Assert.Throws<DuplicateAppointmentException>(() => appointmentServices.AddAppointment(appointment));

            //Assert
            Assert.AreEqual("Already an Appointment exists with such details", exception.Message);
        }

        [Test]
        public void DeleteAppointmentSuccessTest()
        {
            //Action
            var result = appointmentServices.DeleteAppointment(200);

            //Assert
            Assert.AreEqual(200, result.AppointmentId);
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

        //[Test]
        //public void GetAllAppointmentExceptionTest()
        //{
        //    //Action
        //    var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentServices.GetAllAppointments());
        //    //Assert
        //    Assert.AreEqual("Appointment Not Found", exception.Message);
        //}

        [Test]
        public void GetAppointmentByDoctorIDSuccessTest()
        {
            //ACTION
            var result = appointmentServices.GetAppointmentByDoctorId(103);

            //Assert
            Assert.AreEqual(103, result.DoctorId);
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
            var result = appointmentServices.GetAppointmentByPatientID(108);

            //Assert
            Assert.AreEqual(108, result.PatientId);
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
            //Arrange
            Appointment appointment = new Appointment()
            {
                AppointmentId = 201,
                AppointmentDateTime = DateTime.Parse("2024-05-04"),
                DoctorId = 103,
                PatientId = 108,
                Purpose = "Operation",
            };
            var results = appointmentServices.UpdateAppointment(appointment);

            //Assert
            Assert.AreEqual(results.DoctorId, appointment.DoctorId);

        }


        [Test]
        public void UpdateAppointmentExceptionTest()
        {
            //Arrange
            Appointment appointment = new Appointment()
            {
                AppointmentId = 205,
                AppointmentDateTime = DateTime.Parse("2024-05-04"),
                DoctorId = 103,
                PatientId = 108,
                Purpose = "general",
            };
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentServices.UpdateAppointment(appointment));

            //Assert
            Assert.AreEqual("Appointment Not Found", exception.Message);

        }

        [Test]
        public void CancelAppointmentSuccessTest()
        {
            //Action
            var result = appointmentServices.CancelAppointmentByID(201);

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
            var result = appointmentServices.RescheduleAppointmentByID(201, DateTime.Parse("2024-05-07"));

            //Assert
            Assert.AreEqual(result.AppointmentDateTime, DateTime.Parse("2024-05-07"));
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
