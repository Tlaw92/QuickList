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
                keyValue: "1acd60c6-e486-4ae2-9c16-794723e59da1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae666257-1079-4c06-8f21-f814ecfb3fa9", "036a4cd1-477a-4576-aa29-75d3d3a03744", "Shopper", "SHOPPER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae666257-1079-4c06-8f21-f814ecfb3fa9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1acd60c6-e486-4ae2-9c16-794723e59da1", "492cb89f-3606-4d7c-a966-3387b94f95a4", "Shopper", "SHOPPER" });
        }
    }
}
