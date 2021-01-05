using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickList.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1944d5c2-7591-443d-90d2-b07468055719");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef051d0e-ec6a-4701-ab02-a005ed014355", "50df9bf2-5c91-48ae-9e3f-d9dc6fcbb54c", "Shopper", "SHOPPER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef051d0e-ec6a-4701-ab02-a005ed014355");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1944d5c2-7591-443d-90d2-b07468055719", "59b347f3-4da2-43b1-a96d-3d56b1dd31c7", "Shopper", "SHOPPER" });
        }
    }
}
