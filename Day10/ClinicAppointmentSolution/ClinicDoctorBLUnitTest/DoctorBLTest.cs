using ClinicAppointmentBLLibrary;
using ClinicAppointmentBLLibrary.CustomException;
using ClinicAppointmentDALLibrary;
using ClinicAppointmentModelLibrary;

namespace ClinicDoctorBLUnitTest
{
    public class DoctorBLTest
    {
        IRepository<int, Doctor> repository;
        IDoctorServices doctorServices;
        [SetUp]
        public void Setup()
        {
            repository = new DoctorRepository();
            Doctor doctor = new Doctor() { Name = "Huzair", Qualification="MBBS", 
                Specialization="ENT", IsAvailable=true, Exp = 5,
                DateOfBirth=DateTime.Parse("2002-03-13")
            };
            repository.Add(doctor);
            doctorServices = new DoctorBL(repository);
        }

        [Test]
        public void GetDoctorByNameSuccessTest()
        {
            //Action
            var doctor = doctorServices.GetDoctorByName("Huzair");
            //Assert
            Assert.IsNotNull(doctor);
        }

        [Test]
        public void GetDoctorByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.GetDoctorByName("Ahmed"));
            //Assert
            Assert.AreEqual("No Doctor Found", exception.Message);
        }


        [Test]
        public void AddDoctorSuccessTest()
        {
            //Arrange
            Doctor newDoctor = new Doctor()
            {
                Name = "Ahmed",
                Qualification = "MBBS",
                Specialization = "MD",
                IsAvailable = true,
                Exp = 6,
                DateOfBirth = DateTime.Parse("2001-04-14")
            };
            //Action
            var result=doctorServices.AddDoctor(newDoctor);

            //Assert
            Assert.AreEqual(101, result);
        }

        [Test]
        public void AddDoctorExceptionTest() 
        {
            //Arrange
            Doctor newDoctor = new Doctor()
            {
                Name = "Huzair",
                Qualification = "MBBS",
                Specialization = "ENT",
                IsAvailable = true,
                Exp = 5,
                DateOfBirth = DateTime.Parse("2002-03-13")
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
            var result = doctorServices.DeleteDoctorById(100);

            //Assert
            Assert.AreEqual(100, result.Id);
        }

        [Test]
        public void DeleteDoctorExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.DeleteDoctorById(101));
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
            var result = doctorServices.GetDoctorById(100);

            //Assert
            Assert.AreEqual(100,result.Id);
        }
        [Test]
        public void GetDoctorByIDExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.GetDoctorById(102));
            //Assert
            Assert.AreEqual("No Doctor Found", exception.Message);
        }

        [Test]
        public void ChangeDoctorNameSucccessTest()
        {
            //Action
            var result = doctorServices.ChangeDoctorName("Huzair", "Arivu");

            //Assert
            Assert.AreEqual(result.Name, "Arivu");
        }
        [Test]
        public void ChangeDoctorByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.ChangeDoctorName("Ahmed","Arivu"));
            //Assert
            Assert.AreEqual("No Doctor Found", exception.Message);
        }

        [Test]
        public void GetDoctorBySpecializationSuccessTest()
        {
            //Action
            var result = doctorServices.GetDoctorBySpecialization("ENT");

            //Assert
            Assert.AreEqual(result.Specialization, "ENT");
        }

        [Test]
        public void GetDoctorBySpecializationExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.GetDoctorBySpecialization("MD"));
            //Assert
            Assert.AreEqual("No Doctor Found", exception.Message);
        }

        [TestCase(100)]
        public void GetDoctorAvailalityByIDSuccessTest(int id)
        {
            //Action
            var result=doctorServices.GetDoctorAvailalityByID(id);

            //Assert
            Assert.IsTrue(result);
        }
        [TestCase(104)]
        [TestCase(101)]
        public void GetDoctorAvailalityByIDExceptionTest(int id)
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.GetDoctorAvailalityByID(id));
            //Assert
            Assert.AreEqual("No Doctor Found", exception.Message);
        }

        [Test]
        public void GetDoctorAvailalityByIDFailureTest()
        {
            //Arrange
            Doctor newDoctor = new Doctor()
            {
                Name = "Ahmed",
                Qualification = "MBBS",
                Specialization = "MD",
                IsAvailable = false,
                Exp = 5,
                DateOfBirth = DateTime.Parse("2002-03-14")
            };
            doctorServices.AddDoctor(newDoctor);
            //Action
            var result = doctorServices.GetDoctorAvailalityByID(101);

            //Assert
            Assert.AreEqual(false, result);

        }

        [Test]
        public void GetAvailableDoctorsSuccessTest()
        {
            //Action
            var result=doctorServices.GetAvailableDoctors();

            //Assert
            Assert.NotNull(result);
        }
        [Test]
        public void GetAvailableDoctorsExceptionTest()
        {
            //Action
            doctorServices.DeleteDoctorById(100);
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorServices.GetAvailableDoctors());
            //Assert
            Assert.AreEqual("No Doctor Found", exception.Message);
        }
    }
}