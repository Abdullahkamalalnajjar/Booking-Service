using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Deposit",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServicePackages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "ServicePackages",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceFeatures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountCoupon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Services_ServiceEntityId",
                        column: x => x.ServiceEntityId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicePackages_ReservationId",
                table: "ServicePackages",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ServiceEntityId",
                table: "Reservations",
                column: "ServiceEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePackages_Reservations_ReservationId",
                table: "ServicePackages",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicePackages_Reservations_ReservationId",
                table: "ServicePackages");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_ServicePackages_ReservationId",
                table: "ServicePackages");

            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "ServicePackages");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServicePackages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
