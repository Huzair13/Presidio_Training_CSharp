using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaOrderAPI.Migrations
{
    public partial class AvailablePropertyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isAvailable",
                table: "Pizzas",
                newName: "isPizzaAvailable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isPizzaAvailable",
                table: "Pizzas",
                newName: "isAvailable");
        }
    }
}
