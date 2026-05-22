using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationHeads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationHeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationHeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationHeads_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationHeads_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 22, 36, 923, DateTimeKind.Utc).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 22, 36, 923, DateTimeKind.Utc).AddTicks(6731));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 22, 36, 923, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 22, 36, 923, DateTimeKind.Utc).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 22, 36, 923, DateTimeKind.Utc).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 22, 36, 923, DateTimeKind.Utc).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 12, 22, 36, 923, DateTimeKind.Utc).AddTicks(5757));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AnnualSalary", "CreatedAt", "DepartmentId", "DesignationOfficerId", "Email", "EmployeeId", "LocationId", "Name", "Qualification", "Remarks", "Role", "Status", "TemporaryPassword", "UpdatedAt" },
                values: new object[,]
                {
                    { 101, null, new DateTime(2026, 3, 31, 13, 2, 0, 0, DateTimeKind.Utc), null, null, "ranjan.yadav@digital.com", "DEE010126115", 1, "RANJAN YADAV", null, null, "Location Head", "Active", null, null },
                    { 102, null, new DateTime(2025, 12, 30, 6, 40, 15, 0, DateTimeKind.Utc), null, null, "anupam.kumar@digital.com", "DEE251225102", 3, "ANUPAM KUMAR", null, null, "Location Head", "Active", null, null },
                    { 103, null, new DateTime(2026, 3, 31, 14, 26, 42, 0, DateTimeKind.Utc), null, null, "sanjay.mahato@digital.com", "DEE251225103", 5, "SANJAY KUMAR MAHATO", null, null, "Location Head", "Active", null, null }
                });

            migrationBuilder.InsertData(
                table: "LocationHeads",
                columns: new[] { "Id", "AssignedAt", "EmployeeId", "LocationId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 31, 13, 2, 0, 0, DateTimeKind.Utc), 101, 1 },
                    { 2, new DateTime(2026, 4, 1, 4, 39, 0, 0, DateTimeKind.Utc), 102, 3 },
                    { 3, new DateTime(2026, 4, 1, 4, 39, 0, 0, DateTimeKind.Utc), 102, 2 },
                    { 4, new DateTime(2026, 4, 3, 4, 0, 0, 0, DateTimeKind.Utc), 103, 5 },
                    { 5, new DateTime(2026, 4, 3, 4, 15, 0, 0, DateTimeKind.Utc), 101, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationHeads_EmployeeId",
                table: "LocationHeads",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationHeads_LocationId",
                table: "LocationHeads",
                column: "LocationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationHeads");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 39, 19, 922, DateTimeKind.Utc).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 39, 19, 922, DateTimeKind.Utc).AddTicks(7464));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 39, 19, 922, DateTimeKind.Utc).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 39, 19, 922, DateTimeKind.Utc).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 39, 19, 922, DateTimeKind.Utc).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 39, 19, 922, DateTimeKind.Utc).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 11, 39, 19, 922, DateTimeKind.Utc).AddTicks(6137));
        }
    }
}
