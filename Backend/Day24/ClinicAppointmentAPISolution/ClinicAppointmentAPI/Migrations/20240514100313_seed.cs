using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAppointmentAPI.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateOfBirth",
                value: new DateTime(2002, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateOfBirth",
                value: new DateTime(2001, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateOfBirth",
                value: new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateOfBirth",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateOfBirth",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateOfBirth",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(13));
        }
    }
}
