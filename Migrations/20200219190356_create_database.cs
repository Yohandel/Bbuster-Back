using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestTest.Migrations
{
    public partial class create_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusterCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusterCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "BusterDirectors",
                columns: table => new
                {
                    DId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Nacionality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusterDirectors", x => x.DId);
                });

            migrationBuilder.CreateTable(
                name: "BusterUsers",
                columns: table => new
                {
                    UId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusterUsers", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "BusterMovies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    directorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusterMovies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_BusterMovies_BusterDirectors_directorId",
                        column: x => x.directorId,
                        principalTable: "BusterDirectors",
                        principalColumn: "DId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BMovieCategories",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_BusterMovies_directorId",
                table: "BusterMovies",
                column: "directorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BMovieCategories");

            migrationBuilder.DropTable(
                name: "BusterUsers");

            migrationBuilder.DropTable(
                name: "BusterCategories");

            migrationBuilder.DropTable(
                name: "BusterMovies");

            migrationBuilder.DropTable(
                name: "BusterDirectors");
        }
    }
}
