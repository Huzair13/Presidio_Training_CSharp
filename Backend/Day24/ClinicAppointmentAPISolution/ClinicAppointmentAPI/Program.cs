using ClinicAppointmentAPI.contexts;
using ClinicAppointmentAPI.Interfaces;
using ClinicAppointmentAPI.Models;
using ClinicAppointmentAPI.Repositories;
using ClinicAppointmentAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ClinicAppointmentContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
                );

            builder.Services.AddScoped<IRepository<int, Doctor>, DoctorRepository>();

            builder.Services.AddScoped<IDoctorServices, DoctorBasicServices>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}