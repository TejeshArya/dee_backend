using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSubLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubLocations_Locations_LocationId",
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

            migrationBuilder.UpdateData(
                table: "RoleAssignments",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTitle",
                value: "ELECTRICAL INTEGRATION");

            migrationBuilder.InsertData(
                table: "SubLocations",
                columns: new[] { "Id", "CreatedAt", "Description", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), "GRSE FOJ", 4, "GRSE FOJ" },
                    { 2, new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Utc), "AFLS MUSTERING POINT", 1, "INS DEGA BLD" },
                    { 3, new DateTime(2025, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), "N/A", 3, "LION GATE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubLocations_LocationId",
                table: "SubLocations",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubLocations");

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
                table: "RoleAssignments",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTitle",
                value: "ELECTRICAL TECHNICIAN");
        }
    }
}
