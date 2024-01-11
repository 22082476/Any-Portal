using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserApi.Migrations
{
    /// <inheritdoc />
    public partial class FixVoogd4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelMembers_Caretakers_CaretakerId",
                table: "PanelMembers");

            migrationBuilder.DropIndex(
                name: "IX_PanelMembers_CaretakerId",
                table: "PanelMembers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PanelMembers_CaretakerId",
                table: "PanelMembers",
                column: "CaretakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PanelMembers_Caretakers_CaretakerId",
                table: "PanelMembers",
                column: "CaretakerId",
                principalTable: "Caretakers",
                principalColumn: "Id");
        }
    }
}
