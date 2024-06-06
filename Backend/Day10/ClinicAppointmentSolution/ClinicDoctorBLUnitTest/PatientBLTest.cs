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
    public class patientBLTest
    {
        IRepository<int, Patient> repository;
        IPatientServices patientServices;
        [SetUp]
        public void Setup()
        {
            repository = new PatientRepository();
            Patient patient = new Patient()
            { Name = "Huzair",
                admitDate = DateTime.Parse("04-05-2024"),
                purpose="General Check Up",
                ContactNum=9877675643,
                DateOfBirth= DateTime.Parse("2002-03-13")
                };
            repository.Add(patient);
            patientServices = new PatientBL(repository);
        }

        [Test]
        public void GetPatientByNameSuccesTest()
        {
            //Action
            var doctor = patientServices.GetPatientByName("Huzair");
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
        public void AddPatientSuccessTest()
        {
            //Arrange
            Patient newPatient = new Patient()
            {
                Name = "Ahmed",
                admitDate = DateTime.Parse("05-04-2024"),
                purpose = "Scan",
                ContactNum = 7866757532,
                DateOfBirth = DateTime.Parse("2001-05-14")
            };
            //Action
            var result = patientServices.AddPatient(newPatient);

            //Assert
            Assert.AreEqual(11, result);
        }

        [Test]
        public void AddPatientExceptionTest()
        {
            //Arrange
            Patient newpatient = new Patient()
            {
                Name = "Huzair",
                admitDate = DateTime.Parse("04-05-2024"),
                purpose = "General Check Up",
                ContactNum = 9877675643,
                DateOfBirth = DateTime.Parse("2002-03-13")
            };

            //Action
            var exception = Assert.Throws<DuplicatePatientException>(() => patientServices.AddPatient(newpatient));

            //Assert
            Assert.AreEqual("Already a paient exists with such details", exception.Message);
        }

        [Test]
        public void DeletePatientSuccessTest()
        {
            //Action
            var result = patientServices.DeletePatientById(10);

            //Assert
            Assert.AreEqual(10, result.Id);
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

        [Test]
        public void GetAllPatientExceptionTest()
        {
            //Action
            patientServices.DeletePatientById(10);
            var exception = Assert.Throws<PatientNotFoundException>(() => patientServices.GetAllPatient());
            //Assert
            Assert.AreEqual("Patient Not Found", exception.Message);
        }

        [Test]
        public void GetPatientByIDSuccessTest()
        {
            //ACTION
            var result = patientServices.GetPatientById(10);

            //Assert
            Assert.AreEqual(10, result.Id);
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
            var result = patientServices.UpdatePatientName("Huzair", "Arivu");

            //Assert
            Assert.AreEqual(result.Name, "Arivu");
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
            var result = patientServices.GetPatientByPurpose("General Check Up");

            //Assert
            Assert.AreEqual(result.purpose, "General Check Up");
        }

        [Test]
        public void GetDoctorBySpecializationExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientServices.GetPatientByPurpose("Scan"));
            //Assert
            Assert.AreEqual("Patient Not Found", exception.Message);
        }

        [Test]
        public void GetPatientByAdmitDateSuccessTest()
        {
            //Action
            var result = patientServices.GetPatientByAdmitDate(DateTime.Parse("04-05-2024"));

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetPatientByAdmitDateSuccessTestExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientServices.GetPatientByAdmitDate(DateTime.Parse("2024-04-24")));
            //Assert
            Assert.AreEqual("Patient Not Found", exception.Message);
        }

    }
}
