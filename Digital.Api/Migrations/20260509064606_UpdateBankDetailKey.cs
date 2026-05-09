using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBankDetailKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BankDetails",
                table: "BankDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BankDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankDetails",
                table: "BankDetails",
                column: "EmpId");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 6, 46, 5, 567, DateTimeKind.Utc).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 6, 46, 5, 567, DateTimeKind.Utc).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 6, 46, 5, 567, DateTimeKind.Utc).AddTicks(1790));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 6, 46, 5, 567, DateTimeKind.Utc).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 6, 46, 5, 566, DateTimeKind.Utc).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 6, 46, 5, 567, DateTimeKind.Utc).AddTicks(483));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 6, 46, 5, 567, DateTimeKind.Utc).AddTicks(484));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BankDetails",
                table: "BankDetails");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BankDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankDetails",
                table: "BankDetails",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 5, 53, 6, 312, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 5, 53, 6, 312, DateTimeKind.Utc).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 5, 53, 6, 312, DateTimeKind.Utc).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 5, 53, 6, 312, DateTimeKind.Utc).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 5, 53, 6, 312, DateTimeKind.Utc).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 5, 53, 6, 312, DateTimeKind.Utc).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 9, 5, 53, 6, 312, DateTimeKind.Utc).AddTicks(4305));
        }
    }
}
