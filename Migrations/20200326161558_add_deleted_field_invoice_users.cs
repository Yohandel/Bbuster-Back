using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestTest.Migrations
{
    public partial class add_deleted_field_invoice_users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "BusterUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "BusterInvoice",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted",
                table: "BusterUsers");

            migrationBuilder.DropColumn(
                name: "deleted",
                table: "BusterInvoice");
        }
    }
}
