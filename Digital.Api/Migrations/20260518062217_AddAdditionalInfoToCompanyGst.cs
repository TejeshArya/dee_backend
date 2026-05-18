using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalInfoToCompanyGst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CompanyGsts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterPath",
                table: "CompanyGsts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeaderPath",
                table: "CompanyGsts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "CompanyGsts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryMobileNo",
                table: "CompanyGsts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 6, 22, 17, 232, DateTimeKind.Utc).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 6, 22, 17, 232, DateTimeKind.Utc).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 6, 22, 17, 232, DateTimeKind.Utc).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 18, 6, 22, 17, 232, DateTimeKind.Utc).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                columns: new[] { "Color", "CreatedAt", "FooterPath", "HeaderPath", "LogoPath", "SecondaryMobileNo" },
                values: new object[] { "", new DateTime(2026, 5, 18, 6, 22, 17, 231, DateTimeKind.Utc).AddTicks(8751), "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                columns: new[] { "Color", "CreatedAt", "FooterPath", "HeaderPath", "LogoPath", "SecondaryMobileNo" },
                values: new object[] { "", new DateTime(2026, 5, 18, 6, 22, 17, 231, DateTimeKind.Utc).AddTicks(9690), "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                columns: new[] { "Color", "CreatedAt", "FooterPath", "HeaderPath", "LogoPath", "SecondaryMobileNo" },
                values: new object[] { "", new DateTime(2026, 5, 18, 6, 22, 17, 231, DateTimeKind.Utc).AddTicks(9691), "", "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "CompanyGsts");

            migrationBuilder.DropColumn(
                name: "FooterPath",
                table: "CompanyGsts");

            migrationBuilder.DropColumn(
                name: "HeaderPath",
                table: "CompanyGsts");

            migrationBuilder.DropColumn(
                name: "LogoPath",
                table: "CompanyGsts");

            migrationBuilder.DropColumn(
                name: "SecondaryMobileNo",
                table: "CompanyGsts");

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
    }
}
