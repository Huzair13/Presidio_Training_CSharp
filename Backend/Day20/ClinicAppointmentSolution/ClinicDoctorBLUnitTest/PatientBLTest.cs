using ClinicAppointmentBLLibrary.CustomException;
using ClinicAppointmentBLLibrary;
using ClinicAppointmentDALLibrary;
//using ClinicAppointmentModelLibrary;
using ClinicAppointmentDALLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDoctorBLUnitTest
{
    public class patientBLTest
    {
        IRepository<int, Patient> repository;
        IPatientServices patientServices;
        [SetUp]
        public void Setup()
        {
            var dbContext = new dbClinicAppointmentContext();
            repository = new PatientRepository(dbContext);
            //Arrange
            Patient newpatient = new Patient()
            {
                Id = 106,
                Name = "Komu",
                Dateofbirth = DateTime.Parse("2002-04-13"),
                Contactnum = "9878765645",
                Purpose = "Scan",
                Admitdate = DateTime.Parse("2023-04-29")
            };
            repository.Add(newpatient);
            patientServices = new PatientBL(repository);
        }

        [Test]
        public void AddPatientSuccessTest()
        {
            Patient patient = new Patient()
            {
                Id = 105,
                Name = "Somu",
                Dateofbirth = DateTime.Parse("2002 - 03 - 13"),
                Contactnum = "9677381857",
                Purpose = "Checkup",
                Admitdate = DateTime.Parse("2024 - 04 - 29")
            };
            //Action
            var result = patientServices.AddPatient(patient);

            //Assert
            Assert.AreEqual(105, result);
        }

        [Test]
        public void AddPatientExceptionTest()
        {
            //Arrange
            Patient patient = new Patient()
            {
                Id = 105,
                Name = "Somu",
                Dateofbirth = DateTime.Parse("2002 - 03 - 13"),
                Contactnum = "9677381857",
                Purpose = "Checkup",
                Admitdate = DateTime.Parse("2024 - 04 - 29")
            };

            //Action
            var exception = Assert.Throws<DuplicatePatientException>(() => patientServices.AddPatient(patient));

            //Assert
            Assert.AreEqual("Already a paient exists with such details", exception.Message);
        }

        [Test]
        public void GetPatientByNameSuccesTest()
        {
            //Action
            var doctor = patientServices.GetPatientByName("Komu");
            //Assert
            Assert.NotNull(doctor);
        }

        [Test]
        public void GetDoctorByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientServices.GetPatientByName("Ahmed"));
            //Assert
            Assert.AreEqual("Patient Not Found", exception.Message);
        }

        [Test]
        public void DeletePatientSuccessTest()
        {
            //Action
            var result = patientServices.DeletePatientById(105);

            //Assert
            Assert.AreEqual(105, result.Id);
        }

        [Test]
        public void DeletePatientExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientServices.DeletePatientById(11));
            //Assert
            Assert.AreEqual("Patient Not Found", exception.Message);
        }

        [Test]
        public void GetAllPatientSuccessTest()
        {
            //Action
            var result = patientServices.GetAllPatient();

            //Assert
            Assert.NotNull(result);
        }

        //[Test]
        //public void GetAllPatientExceptionTest()
        //{
        //    //Action
        //    var exception = Assert.Throws<PatientNotFoundException>(() => patientServices.GetAllPatient());
        //    //Assert
        //    Assert.AreEqual("Patient Not Found", exception.Message);
        //}

        [Test]
        public void GetPatientByIDSuccessTest()
        {
            //ACTION
            var result = patientServices.GetPatientById(108);

            //Assert
            Assert.AreEqual(108, result.Id);
        }
        [Test]
        public void GetPatientByIDExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientServices.GetPatientById(12));
            //Assert
            Assert.AreEqual("Patient Not Found", exception.Message);
        }

        [Test]
        public void ChangePatientNameSucccessTest()
        {
            //Action
            var result = patientServices.UpdatePatientName("Arokia", "Sai");

            //Assert
            Assert.AreEqual(result.Name, "Sai");
        }
        [Test]
        public void ChangePatientNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientServices.UpdatePatientName("Ahmed", "Arivu"));
            //Assert
            Assert.AreEqual("Patient Not Found", exception.Message);
        }

        [Test]
        public void GetPatientByPurposeSuccessTest()
        {
            //Action
            var result = patientServices.GetPatientByPurpose("Scan");

            //Assert
            Assert.AreEqual(result.Purpose, "Scan");
        }

        [Test]
        public void GetDoctorBySpecializationExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientServices.GetPatientByPurpose("Checking up"));
            //Assert
            Assert.AreEqual("Patient Not Found", exception.Message);
        }

        [Test]
        public void GetPatientByAdmitDateSuccessTest()
        {
            //Action
            var result = patientServices.GetPatientByAdmitDate(DateTime.Parse("2023-04-29"));

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetPatientByAdmitDateSuccessTestExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientServices.GetPatientByAdmitDate(DateTime.Parse("2004-04-24")));
            //Assert
            Assert.AreEqual("Patient Not Found", exception.Message);
        }

    }
}
