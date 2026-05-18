using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddGstStateCodeToMasterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GstStateCode",
                table: "MasterData",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 5, 47, 48, 77, DateTimeKind.Utc).AddTicks(7253));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 5, 47, 48, 77, DateTimeKind.Utc).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 5, 47, 48, 77, DateTimeKind.Utc).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 5, 47, 48, 77, DateTimeKind.Utc).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 5, 47, 48, 77, DateTimeKind.Utc).AddTicks(5679));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 5, 47, 48, 77, DateTimeKind.Utc).AddTicks(6667));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 5, 47, 48, 77, DateTimeKind.Utc).AddTicks(6669));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GstStateCode",
                table: "MasterData");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 8, 24, 36, 588, DateTimeKind.Utc).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 8, 24, 36, 588, DateTimeKind.Utc).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 8, 24, 36, 588, DateTimeKind.Utc).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 8, 24, 36, 588, DateTimeKind.Utc).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 8, 24, 36, 588, DateTimeKind.Utc).AddTicks(7238));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 8, 24, 36, 588, DateTimeKind.Utc).AddTicks(8224));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 8, 24, 36, 588, DateTimeKind.Utc).AddTicks(8226));
        }
    }
}
