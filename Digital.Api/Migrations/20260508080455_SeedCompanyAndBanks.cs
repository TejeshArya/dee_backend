using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompanyAndBanks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "BankName", "CreatedAt", "Description" },
                values: new object[,]
                {
                    { 1, "STATE BANK OF INDIA", new DateTime(2026, 5, 8, 8, 4, 55, 445, DateTimeKind.Utc).AddTicks(6736), "SBI" },
                    { 2, "HDFC BANK", new DateTime(2026, 5, 8, 8, 4, 55, 445, DateTimeKind.Utc).AddTicks(7254), "HDFC" },
                    { 3, "ICICI BANK", new DateTime(2026, 5, 8, 8, 4, 55, 445, DateTimeKind.Utc).AddTicks(7256), "ICICI" },
                    { 4, "CANARA BANK", new DateTime(2026, 5, 8, 8, 4, 55, 445, DateTimeKind.Utc).AddTicks(7257), "CANARA" }
                });

            migrationBuilder.InsertData(
                table: "CompanyGsts",
                columns: new[] { "GstNumber", "City", "CompanyAddress", "CompanyEstablished", "CompanyName", "CreatedAt", "DealsIn", "Email", "GstStateCode", "GstType", "MobileNumber", "PanNumber", "PinCode", "Remarks", "StateName", "TanNumber" },
                values: new object[,]
                {
                    { "27AADCD1234A1Z1", "", "", null, "DIGITAL NEW ENTERPRISES", new DateTime(2026, 5, 8, 8, 4, 55, 445, DateTimeKind.Utc).AddTicks(5344), "", "contact@digital.com", "", "GST", "9876543210", "", "", "", "Maharashtra", "" },
                    { "27BBBDD4321B1Z2", "", "", null, "TECH SOLUTIONS LTD", new DateTime(2026, 5, 8, 8, 4, 55, 445, DateTimeKind.Utc).AddTicks(6207), "", "info@techsolutions.com", "", "GST", "9988776655", "", "", "", "Karnataka", "" },
                    { "27CCCCD9999C1Z3", "", "", null, "GLOBAL LOGISTICS CORP", new DateTime(2026, 5, 8, 8, 4, 55, 445, DateTimeKind.Utc).AddTicks(6211), "", "support@global.com", "", "GST", "9123456789", "", "", "", "Gujarat", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27AADCD1234A1Z1");

            migrationBuilder.DeleteData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27BBBDD4321B1Z2");

            migrationBuilder.DeleteData(
                table: "CompanyGsts",
                keyColumn: "GstNumber",
                keyValue: "27CCCCD9999C1Z3");
        }
    }
}
