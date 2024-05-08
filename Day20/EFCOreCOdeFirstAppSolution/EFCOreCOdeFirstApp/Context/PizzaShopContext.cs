using EFCOreCOdeFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCOreCOdeFirstApp.Context
{
    public class PizzaShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-92EC60F\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbPizzaShop");
        }
        public DbSet<Pizza> Pizzas { get; set; }
    }
}
