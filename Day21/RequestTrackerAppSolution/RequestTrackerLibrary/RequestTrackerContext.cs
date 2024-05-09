﻿using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerLibrary
{
        public class RequestTrackerContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-92EC60F\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbEmployeeTrackerCF;");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Request> Requests { get; set; }

        public DbSet<Testing> Testing { get; set; }
        public DbSet<Testing2> Testing2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 101, Name = "Ramu", Password = "ramu123", Role = "Admin" },
                new Employee { Id = 102, Name = "Somu", Password = "somu123", Role = "Admin" },
                new Employee { Id = 103, Name = "Bimu", Password = "bimu123", Role = "User" }
                );

            modelBuilder.Entity<Request>().HasKey(r => r.RequestNumber);

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RaisedByEmployee)
               .WithMany(e => e.RequestsRaised)
               .HasForeignKey(r => r.RequestRaisedBy)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RequestClosedByEmployee)
               .WithMany(e => e.RequestsClosed)
               .HasForeignKey(r => r.RequestClosedBy)
               .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
