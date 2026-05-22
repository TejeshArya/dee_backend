using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeFunds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeFunds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    GivenDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Purpose = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RefNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RecordedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFunds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeFunds_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 31, 26, 402, DateTimeKind.Utc).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 31, 26, 402, DateTimeKind.Utc).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 31, 26, 402, DateTimeKind.Utc).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 31, 26, 402, DateTimeKind.Utc).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 31, 26, 401, DateTimeKind.Utc).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 31, 26, 402, DateTimeKind.Utc).AddTicks(271));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 31, 26, 402, DateTimeKind.Utc).AddTicks(274));

            migrationBuilder.InsertData(
                table: "EmployeeFunds",
                columns: new[] { "Id", "Amount", "CreatedAt", "EmployeeId", "GivenDate", "Purpose", "RecordedBy", "RefNo", "Status" },
                values: new object[,]
                {
                    { 1, 15000.00m, new DateTime(2026, 4, 15, 10, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Office Supplies & Development Kit Reimbursement", "AMANTU", "FT-948274", "Approved" },
                    { 2, 8500.00m, new DateTime(2026, 5, 10, 11, 30, 0, 0, DateTimeKind.Utc), 3, new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Client Site Travel & Accommodation Allowance", "AMANTU", "FT-201847", "Released" },
                    { 3, 12000.00m, new DateTime(2026, 5, 18, 14, 15, 0, 0, DateTimeKind.Utc), 102, new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Technical Certification Fee Reimbursement", "AMANTU", "FT-583921", "Pending" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFunds_EmployeeId",
                table: "EmployeeFunds",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeFunds");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 25, 25, 824, DateTimeKind.Utc).AddTicks(5288));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 25, 25, 824, DateTimeKind.Utc).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 25, 25, 824, DateTimeKind.Utc).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 25, 25, 824, DateTimeKind.Utc).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 25, 25, 824, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 25, 25, 824, DateTimeKind.Utc).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 25, 25, 824, DateTimeKind.Utc).AddTicks(4710));
        }
    }
}
