using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Locations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 34, 51, 472, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 34, 51, 472, DateTimeKind.Utc).AddTicks(9703));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 34, 51, 472, DateTimeKind.Utc).AddTicks(9705));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 34, 51, 472, DateTimeKind.Utc).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 34, 51, 472, DateTimeKind.Utc).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 34, 51, 472, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 34, 51, 472, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 12, 19, 11, 0, 18, 0, DateTimeKind.Utc), "Main Office Location" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2025, 12, 24, 2, 42, 58, 0, DateTimeKind.Utc), "DESC", "KARWAR" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 3, new DateTime(2025, 12, 30, 6, 40, 15, 0, DateTimeKind.Utc), "MUMBAI", "MUMBAI" },
                    { 4, new DateTime(2026, 1, 2, 6, 1, 30, 0, DateTimeKind.Utc), "WEST BENGAL", "KOLKATA" },
                    { 5, new DateTime(2026, 3, 31, 14, 26, 42, 0, DateTimeKind.Utc), "JAMNAGAR", "JAMNAGAR" },
                    { 6, new DateTime(2026, 3, 31, 14, 28, 28, 0, DateTimeKind.Utc), "KOCHIN", "KOCHIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Locations");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 10, 10, 0, 22, DateTimeKind.Utc).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 10, 10, 0, 23, DateTimeKind.Utc).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 10, 10, 0, 23, DateTimeKind.Utc).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 10, 10, 0, 23, DateTimeKind.Utc).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 10, 10, 0, 22, DateTimeKind.Utc).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 10, 10, 0, 22, DateTimeKind.Utc).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 10, 10, 0, 22, DateTimeKind.Utc).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "JAMNAGAR");
        }
    }
}
