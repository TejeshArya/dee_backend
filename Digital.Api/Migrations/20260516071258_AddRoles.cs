using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Permissions = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 7, 12, 57, 299, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 7, 12, 57, 299, DateTimeKind.Utc).AddTicks(5492));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 7, 12, 57, 299, DateTimeKind.Utc).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 7, 12, 57, 299, DateTimeKind.Utc).AddTicks(5495));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 7, 12, 57, 299, DateTimeKind.Utc).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 7, 12, 57, 299, DateTimeKind.Utc).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 7, 12, 57, 299, DateTimeKind.Utc).AddTicks(4373));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "DisplayName", "Name", "Permissions" },
                values: new object[,]
                {
                    { 1, "Full system access", "Administrator", "admin", "" },
                    { 2, "ADMIN", "DIRECTOR", "DIRECTOR", "" },
                    { 3, "DESC", "MANAGING DIRECTOR", "MANAGING DIRECTOR", "" },
                    { 4, "HR", "HR", "HR", "" },
                    { 5, "IT DEPARTMENT", "IT", "IT", "" },
                    { 6, "DESCRIPTION", "SENIOR MANAGER", "SENIOR MANAGER", "" },
                    { 7, "DESCRIPTION", "MANAGER", "MANAGER", "" },
                    { 8, "DESCRIPTION", "ASSISTANT MANAGER", "ASSISTANT MANAGER", "" },
                    { 9, "DESCRIPTION", "JUNIOR MANAGER", "JUNIOR MANAGER", "" },
                    { 10, "DESCRIPTION", "SENIOR ENGINEER", "SENIOR ENGINEER", "" },
                    { 11, "DESCRIPTION", "ENGINEER", "ENGINEER", "" },
                    { 12, "DESCRIPTION", "JUNIOR ENGINEER", "JUNIOR ENGINEER", "" },
                    { 13, "DESCRIPTION", "SUPERVISOR", "SUPERVISOR", "" },
                    { 14, "DESCRIPTION", "ASSISTANT SUPERVISOR", "ASSISTANT SUPERVISOR", "" },
                    { 15, "DESCRIPTION", "TECHNICIAN", "TECHNICIAN", "" },
                    { 16, "DESCRIPTION", "HELPER", "HELPER", "" },
                    { 17, "DESCRIPTION", "UNDER TRAINING", "UNDER TRAINING", "" },
                    { 18, "Default user access", "User", "User", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 15, 12, 6, 0, 797, DateTimeKind.Utc).AddTicks(2945));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 15, 12, 6, 0, 797, DateTimeKind.Utc).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 15, 12, 6, 0, 797, DateTimeKind.Utc).AddTicks(3632));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 15, 12, 6, 0, 797, DateTimeKind.Utc).AddTicks(3633));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 15, 12, 6, 0, 797, DateTimeKind.Utc).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 15, 12, 6, 0, 797, DateTimeKind.Utc).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3",
                column: "CreatedAt",
                value: new DateTime(2026, 5, 15, 12, 6, 0, 797, DateTimeKind.Utc).AddTicks(2294));
        }
    }
}
