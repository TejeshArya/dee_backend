using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeRequiredRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeRequiredRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeCode = table.Column<bool>(type: "boolean", nullable: false),
                    Location = table.Column<bool>(type: "boolean", nullable: false),
                    AnnualSalary = table.Column<bool>(type: "boolean", nullable: false),
                    CoreQualification = table.Column<bool>(type: "boolean", nullable: false),
                    Remarks = table.Column<bool>(type: "boolean", nullable: false),
                    BloodGroup = table.Column<bool>(type: "boolean", nullable: false),
                    Religion = table.Column<bool>(type: "boolean", nullable: false),
                    Category = table.Column<bool>(type: "boolean", nullable: false),
                    AlternateNumber = table.Column<bool>(type: "boolean", nullable: false),
                    AadharNumber = table.Column<bool>(type: "boolean", nullable: false),
                    PanNumber = table.Column<bool>(type: "boolean", nullable: false),
                    UanNumber = table.Column<bool>(type: "boolean", nullable: false),
                    EsicNumber = table.Column<bool>(type: "boolean", nullable: false),
                    PassportNumber = table.Column<bool>(type: "boolean", nullable: false),
                    PvcNumber = table.Column<bool>(type: "boolean", nullable: false),
                    BankDetails = table.Column<bool>(type: "boolean", nullable: false),
                    NomineeDetails = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRequiredRules", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "EmployeeRequiredRules",
                columns: new[] { "Id", "AadharNumber", "AlternateNumber", "AnnualSalary", "BankDetails", "BloodGroup", "Category", "CoreQualification", "EmployeeCode", "EsicNumber", "Location", "NomineeDetails", "PanNumber", "PassportNumber", "PvcNumber", "Religion", "Remarks", "UanNumber" },
                values: new object[] { 1, true, false, false, true, true, true, true, false, false, false, false, true, false, false, false, false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeRequiredRules");

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
        }
    }
}
