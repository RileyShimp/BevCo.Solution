using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BevCo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beverages",
                columns: table => new
                {
                    BeverageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BeverageName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CalorieCount = table.Column<int>(type: "int", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    BottleCount = table.Column<int>(type: "int", nullable: false),
                    IndividualBottleSize = table.Column<int>(type: "int", nullable: false),
                    StockCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverages", x => x.BeverageId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IsAlcoholic = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryBeverage",
                columns: table => new
                {
                    CategoryBeverageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BeverageId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBeverage", x => x.CategoryBeverageId);
                    table.ForeignKey(
                        name: "FK_CategoryBeverage_Beverages_BeverageId",
                        column: x => x.BeverageId,
                        principalTable: "Beverages",
                        principalColumn: "BeverageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryBeverage_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBeverage_BeverageId",
                table: "CategoryBeverage",
                column: "BeverageId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBeverage_CategoryId",
                table: "CategoryBeverage",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryBeverage");

            migrationBuilder.DropTable(
                name: "Beverages");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
