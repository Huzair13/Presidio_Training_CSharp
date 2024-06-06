using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentModelLibrary
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long ContactNum { get; set; }
        public int age;
        public string purpose { get; set; }= string.Empty;
        public int Age
        {
            get => age;
        }
        public DateTime dob;
        public DateTime admitDate { get; set; } = DateTime.Today;

        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }


        public Patient()
        {
            Id = 0;
            Name = string.Empty;
            ContactNum = 0;
            DateOfBirth = new DateTime();
        }

        public Patient(int id, string  name, long contactNum, DateTime dateOfBirth)
        {
            Id= id;
            Name = name;
            ContactNum = contactNum;
            DateOfBirth = dateOfBirth;
        }
    }
}
