using Microsoft.EntityFrameworkCore;
using PizzaOrderAPI.Models;

namespace PizzaOrderAPI.contexts
{
    public class PizzaOrderContext :DbContext
    {
        public PizzaOrderContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserDetails> UsersDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 101, UserName = "Ramu", DateOfBirth = new DateTime(2000, 2, 12), 
                    MobileNum = "9876456567",Email="Ramu@123",Address="Anna Nagar, Chennai, TamilNadu",Role="User"},
                new User() { UserId = 102, UserName = "Somu", DateOfBirth = new DateTime(2002, 3, 13), 
                    MobileNum = "8777656432", Email = "somu@123", Address = "KK Nagar, Salem, TamilNadu",Role ="Admin" }
                );
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { 
                    PizzaId = 201, 
                    PizzaImage="",
                    Name= "Sizzling Schezwan Chicken",
                    crustType=CrustType.Thick,isVeg=false, 
                    Description= "Loaded with our signature spicy schezwan sauce, juicy schezwan chicken meatballs & 100% mozzarella cheese",
                    size=PizzaSize.Medium,
                    Price=205,
                    PizzasInStock=10 },
                new Pizza()
                {
                    PizzaId = 202,
                    PizzaImage = "",
                    Name = "Awesome American Cheesy Chicken",
                    crustType = CrustType.Stuffed,
                    isVeg = false,
                    Description = "Topped with classic chicken pepperoni, cheese and chicken sausage black olives, spicy jalapeno and 100% mozzarella cheese",
                    size = PizzaSize.Large,
                    Price = 285,
                    PizzasInStock = 7
                }
                );
        }
    }
}
