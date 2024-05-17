using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRequestTrackerAPI.Migrations
{
    public partial class RequestTable_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Employees_RequestClosedBy",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Employees_RequestRaisedBy",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.RenameTable(
                name: "Request",
                newName: "Requests");

            migrationBuilder.RenameIndex(
                name: "IX_Request_RequestRaisedBy",
                table: "Requests",
                newName: "IX_Requests_RequestRaisedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Request_RequestClosedBy",
                table: "Requests",
                newName: "IX_Requests_RequestClosedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "RequestNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestRaisedBy",
                table: "Requests",
                column: "RequestRaisedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestRaisedBy",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "Request");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestRaisedBy",
                table: "Request",
                newName: "IX_Request_RequestRaisedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Request",
                newName: "IX_Request_RequestClosedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "RequestNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Employees_RequestClosedBy",
                table: "Request",
                column: "RequestClosedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Employees_RequestRaisedBy",
                table: "Request",
                column: "RequestRaisedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
