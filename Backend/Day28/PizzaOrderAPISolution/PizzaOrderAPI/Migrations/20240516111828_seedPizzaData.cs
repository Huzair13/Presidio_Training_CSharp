using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaOrderAPI.Migrations
{
    public partial class seedPizzaData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 201,
                column: "isAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 202,
                column: "isAvailable",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 201,
                column: "isAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 202,
                column: "isAvailable",
                value: false);
        }
    }
}
