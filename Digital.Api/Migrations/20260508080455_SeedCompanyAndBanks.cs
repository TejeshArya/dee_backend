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
                columns: new[] { "Id", "BankName", "Description", "CreatedAt" },
                values: new object[,]
                {
                    { 1, "STATE BANK OF INDIA", "SBI", DateTime.UtcNow },
                    { 2, "HDFC BANK", "HDFC", DateTime.UtcNow },
                    { 3, "ICICI BANK", "ICICI", DateTime.UtcNow },
                    { 4, "CANARA BANK", "CANARA", DateTime.UtcNow }
                });

            migrationBuilder.InsertData(
                table: "CompanyGsts",
                columns: new[] { "GstNumber", "GstStateCode", "CompanyName", "PanNumber", "TanNumber", "MobileNumber", "StateName", "Email", "PinCode", "CompanyAddress", "Remarks", "City", "GstType", "DealsIn", "CreatedAt" },
                values: new object[,]
                {
                    { "27AADCD1234A1Z1", "27", "DIGITAL NEW ENTERPRISES", "AADCD1234A", "TAN12345", "9876543210", "Maharashtra", "contact@digital.com", "400001", "Mumbai Address", "Remarks", "Mumbai", "Regular", "Services", DateTime.UtcNow },
                    { "27BBBDD4321B1Z2", "27", "TECH SOLUTIONS LTD", "BBBDD4321B", "TAN54321", "9988776655", "Karnataka", "info@techsolutions.com", "560001", "Bangalore Address", "Remarks", "Bangalore", "Regular", "IT Services", DateTime.UtcNow },
                    { "27CCCCD9999C1Z3", "27", "GLOBAL LOGISTICS CORP", "CCCCD9999C", "TAN99999", "9123456789", "Gujarat", "support@global.com", "380001", "Ahmedabad Address", "Remarks", "Ahmedabad", "Regular", "Logistics", DateTime.UtcNow }
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
