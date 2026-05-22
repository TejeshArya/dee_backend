using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPostsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    GroupName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Wing = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Dept = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Desc = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(4122));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(3044));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 19, 9, 505, DateTimeKind.Utc).AddTicks(3048));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Date", "Dept", "Desc", "GroupId", "GroupName", "Title", "Wing" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "P & P", "DEVELOPER", 12, "JUNIOR ENGINEER", "SOFTWARE DEVELOPER3", "ELECTRICAL" },
                    { 2, new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), "P & P", "Welder", 15, "TECHNICIAN", "Welder", "CIVIL" },
                    { 3, new DateTime(2026, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), "P & P", "DEE HQ OFFICE ADMINISTRATOR", 14, "ASSISTANT SUPERVISOR", "DEE HQ OFFICE ADMINISTRATOR", "ELECTRICAL" },
                    { 4, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), "P & P", "ELECTRICAL TECHNICIAN", 15, "TECHNICIAN", "ELECTRICAL TECHNICIAN", "ELECTRICAL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 10, 29, 102, DateTimeKind.Utc).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 10, 29, 102, DateTimeKind.Utc).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 10, 29, 102, DateTimeKind.Utc).AddTicks(2675));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 10, 29, 102, DateTimeKind.Utc).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 10, 29, 102, DateTimeKind.Utc).AddTicks(562));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 10, 29, 102, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 21, 9, 10, 29, 102, DateTimeKind.Utc).AddTicks(1526));
        }
    }
}
