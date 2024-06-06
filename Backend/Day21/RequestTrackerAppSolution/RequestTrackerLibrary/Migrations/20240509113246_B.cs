using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class B : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Testing",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "Testing");
        }
    }
}
