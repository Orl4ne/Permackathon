using Microsoft.EntityFrameworkCore.Migrations;

namespace Permackathon.Financial.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Effectives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Eat = table.Column<double>(nullable: false),
                    Grow = table.Column<double>(nullable: false),
                    Learn = table.Column<double>(nullable: false),
                    CashFlow = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effectives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Predictions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Eat = table.Column<double>(nullable: false),
                    Grow = table.Column<double>(nullable: false),
                    Learn = table.Column<double>(nullable: false),
                    CashFlow = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predictions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Effectives");

            migrationBuilder.DropTable(
                name: "Predictions");
        }
    }
}
