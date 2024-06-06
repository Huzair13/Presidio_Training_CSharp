using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRequestTrackerAPI.Migrations
{
    public partial class RequestTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestRaisedBy = table.Column<int>(type: "int", nullable: false),
                    RequestClosedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestNumber);
                    table.ForeignKey(
                        name: "FK_Request_Employees_RequestClosedBy",
                        column: x => x.RequestClosedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Employees_RequestRaisedBy",
                        column: x => x.RequestRaisedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestClosedBy",
                table: "Request",
                column: "RequestClosedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestRaisedBy",
                table: "Request",
                column: "RequestRaisedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Request");
        }
    }
}
