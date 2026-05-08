using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Api.Migrations
{
    /// <inheritdoc />
    public partial class RedesignSubGst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "SubGsts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "SubGsts");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "SubGsts",
                newName: "OfficerName");

            migrationBuilder.RenameColumn(
                name: "PinCode",
                table: "SubGsts",
                newName: "GstNumber");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "SubGsts",
                newName: "Department");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "SubGsts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SubGsts");

            migrationBuilder.RenameColumn(
                name: "OfficerName",
                table: "SubGsts",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "GstNumber",
                table: "SubGsts",
                newName: "PinCode");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "SubGsts",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "SubGsts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SubGsts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
