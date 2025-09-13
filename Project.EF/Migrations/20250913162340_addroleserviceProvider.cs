using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.EF.Migrations
{
    /// <inheritdoc />
    public partial class addroleserviceProvider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefualt", "IsDeleted", "Name", "NormalizedName" },
                values: new object[] { "d3b5c8e1-4f3a-4c9e-8f7a-2e6f5e30ab12", "a1c2d3e4-f5b6-7890-abcd-ef0123456789", false, false, "ServiceProvider", "SERVICEPROVIDER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3b5c8e1-4f3a-4c9e-8f7a-2e6f5e30ab12");
        }
    }
}
