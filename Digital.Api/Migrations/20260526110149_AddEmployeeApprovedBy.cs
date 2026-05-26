using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeApprovedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 11, 1, 48, 428, DateTimeKind.Utc).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 11, 1, 48, 428, DateTimeKind.Utc).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 11, 1, 48, 428, DateTimeKind.Utc).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 11, 1, 48, 428, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 11, 1, 48, 428, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 11, 1, 48, 428, DateTimeKind.Utc).AddTicks(3192));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 11, 1, 48, 428, DateTimeKind.Utc).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                column: "ApprovedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102,
                column: "ApprovedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103,
                column: "ApprovedBy",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 10, 56, 14, 248, DateTimeKind.Utc).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 10, 56, 14, 248, DateTimeKind.Utc).AddTicks(2899));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 10, 56, 14, 248, DateTimeKind.Utc).AddTicks(2900));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 10, 56, 14, 248, DateTimeKind.Utc).AddTicks(2902));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 10, 56, 14, 248, DateTimeKind.Utc).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 10, 56, 14, 248, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 26, 10, 56, 14, 248, DateTimeKind.Utc).AddTicks(1758));
        }
    }
}
