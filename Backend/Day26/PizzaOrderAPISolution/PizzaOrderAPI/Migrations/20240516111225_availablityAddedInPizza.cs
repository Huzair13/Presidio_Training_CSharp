using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaOrderAPI.Migrations
{
    public partial class availablityAddedInPizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAvailable",
                table: "Pizzas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAvailable",
                table: "Pizzas");
        }
    }
}
