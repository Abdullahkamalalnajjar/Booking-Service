using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.EF.Migrations
{
    /// <inheritdoc />
    public partial class dsgdgs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicePackages_Reservations_ReservationId",
                table: "ServicePackages");

            migrationBuilder.DropIndex(
                name: "IX_ServicePackages_ReservationId",
                table: "ServicePackages");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "ServicePackages");

            migrationBuilder.CreateTable(
                name: "ReservationPackage",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    ServicePackageId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationPackage", x => new { x.ReservationId, x.ServicePackageId });
                    table.ForeignKey(
                        name: "FK_ReservationPackage_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationPackage_ServicePackages_ServicePackageId",
                        column: x => x.ServicePackageId,
                        principalTable: "ServicePackages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPackage_ServicePackageId",
                table: "ReservationPackage",
                column: "ServicePackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationPackage");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "ServicePackages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicePackages_ReservationId",
                table: "ServicePackages",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePackages_Reservations_ReservationId",
                table: "ServicePackages",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}
