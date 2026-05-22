using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Departments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Departments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(7108));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name", "Status" },
                values: new object[] { new DateTime(2025, 12, 22, 5, 57, 0, 0, DateTimeKind.Utc), "DSEC", "HR", true });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "Status" },
                values: new object[] { new DateTime(2025, 12, 22, 5, 57, 0, 0, DateTimeKind.Utc), "DSEC", "IT", true });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name", "Status" },
                values: new object[] { new DateTime(2025, 12, 22, 5, 58, 0, 0, DateTimeKind.Utc), "DESCRIPTION", "SALES", true });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name", "Status", "CompanyGstNumber" },
                values: new object[] { new DateTime(2025, 12, 22, 5, 58, 0, 0, DateTimeKind.Utc), "RESEARCH AND DEVELOPMENT", "R & D", true, "27AADCD1234A1Z1" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name", "Status", "CompanyGstNumber" },
                values: new object[] { new DateTime(2025, 12, 22, 5, 59, 0, 0, DateTimeKind.Utc), "PLANNING AND PRODUCTION", "P & P", true, "27AADCD1234A1Z1" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "Name", "Status", "CompanyGstNumber" },
                values: new object[] { new DateTime(2025, 12, 22, 5, 59, 0, 0, DateTimeKind.Utc), "ACCOUNTS", "ACCOUNTS", true, "27AADCD1234A1Z1" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Name", "Status", "CompanyGstNumber" },
                values: new object[] { new DateTime(2026, 4, 4, 23, 32, 0, 0, DateTimeKind.Utc), "CIVIL WORK", "CIVIL DEPARTMENT", true, "27AADCD1234A1Z1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Departments");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(4122));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(3044));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "P & P");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "CIVIL DEPARTMENT");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "IT");
        }
    }
}
