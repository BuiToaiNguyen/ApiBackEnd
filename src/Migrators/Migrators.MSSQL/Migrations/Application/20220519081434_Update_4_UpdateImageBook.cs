using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_4_UpdateImageBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "Catalog",
                table: "CategoryBooks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "Catalog",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "Catalog",
                table: "AuthorBooks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Catalog",
                table: "CategoryBooks");

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Catalog",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Catalog",
                table: "AuthorBooks");
        }
    }
}
