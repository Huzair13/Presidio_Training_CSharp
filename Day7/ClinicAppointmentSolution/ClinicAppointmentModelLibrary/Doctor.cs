namespace ClinicAppointmentModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Exp { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; } = string.Empty;
        int age;
        DateTime dob;
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }

        }

        public Doctor()
        {
            Id = 0;
            Name=string.Empty;
            Exp = 0f;
            Qualification = string.Empty;
            Specialization = string.Empty;
            DateOfBirth = new DateTime();
        }

        public Doctor(int id,string name, float exp,string qualification,string specialization,DateTime dateOfBirth)
        {
            Id=id;
            Name=name;
            Exp=exp;
            Qualification=qualification;
            Specialization=specialization;
            DateOfBirth = dateOfBirth;
        }
    }
}
