namespace UnderstandingBasicsApp.Models
{
    class Doctor
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Exp { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }

        //constructor with one paramater
        public Doctor(int id)
        {
            Id = id;
        }

        //no parameter constructor 
        public Doctor()
        {
            Id = 0;
            Name = string.Empty;
            Age = 0;
            Exp = 0;
            Qualification = string.Empty;
            Speciality = string.Empty;

        }

        /// <summary>
        /// This is a parameterized constructor which takes the ID, Name, Age, Experience, Qualification and Speciality as the input
        /// </summary>
        /// <param name="id">ID of the Doctor</param>
        /// <param name="name">Name of the Doctor</param>
        /// <param name="age">Age of the Doctor</param>
        /// <param name="exp">Experience of the Doctor</param>
        /// <param name="qualification">Qualification of the Doctor</param>
        /// <param name="speciality">Speciality of the Doctor</param>
        public Doctor(int id, string name, int age, int exp, string qualification, string speciality)
        {
            Id = id;
            Name = name;
            Age = age;
            Exp = exp;
            Qualification = qualification;
            Speciality = speciality;
        }

        /// <summary>
        /// Prints all the details of Doctor
        /// </summary>
        public void PrintDoctorDetails()
        {
            Console.WriteLine($"Doctor Id\t:\t{Id}");
            Console.WriteLine($"Doctor name\t:\t{Name}");
            Console.WriteLine($"Doctor age\t:\t{Age}");
            Console.WriteLine($"Doctor Experience\t:\t{Exp}");
            Console.WriteLine($"Doctor Qualification\t:\t{Qualification}");
            Console.WriteLine($"Doctor Speciality\t:\t{Speciality}");
        }
    }

}

