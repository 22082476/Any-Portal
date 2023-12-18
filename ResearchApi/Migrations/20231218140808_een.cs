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
            migrationBuilder.CreateTable(
                name: "Research",
                columns: table => new
                {
                    Rcode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Compensation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type_Research = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link_Research = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disabillity_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Participant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allowed_AgeRange = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Research", x => x.Rcode);
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
