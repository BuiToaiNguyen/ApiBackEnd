using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_2_Book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_AuthorBooks_AuthorId",
                schema: "Catalog",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                schema: "Catalog",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryBooks",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameCate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBooks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                schema: "Catalog",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AuthorBooks_AuthorId",
                schema: "Catalog",
                table: "Books",
                column: "AuthorId",
                principalSchema: "Catalog",
                principalTable: "AuthorBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_CategoryBooks_CategoryId",
                schema: "Catalog",
                table: "Books",
                column: "CategoryId",
                principalSchema: "Catalog",
                principalTable: "CategoryBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_AuthorBooks_AuthorId",
                schema: "Catalog",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_CategoryBooks_CategoryId",
                schema: "Catalog",
                table: "Books");

            migrationBuilder.DropTable(
                name: "CategoryBooks",
                schema: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                schema: "Catalog",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "Catalog",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AuthorBooks_AuthorId",
                schema: "Catalog",
                table: "Books",
                column: "AuthorId",
                principalSchema: "Catalog",
                principalTable: "AuthorBooks",
                principalColumn: "Id");
        }
    }
}
