using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserApi.Migrations
{
    /// <inheritdoc />
    public partial class Vierde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelMembers_AgeRanges_AgeRangeName",
                table: "PanelMembers");

            migrationBuilder.DropIndex(
                name: "IX_PanelMembers_AgeRangeName",
                table: "PanelMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgeRanges",
                table: "AgeRanges");

            migrationBuilder.DropColumn(
                name: "AgeRangeName",
                table: "PanelMembers");

            migrationBuilder.DropColumn(
                name: "RangeName",
                table: "AgeRanges");

            migrationBuilder.AddColumn<int>(
                name: "AgeId",
                table: "PanelMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgeId",
                table: "AgeRanges",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgeRanges",
                table: "AgeRanges",
                column: "AgeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AgeRanges",
                table: "AgeRanges");

            migrationBuilder.DropColumn(
                name: "AgeId",
                table: "PanelMembers");

            migrationBuilder.DropColumn(
                name: "AgeId",
                table: "AgeRanges");

            migrationBuilder.AddColumn<string>(
                name: "AgeRangeName",
                table: "PanelMembers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RangeName",
                table: "AgeRanges",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgeRanges",
                table: "AgeRanges",
                column: "RangeName");

            migrationBuilder.CreateIndex(
                name: "IX_PanelMembers_AgeRangeName",
                table: "PanelMembers",
                column: "AgeRangeName");

            migrationBuilder.AddForeignKey(
                name: "FK_PanelMembers_AgeRanges_AgeRangeName",
                table: "PanelMembers",
                column: "AgeRangeName",
                principalTable: "AgeRanges",
                principalColumn: "RangeName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
