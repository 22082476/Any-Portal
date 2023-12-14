using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchApi.Migrations
{
    /// <inheritdoc />
    public partial class een : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "compensation",
                table: "Research",
                newName: "Compensation");

            migrationBuilder.AddColumn<string>(
                name: "Allowed_AgeRange",
                table: "Research",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Disabillity_Type",
                table: "Research",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Participant",
                table: "Research",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allowed_AgeRange",
                table: "Research");

            migrationBuilder.DropColumn(
                name: "Disabillity_Type",
                table: "Research");

            migrationBuilder.DropColumn(
                name: "Participant",
                table: "Research");

            migrationBuilder.RenameColumn(
                name: "Compensation",
                table: "Research",
                newName: "compensation");
        }
    }
}
