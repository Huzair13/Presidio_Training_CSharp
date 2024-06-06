using ClinicAppointmentBLLibrary;
using ClinicAppointmentBLLibrary.CustomException;
using ClinicAppointmentDALLibrary;
using ClinicAppointmentDALLibrary.Model;
//using ClinicAppointmentModelLibrary;

namespace ClinicDoctorBLUnitTest
{
    public class DoctorBLTest
    {
        IRepository<int, Doctor> repository;
        IDoctorServices doctorServices;
        [SetUp]
        public void Setup()
        {
            var dbContext = new dbClinicAppointmentContext();
            repository = new DoctorRepository(dbContext);
            doctorServices = new DoctorBL(repository);
        }

        [Test]
        public void GetDoctorByNameSuccessTest()
        {
            //Action
            var doctor = doctorServices.GetDoctorByName("Dr. Ahmed");
            //Assert
            Assert.IsNotNull(doctor);
        }

        [Test]
        public void GetDoctorByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.GetDoctorByName("Reya"));
            //Assert
            Assert.AreEqual("No Doctor Found", exception.Message);
        }


        [Test]
        public void AddDoctorSuccessTest()
        {
            //Arrange
            Doctor newDoctor = new Doctor()
            {
                Id=103,
                Name = "Dr. Riyaz",
                Qualification = "MBBS",
                Specialization = "MD",
                Exp = 15,
                DateOfBirth = DateTime.Parse("1996-04-14")
            };
            //Action
            var result = doctorServices.AddDoctor(newDoctor);

            //Assert
            Assert.AreEqual(103, result);
        }

        [Test]
        public void AddDoctorExceptionTest()
        {
            //Arrange
            Doctor newDoctor = new Doctor()
            {
                Id = 103,
                Name = "Dr. Riyaz",
                Qualification = "MBBS",
                Specialization = "MD",
                Exp = 15,
                DateOfBirth = DateTime.Parse("1996-04-14")
            };

            //Action
            var exception = Assert.Throws<DuplicateDoctorException>(() => doctorServices.AddDoctor(newDoctor));

            //Assert
            Assert.AreEqual("Already a Doctor exists with such details", exception.Message);
        }

        [Test]
        public void DeleteDoctorSuccessTest()
        {
            //Action
            var result = doctorServices.DeleteDoctorById(0);

            //Assert
            Assert.AreEqual(0, result.Id);
        }

        [Test]
        public void DeleteDoctorExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.DeleteDoctorById(200));
            //Assert
            Assert.AreEqual("No Doctor Found", exception.Message);
        }

        [Test]
        public void GetAllDoctorsSuccessTest()
        {
            //Action
            var result = doctorServices.GetAllDoctors();

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void GetAllDoctorsExceptionTest()
        {
            //Action
            doctorServices.DeleteDoctorById(100);
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.GetAllDoctors());
            //Assert
            Assert.AreEqual("No Doctor Found", exception.Message);
        }

        [Test]
        public void GetDoctorByIDSuccessTest()
        {
            //ACTION
            var result = doctorServices.GetDoctorById(102);

            //Assert
            Assert.AreEqual(102, result.Id);
        }
        [Test]
        public void GetDoctorByIDExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.GetDoctorById(200));
            //Assert
            Assert.AreEqual("No Doctor Found", exception.Message);
        }

        [Test]
        public void ChangeDoctorNameSucccessTest()
        {
            //Action
            var result = doctorServices.ChangeDoctorName("Arivu", "Mathi");

            //Assert
            Assert.AreEqual(result.Name, "Mathi");
        }
        [Test]
        public void ChangeDoctorByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.ChangeDoctorName("Arivu", "Mathi"));
            //Assert
            Assert.AreEqual("No Doctor Found", exception.Message);
        }

        [Test]
        public void GetDoctorBySpecializationSuccessTest()
        {
            //Action
            var result = doctorServices.GetDoctorBySpecialization("MD");

            //Assert
            Assert.AreEqual(result.Specialization, "MD");
        }

        [Test]
        public void GetDoctorBySpecializationExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.GetDoctorBySpecialization("ENT"));
            //Assert
            Assert.AreEqual("No Doctor Found", exception.Message);
        }

    }
}