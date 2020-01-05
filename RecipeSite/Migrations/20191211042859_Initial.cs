using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeSite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    CuisineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CuisineType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.CuisineID);
                });

            migrationBuilder.CreateTable(
                name: "AddRecipes",
                columns: table => new
                {
                    RecipeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    DifficultyLevel = table.Column<string>(nullable: false),
                    CookingTimeInMin = table.Column<int>(nullable: false),
                    IngredientList = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CuisineID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddRecipes", x => x.RecipeID);
                    table.ForeignKey(
                        name: "FK_AddRecipes_Cuisines_CuisineID",
                        column: x => x.CuisineID,
                        principalTable: "Cuisines",
                        principalColumn: "CuisineID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddRecipes_CuisineID",
                table: "AddRecipes",
                column: "CuisineID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddRecipes");

            migrationBuilder.DropTable(
                name: "Cuisines");
        }
    }
}
