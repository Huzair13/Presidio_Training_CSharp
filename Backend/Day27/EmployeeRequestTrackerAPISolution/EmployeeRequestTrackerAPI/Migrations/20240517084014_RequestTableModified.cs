using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRequestTrackerAPI.Migrations
{
    public partial class RequestTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestNumber",
                table: "Requests",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Requests",
                newName: "RequestNumber");
        }
    }
}
