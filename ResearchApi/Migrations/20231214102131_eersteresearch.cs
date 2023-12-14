using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchApi.Migrations
{
    /// <inheritdoc />
    public partial class eersteresearch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Research",
                columns: table => new
                {
                    Ocode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    compensation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type_Research = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link_Research = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Research", x => x.Ocode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Research");
        }
    }
}
