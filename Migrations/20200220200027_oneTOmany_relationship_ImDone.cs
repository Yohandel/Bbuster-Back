using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestTest.Migrations
{
    public partial class oneTOmany_relationship_ImDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BMovieCategories");

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "BusterMovies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BusterMovies_categoryId",
                table: "BusterMovies",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusterMovies_BusterCategories_categoryId",
                table: "BusterMovies",
                column: "categoryId",
                principalTable: "BusterCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusterMovies_BusterCategories_categoryId",
                table: "BusterMovies");

            migrationBuilder.DropIndex(
                name: "IX_BusterMovies_categoryId",
                table: "BusterMovies");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "BusterMovies");

            migrationBuilder.CreateTable(
                name: "BMovieCategories",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BMovieCategories", x => new { x.MovieId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BMovieCategories_BusterCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BusterCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BMovieCategories_BusterMovies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "BusterMovies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BMovieCategories_CategoryId",
                table: "BMovieCategories",
                column: "CategoryId");
        }
    }
}
