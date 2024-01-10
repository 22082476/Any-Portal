using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserApi.Migrations
{
    /// <inheritdoc />
    public partial class CareTaker2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelMembers_Caretaker_caretakerId",
                table: "PanelMembers");

            migrationBuilder.RenameColumn(
                name: "caretakerId",
                table: "PanelMembers",
                newName: "CaretakerId");

            migrationBuilder.RenameIndex(
                name: "IX_PanelMembers_caretakerId",
                table: "PanelMembers",
                newName: "IX_PanelMembers_CaretakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PanelMembers_Caretaker_CaretakerId",
                table: "PanelMembers",
                column: "CaretakerId",
                principalTable: "Caretaker",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelMembers_Caretaker_CaretakerId",
                table: "PanelMembers");

            migrationBuilder.RenameColumn(
                name: "CaretakerId",
                table: "PanelMembers",
                newName: "caretakerId");

            migrationBuilder.RenameIndex(
                name: "IX_PanelMembers_CaretakerId",
                table: "PanelMembers",
                newName: "IX_PanelMembers_caretakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PanelMembers_Caretaker_caretakerId",
                table: "PanelMembers",
                column: "caretakerId",
                principalTable: "Caretaker",
                principalColumn: "Id");
        }
    }
}
