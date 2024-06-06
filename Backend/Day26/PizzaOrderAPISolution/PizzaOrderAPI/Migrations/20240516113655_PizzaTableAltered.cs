using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaOrderAPI.Migrations
{
    public partial class PizzaTableAltered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "size",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "crustType",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 201,
                columns: new[] { "crustType", "size" },
                values: new object[] { "Thick", "Medium" });

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 202,
                columns: new[] { "crustType", "size" },
                values: new object[] { "Stuffed", "Large" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "size",
                table: "Pizzas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "crustType",
                table: "Pizzas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 201,
                columns: new[] { "crustType", "size" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 202,
                columns: new[] { "crustType", "size" },
                values: new object[] { 2, 2 });
        }
    }
}
