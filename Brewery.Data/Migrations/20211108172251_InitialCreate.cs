using Microsoft.EntityFrameworkCore.Migrations;

namespace Brewery.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WholeSalers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WholeSalers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    AlcoholLevel = table.Column<double>(type: "REAL", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    BreweryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeerStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WholeSalerId = table.Column<int>(type: "INTEGER", nullable: true),
                    BeerId = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeerStocks_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeerStocks_WholeSalers_WholeSalerId",
                        column: x => x.WholeSalerId,
                        principalTable: "WholeSalers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_BeerStocks_BeerId",
                table: "BeerStocks",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_BeerStocks_WholeSalerId",
                table: "BeerStocks",
                column: "WholeSalerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerStocks");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "WholeSalers");

            migrationBuilder.DropTable(
                name: "Breweries");
        }
    }
}
