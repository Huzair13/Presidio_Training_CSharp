using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicAppointmentDALLibrary.Model
{
    public partial class dbClinicAppointmentContext : DbContext
    {
        public dbClinicAppointmentContext()
        {
        }

        public dbClinicAppointmentContext(DbContextOptions<dbClinicAppointmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-92EC60F\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbClinicAppointment");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentId).ValueGeneratedNever();

                entity.Property(e => e.AppointmentDateTime).HasColumnType("datetime");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("fk_doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("fk_patient");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Age).HasComputedColumnSql("(datediff(year,[DateOfBirth],getdate())-case when dateadd(year,datediff(year,[DateOfBirth],getdate()),[DateOfBirth])>getdate() then (1) else (0) end)", false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Specialization)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Admitdate)
                    .HasColumnType("date")
                    .HasColumnName("admitdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasComputedColumnSql("(datediff(year,[dateofbirth],getdate())-case when dateadd(year,datediff(year,[dateofbirth],getdate()),[dateofbirth])>getdate() then (1) else (0) end)", false);

                entity.Property(e => e.Contactnum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("contactnum")
                    .IsFixedLength();

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("date")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("purpose");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
