using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoItems.Migrations
{
    public partial class addDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems");

            migrationBuilder.RenameTable(
                name: "TodoItems",
                newName: "TodoItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItem",
                table: "TodoItem",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItem",
                table: "TodoItem");

            migrationBuilder.RenameTable(
                name: "TodoItem",
                newName: "TodoItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems",
                column: "Id");
        }
    }
}
