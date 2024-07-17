using Microsoft.EntityFrameworkCore;
using ProductApp.Models;

namespace ProductApp.contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id=100,
                    Name="Mouse",
                    Description = "HP Mouse",
                    Price =500,
                    imageURL = "https://sachuzair.blob.core.windows.net/productcontainer/pexels-craigmdennis-205421.jpg"
                },
                new Product()
                {
                    Id = 101,
                    Name = "Laptop",
                    Description = "DELL Laptop",
                    Price = 50000,
                    imageURL= "https://sachuzair.blob.core.windows.net/productcontainer/pexels-johnpet-2115256.jpg"
                }
                );

            modelBuilder.Entity<Product>()
                        .Property(p => p.Price)
                        .HasColumnType("decimal(18, 2)");
        }
    }
}
