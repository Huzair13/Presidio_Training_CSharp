using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAppointmentAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exp = table.Column<double>(type: "float", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DateOfBirth", "Exp", "Image", "Name", "Qualification", "Specialization" },
                values: new object[] { 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(51), 2.0, "", "Huzair", "MBBS", "MD" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DateOfBirth", "Exp", "Image", "Name", "Qualification", "Specialization" },
                values: new object[] { 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(83), 3.0, "", "Ahmed", "MBBS", "ENT" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DateOfBirth", "Exp", "Image", "Name", "Qualification", "Specialization" },
                values: new object[] { 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(13), 4.0, "", "Shree", "MBBS", "MD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
