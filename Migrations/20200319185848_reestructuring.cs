using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestTest.Migrations
{
    public partial class reestructuring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "BusterUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identification",
                table: "BusterUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "BusterUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BusterUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "BusterMovies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BusterInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(nullable: false),
                    id_movie = table.Column<int>(nullable: false),
                    Created_At = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusterInvoice", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusterInvoice");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "BusterUsers");

            migrationBuilder.DropColumn(
                name: "Identification",
                table: "BusterUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "BusterUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BusterUsers");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "BusterMovies");
        }
    }
}
