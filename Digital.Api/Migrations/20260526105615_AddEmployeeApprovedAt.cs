using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeApprovedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedAt",
                table: "Employees",
                type: "timestamp without time zone",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101,
                column: "ApprovedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102,
                column: "ApprovedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103,
                column: "ApprovedAt",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 23, 6, 32, 5, 947, DateTimeKind.Utc).AddTicks(7308));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 23, 6, 32, 5, 947, DateTimeKind.Utc).AddTicks(7815));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 23, 6, 32, 5, 947, DateTimeKind.Utc).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 23, 6, 32, 5, 947, DateTimeKind.Utc).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 23, 6, 32, 5, 947, DateTimeKind.Utc).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 23, 6, 32, 5, 947, DateTimeKind.Utc).AddTicks(6806));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 23, 6, 32, 5, 947, DateTimeKind.Utc).AddTicks(6808));
        }
    }
}
