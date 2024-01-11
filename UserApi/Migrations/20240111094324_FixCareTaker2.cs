using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserApi.Migrations
{
    /// <inheritdoc />
    public partial class FixCareTaker2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelMembers_Caretaker_CaretakerId",
                table: "PanelMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caretaker",
                table: "Caretaker");

            migrationBuilder.RenameTable(
                name: "Caretaker",
                newName: "Caretakers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caretakers",
                table: "Caretakers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PanelMembers_Caretakers_CaretakerId",
                table: "PanelMembers",
                column: "CaretakerId",
                principalTable: "Caretakers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelMembers_Caretakers_CaretakerId",
                table: "PanelMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caretakers",
                table: "Caretakers");

            migrationBuilder.RenameTable(
                name: "Caretakers",
                newName: "Caretaker");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caretaker",
                table: "Caretaker",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PanelMembers_Caretaker_CaretakerId",
                table: "PanelMembers",
                column: "CaretakerId",
                principalTable: "Caretaker",
                principalColumn: "Id");
        }
    }
}
