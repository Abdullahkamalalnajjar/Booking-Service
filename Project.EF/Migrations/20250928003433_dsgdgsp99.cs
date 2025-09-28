using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.EF.Migrations
{
    /// <inheritdoc />
    public partial class dsgdgsp99 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReservationPackage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReservationPackage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
