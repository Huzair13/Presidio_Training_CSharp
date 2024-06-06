using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class C : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dob",
                table: "Testing");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dob",
                table: "Testing",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
