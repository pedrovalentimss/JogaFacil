using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JogaFacil.Api.Migrations
{
    public partial class YeahBro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Addresses_AddressId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_OpenHours_OpenHoursId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Arenas_ArenaId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Places_PlaceId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "OpenHours");

            migrationBuilder.DropTable(
                name: "OpenHoursDays");

            migrationBuilder.DropIndex(
                name: "IX_Places_AddressId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_OpenHoursId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHoursId",
                table: "Places");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ArenaId",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Neighbourhood",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Number",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Friday_ClosingHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Friday_OpeningHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Monday_ClosingHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Monday_OpeningHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Saturday_ClosingHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Saturday_OpeningHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Sunday_ClosingHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Sunday_OpeningHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Thursday_ClosingHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Thursday_OpeningHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Tuesday_ClosingHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Tuesday_OpeningHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Wednesday_ClosingHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenHours_Wednesday_OpeningHour",
                table: "Places",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Arenas_ArenaId",
                table: "Reservations",
                column: "ArenaId",
                principalTable: "Arenas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Places_PlaceId",
                table: "Reservations",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Arenas_ArenaId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Places_PlaceId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Address_Neighbourhood",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Address_Number",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Friday_ClosingHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Friday_OpeningHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Monday_ClosingHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Monday_OpeningHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Saturday_ClosingHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Saturday_OpeningHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Sunday_ClosingHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Sunday_OpeningHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Thursday_ClosingHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Thursday_OpeningHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Tuesday_ClosingHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Tuesday_OpeningHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Wednesday_ClosingHour",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenHours_Wednesday_OpeningHour",
                table: "Places");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArenaId",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Places",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OpenHoursId",
                table: "Places",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighbourhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenHoursDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClosingHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpeningHour = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenHoursDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridayId = table.Column<int>(type: "int", nullable: true),
                    MondayId = table.Column<int>(type: "int", nullable: true),
                    SaturdayId = table.Column<int>(type: "int", nullable: true),
                    SundayId = table.Column<int>(type: "int", nullable: true),
                    ThursdayId = table.Column<int>(type: "int", nullable: true),
                    TuesdayId = table.Column<int>(type: "int", nullable: true),
                    WednesdayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDays_FridayId",
                        column: x => x.FridayId,
                        principalTable: "OpenHoursDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDays_MondayId",
                        column: x => x.MondayId,
                        principalTable: "OpenHoursDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDays_SaturdayId",
                        column: x => x.SaturdayId,
                        principalTable: "OpenHoursDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDays_SundayId",
                        column: x => x.SundayId,
                        principalTable: "OpenHoursDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDays_ThursdayId",
                        column: x => x.ThursdayId,
                        principalTable: "OpenHoursDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDays_TuesdayId",
                        column: x => x.TuesdayId,
                        principalTable: "OpenHoursDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDays_WednesdayId",
                        column: x => x.WednesdayId,
                        principalTable: "OpenHoursDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_AddressId",
                table: "Places",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_OpenHoursId",
                table: "Places",
                column: "OpenHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenHours_FridayId",
                table: "OpenHours",
                column: "FridayId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenHours_MondayId",
                table: "OpenHours",
                column: "MondayId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenHours_SaturdayId",
                table: "OpenHours",
                column: "SaturdayId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenHours_SundayId",
                table: "OpenHours",
                column: "SundayId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenHours_ThursdayId",
                table: "OpenHours",
                column: "ThursdayId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenHours_TuesdayId",
                table: "OpenHours",
                column: "TuesdayId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenHours_WednesdayId",
                table: "OpenHours",
                column: "WednesdayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Addresses_AddressId",
                table: "Places",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_OpenHours_OpenHoursId",
                table: "Places",
                column: "OpenHoursId",
                principalTable: "OpenHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Arenas_ArenaId",
                table: "Reservations",
                column: "ArenaId",
                principalTable: "Arenas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Places_PlaceId",
                table: "Reservations",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
