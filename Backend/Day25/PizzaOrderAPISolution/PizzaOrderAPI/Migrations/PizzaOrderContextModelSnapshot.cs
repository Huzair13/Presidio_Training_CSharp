﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaOrderAPI.contexts;

#nullable disable

namespace PizzaOrderAPI.Migrations
{
    [DbContext(typeof(PizzaOrderContext))]
    partial class PizzaOrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PizzaOrderAPI.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("OrderDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("totalOrderPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaOrderAPI.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("PizzaOrderAPI.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PizzaId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PizzaImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PizzasInStock")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("crustType")
                        .HasColumnType("int");

                    b.Property<bool>("isVeg")
                        .HasColumnType("bit");

                    b.Property<int>("size")
                        .HasColumnType("int");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            PizzaId = 201,
                            Description = "Loaded with our signature spicy schezwan sauce, juicy schezwan chicken meatballs & 100% mozzarella cheese",
                            Name = "Sizzling Schezwan Chicken",
                            PizzaImage = "",
                            PizzasInStock = 10,
                            Price = 205m,
                            crustType = 1,
                            isVeg = false,
                            size = 1
                        },
                        new
                        {
                            PizzaId = 202,
                            Description = "Topped with classic chicken pepperoni, cheese and chicken sausage black olives, spicy jalapeno and 100% mozzarella cheese",
                            Name = "Awesome American Cheesy Chicken",
                            PizzaImage = "",
                            PizzasInStock = 7,
                            Price = 285m,
                            crustType = 2,
                            isVeg = false,
                            size = 2
                        });
                });

            modelBuilder.Entity("PizzaOrderAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 101,
                            Address = "Anna Nagar, Chennai, TamilNadu",
                            DateOfBirth = new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Ramu@123",
                            MobileNum = "9876456567",
                            Role = "User",
                            UserName = "Ramu"
                        },
                        new
                        {
                            UserId = 102,
                            Address = "KK Nagar, Salem, TamilNadu",
                            DateOfBirth = new DateTime(2002, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "somu@123",
                            MobileNum = "8777656432",
                            Role = "Admin",
                            UserName = "Somu"
                        });
                });

            modelBuilder.Entity("PizzaOrderAPI.Models.UserDetails", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordHashKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("UserId");

                    b.ToTable("UsersDetails");
                });

            modelBuilder.Entity("PizzaOrderAPI.Models.Order", b =>
                {
                    b.HasOne("PizzaOrderAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PizzaOrderAPI.Models.OrderItem", b =>
                {
                    b.HasOne("PizzaOrderAPI.Models.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.HasOne("PizzaOrderAPI.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaOrderAPI.Models.UserDetails", b =>
                {
                    b.HasOne("PizzaOrderAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PizzaOrderAPI.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
