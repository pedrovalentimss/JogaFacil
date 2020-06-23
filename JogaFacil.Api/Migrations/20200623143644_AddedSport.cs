using Microsoft.EntityFrameworkCore.Migrations;

namespace JogaFacil.Api.Migrations
{
    public partial class AddedSport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sport",
                table: "Arenas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sport",
                table: "Arenas");
        }
    }
}
