using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.EF.Migrations
{
    /// <inheritdoc />
    public partial class ReservationService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ClientId",
                table: "Reservations",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ClientId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Reservations");
        }
    }
}
