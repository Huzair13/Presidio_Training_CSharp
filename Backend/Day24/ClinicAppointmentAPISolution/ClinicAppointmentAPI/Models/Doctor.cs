namespace ClinicAppointmentAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Exp { get; set; }
        public string? Qualification { get; set; }
        public string? Specialization { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string Image { get; set; }
        public int? Age => CalculateAge();

        private int? CalculateAge()
        {
            if (DateOfBirth.HasValue)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - DateOfBirth.Value.Year;
                return age;
            }
            return null;
        }
    }
}
