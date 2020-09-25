using Microsoft.EntityFrameworkCore.Migrations;

namespace Chore_App.Migrations
{
    public partial class ListOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "listOwner",
                table: "Chorelist",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "listOwner",
                table: "Chorelist");
        }
    }
}
