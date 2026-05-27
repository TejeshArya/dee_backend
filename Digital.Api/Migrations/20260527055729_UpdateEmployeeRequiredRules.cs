using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeRequiredRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CurrentAddress",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DateOfBirth",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DateOfJoining",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Department",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Designation",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EmergencyName",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EmergencyPhone",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EmergencyRelation",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FullName",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MaritalStatus",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MobileNumber",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OfficialEmail",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PermanentAddress",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Photo",
                table: "EmployeeRequiredRules",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 57, 28, 624, DateTimeKind.Utc).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 57, 28, 624, DateTimeKind.Utc).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 57, 28, 624, DateTimeKind.Utc).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 57, 28, 624, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 57, 28, 624, DateTimeKind.Utc).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 57, 28, 624, DateTimeKind.Utc).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 57, 28, 624, DateTimeKind.Utc).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "EmployeeRequiredRules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CurrentAddress", "DateOfBirth", "DateOfJoining", "Department", "Designation", "EmergencyName", "EmergencyPhone", "EmergencyRelation", "FullName", "Gender", "MaritalStatus", "MobileNumber", "OfficialEmail", "PermanentAddress", "Photo" },
                values: new object[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentAddress",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "DateOfJoining",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "EmergencyName",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "EmergencyPhone",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "EmergencyRelation",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "OfficialEmail",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "EmployeeRequiredRules");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "EmployeeRequiredRules");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 44, 13, 607, DateTimeKind.Utc).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 44, 13, 608, DateTimeKind.Utc).AddTicks(166));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 44, 13, 608, DateTimeKind.Utc).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 44, 13, 608, DateTimeKind.Utc).AddTicks(169));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 44, 13, 607, DateTimeKind.Utc).AddTicks(6886));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 44, 13, 607, DateTimeKind.Utc).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 5, 44, 13, 607, DateTimeKind.Utc).AddTicks(8276));
        }
    }
}
