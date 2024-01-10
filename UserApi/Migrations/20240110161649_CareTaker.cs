using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserApi.Migrations
{
    /// <inheritdoc />
    public partial class CareTaker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "caretakerId",
                table: "PanelMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Caretaker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caretaker", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PanelMembers_caretakerId",
                table: "PanelMembers",
                column: "caretakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PanelMembers_Caretaker_caretakerId",
                table: "PanelMembers",
                column: "caretakerId",
                principalTable: "Caretaker",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelMembers_Caretaker_caretakerId",
                table: "PanelMembers");

            migrationBuilder.DropTable(
                name: "Caretaker");

            migrationBuilder.DropIndex(
                name: "IX_PanelMembers_caretakerId",
                table: "PanelMembers");

            migrationBuilder.DropColumn(
                name: "caretakerId",
                table: "PanelMembers");
        }
    }
}
