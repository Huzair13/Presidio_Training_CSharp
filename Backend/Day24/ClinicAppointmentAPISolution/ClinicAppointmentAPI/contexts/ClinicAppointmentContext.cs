using ClinicAppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentAPI.contexts
{
    public class ClinicAppointmentContext :DbContext
    {
        public ClinicAppointmentContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id=201,Name = "Huzair", DateOfBirth = new DateTime(2002,03,13), Exp = 2, Qualification = "MBBS", Specialization = "MD",Image="" },
                new Doctor() { Id=202,Name = "Ahmed", DateOfBirth = new DateTime(2001,02,12), Exp = 3, Qualification = "MBBS", Specialization = "ENT" ,Image=""},
                new Doctor() { Id=203,Name = "Shree", DateOfBirth = new DateTime(2000,12,12), Exp = 4, Qualification = "MBBS", Specialization = "MD", Image = "" }
        );
        }

    }
}
