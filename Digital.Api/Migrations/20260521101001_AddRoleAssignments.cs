using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    GroupName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    PostTitle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Wing = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Dept = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    LocationName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmployeeCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Desc = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAssignments", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "RoleAssignments",
                columns: new[] { "Id", "Date", "Dept", "Desc", "EmployeeCode", "EmployeeId", "EmployeeName", "GroupId", "GroupName", "LocationId", "LocationName", "PostId", "PostTitle", "Wing" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "P & P", "DEVELOPER", "DEE300426132", 1, "TEJESH GUDLA", 12, "JUNIOR ENGINEER", 1, "VISAKHAPATNAM", 1, "SOFTWARE DEVELOPER3", "ELECTRICAL" },
                    { 2, new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), "P & P", "Welder", "DEE130426131", 2, "GANDIBOINA GOWRI PRASAD", 15, "TECHNICIAN", 1, "VISAKHAPATNAM", 2, "Welder", "CIVIL" },
                    { 3, new DateTime(2026, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), "P & P", "DEE HQ OFFICE ADMINISTRATIVE", "DEE040426129", 3, "SAYAD SARFARAZ", 14, "ASSISTANT SUPERVISOR", 1, "VISAKHAPATNAM", 3, "DEE HQ OFFICE ADMINISTRATOR", "ELECTRICAL" },
                    { 4, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), "P & P", "desc", "DEE030426128", 4, "KANDREGULA KOTESWARA RAO", 15, "TECHNICIAN", 1, "VISAKHAPATNAM", 4, "ELECTRICAL TECHNICIAN", "ELECTRICAL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleAssignments");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 37, 30, 414, DateTimeKind.Utc).AddTicks(7108));
        }
    }
}
