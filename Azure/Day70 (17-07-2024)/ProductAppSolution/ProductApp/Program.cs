using Microsoft.EntityFrameworkCore;
using ProductApp.Interfaces;
using ProductApp.contexts;
using ProductApp.services;
using ProductApp.Repositories;
using Microsoft.OpenApi.Models;
using ProductApp.Models;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;

namespace ProductApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            const string secretName = "dbConnection";
            var keyVaultName = "kvhuzairnew";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            var secret = await client.GetSecretAsync(secretName);
            Console.WriteLine($"Your secret is '{secret.Value.Value}'.");

            // Add DbContext configuration
            builder.Services.AddDbContext<ProductContext>(options =>
            {
                options.UseSqlServer(secret.Value.Value); 
            });

            //// Add DbContext configuration
            //builder.Services.AddDbContext<ProductContext>(
            //    options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            //);


            // Register services
            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();

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
