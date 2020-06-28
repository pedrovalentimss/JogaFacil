using Microsoft.EntityFrameworkCore.Migrations;

namespace JogaFacil.Api.Migrations
{
    public partial class AddedCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_Latitude",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Longitude",
                table: "Places",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Latitude",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Address_Longitude",
                table: "Places");
        }
    }
}
