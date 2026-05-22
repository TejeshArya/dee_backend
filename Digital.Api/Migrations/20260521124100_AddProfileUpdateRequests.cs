using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileUpdateRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileUpdateRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    FieldName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OldValue = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    NewValue = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RejectionReason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    RequestedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReviewedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ReviewedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileUpdateRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileUpdateRequests_Employees_EmployeeId",
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
                value: new DateTime(2026, 5, 21, 12, 40, 59, 470, DateTimeKind.Utc).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 40, 59, 470, DateTimeKind.Utc).AddTicks(703));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 40, 59, 470, DateTimeKind.Utc).AddTicks(704));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 40, 59, 470, DateTimeKind.Utc).AddTicks(705));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 40, 59, 469, DateTimeKind.Utc).AddTicks(8842));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 40, 59, 469, DateTimeKind.Utc).AddTicks(9702));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 40, 59, 469, DateTimeKind.Utc).AddTicks(9704));

            migrationBuilder.InsertData(
                table: "ProfileUpdateRequests",
                columns: new[] { "Id", "EmployeeId", "FieldName", "NewValue", "OldValue", "RejectionReason", "RequestedAt", "ReviewedAt", "ReviewedBy", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Role", "SENIOR ENGINEER", "JUNIOR ENGINEER", null, new DateTime(2026, 5, 19, 9, 0, 0, 0, DateTimeKind.Utc), null, null, "Pending" },
                    { 2, 3, "Qualification", "B.Tech Civil Engineering", null, null, new DateTime(2026, 5, 20, 11, 30, 0, 0, DateTimeKind.Utc), null, null, "Pending" },
                    { 3, 102, "Email", "a.kumar@digital.com", "anupam.kumar@digital.com", null, new DateTime(2026, 5, 21, 8, 0, 0, 0, DateTimeKind.Utc), null, null, "Pending" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileUpdateRequests_EmployeeId",
                table: "ProfileUpdateRequests",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileUpdateRequests");

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
        }
    }
}
