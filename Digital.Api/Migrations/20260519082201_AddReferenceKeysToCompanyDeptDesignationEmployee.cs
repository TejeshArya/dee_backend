using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddReferenceKeysToCompanyDeptDesignationEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignationOfficerId",
                table: "Employees",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "DesignationOfficers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyGstNumber",
                table: "Departments",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 22, 0, 759, DateTimeKind.Utc).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 22, 0, 759, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 22, 0, 759, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 22, 0, 759, DateTimeKind.Utc).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 22, 0, 759, DateTimeKind.Utc).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 22, 0, 759, DateTimeKind.Utc).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 22, 0, 759, DateTimeKind.Utc).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyGstNumber",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompanyGstNumber",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CompanyGstNumber",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationOfficerId",
                table: "Employees",
                column: "DesignationOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignationOfficers_DepartmentId",
                table: "DesignationOfficers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyGstNumber",
                table: "Departments",
                column: "CompanyGstNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_CompanyGsts_CompanyGstNumber",
                table: "Departments",
                column: "CompanyGstNumber",
                principalTable: "CompanyGsts",
                principalColumn: "GstNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_DesignationOfficers_Departments_DepartmentId",
                table: "DesignationOfficers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DesignationOfficers_DesignationOfficerId",
                table: "Employees",
                column: "DesignationOfficerId",
                principalTable: "DesignationOfficers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_CompanyGsts_CompanyGstNumber",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_DesignationOfficers_Departments_DepartmentId",
                table: "DesignationOfficers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DesignationOfficers_DesignationOfficerId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DesignationOfficerId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_DesignationOfficers_DepartmentId",
                table: "DesignationOfficers");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CompanyGstNumber",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DesignationOfficerId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "DesignationOfficers");

            migrationBuilder.DropColumn(
                name: "CompanyGstNumber",
                table: "Departments");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 4, 39, 321, DateTimeKind.Utc).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 4, 39, 321, DateTimeKind.Utc).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 4, 39, 321, DateTimeKind.Utc).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 4, 39, 321, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 4, 39, 321, DateTimeKind.Utc).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 4, 39, 321, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 19, 8, 4, 39, 321, DateTimeKind.Utc).AddTicks(8534));
        }
    }
}
