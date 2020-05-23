using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JogaFacil.Api.Migrations
{
    public partial class ChangedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arena_Place_PlaceId",
                table: "Arena");

            migrationBuilder.DropForeignKey(
                name: "FK_Place_Address_AddressId",
                table: "Place");

            migrationBuilder.DropForeignKey(
                name: "FK_Place_User_OwnerId",
                table: "Place");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Arena_ArenaId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Place_PlaceId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_User_UserId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Place_PlaceId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Place",
                table: "Place");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "Place",
                newName: "Places");

            migrationBuilder.RenameIndex(
                name: "IX_User_PlaceId",
                table: "Users",
                newName: "IX_Users_PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_UserId",
                table: "Reservations",
                newName: "IX_Reservations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_PlaceId",
                table: "Reservations",
                newName: "IX_Reservations_PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_ArenaId",
                table: "Reservations",
                newName: "IX_Reservations_ArenaId");

            migrationBuilder.RenameIndex(
                name: "IX_Place_OwnerId",
                table: "Places",
                newName: "IX_Places_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Place_AddressId",
                table: "Places",
                newName: "IX_Places_AddressId");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Arena",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpenHoursId",
                table: "Places",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Places",
                table: "Places",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OpenHoursDay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpeningHour = table.Column<DateTime>(nullable: false),
                    ClosingHour = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenHoursDay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenHours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MondayId = table.Column<int>(nullable: true),
                    TuesdayId = table.Column<int>(nullable: true),
                    WednesdayId = table.Column<int>(nullable: true),
                    ThursdayId = table.Column<int>(nullable: true),
                    FridayId = table.Column<int>(nullable: true),
                    SaturdayId = table.Column<int>(nullable: true),
                    SundayId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDay_FridayId",
                        column: x => x.FridayId,
                        principalTable: "OpenHoursDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDay_MondayId",
                        column: x => x.MondayId,
                        principalTable: "OpenHoursDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDay_SaturdayId",
                        column: x => x.SaturdayId,
                        principalTable: "OpenHoursDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDay_SundayId",
                        column: x => x.SundayId,
                        principalTable: "OpenHoursDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDay_ThursdayId",
                        column: x => x.ThursdayId,
                        principalTable: "OpenHoursDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDay_TuesdayId",
                        column: x => x.TuesdayId,
                        principalTable: "OpenHoursDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenHours_OpenHoursDay_WednesdayId",
                        column: x => x.WednesdayId,
                        principalTable: "OpenHoursDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "FK_Arena_Places_PlaceId",
                table: "Arena",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Address_AddressId",
                table: "Places",
                column: "AddressId",
                principalTable: "Address",
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
                name: "FK_Places_Users_OwnerId",
                table: "Places",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Arena_ArenaId",
                table: "Reservations",
                column: "ArenaId",
                principalTable: "Arena",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Places_PlaceId",
                table: "Users",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arena_Places_PlaceId",
                table: "Arena");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Address_AddressId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_OpenHours_OpenHoursId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_OwnerId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Arena_ArenaId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Places_PlaceId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Places_PlaceId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "OpenHours");

            migrationBuilder.DropTable(
                name: "OpenHoursDay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Places",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_OpenHoursId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Arena");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "OpenHoursId",
                table: "Places");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameTable(
                name: "Places",
                newName: "Place");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PlaceId",
                table: "User",
                newName: "IX_User_PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_UserId",
                table: "Reservation",
                newName: "IX_Reservation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_PlaceId",
                table: "Reservation",
                newName: "IX_Reservation_PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ArenaId",
                table: "Reservation",
                newName: "IX_Reservation_ArenaId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_OwnerId",
                table: "Place",
                newName: "IX_Place_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_AddressId",
                table: "Place",
                newName: "IX_Place_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Place",
                table: "Place",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arena_Place_PlaceId",
                table: "Arena",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Place_Address_AddressId",
                table: "Place",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Place_User_OwnerId",
                table: "Place",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Arena_ArenaId",
                table: "Reservation",
                column: "ArenaId",
                principalTable: "Arena",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Place_PlaceId",
                table: "Reservation",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_User_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Place_PlaceId",
                table: "User",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
