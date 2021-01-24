using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickList.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "198ea203-0c5f-42e6-9cdd-0fb78ae6b8a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "489ae8af-d41c-4dfb-bc77-a8622360ddd5", "1d635417-96db-4217-9447-d8d1398a1c4f", "Shopper", "SHOPPER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "489ae8af-d41c-4dfb-bc77-a8622360ddd5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "198ea203-0c5f-42e6-9cdd-0fb78ae6b8a2", "6893a8a2-99df-488b-aa5e-5d828660fbd4", "Shopper", "SHOPPER" });
        }
    }
}
