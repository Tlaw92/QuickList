using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickList.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30091614-31e9-4803-8538-ca7778d45285");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3bc50e2e-2884-4f9e-83f0-8d7c5626725d", "4d6aa588-fdd4-40ec-b7f0-9789bca31c77", "Shopper", "SHOPPER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bc50e2e-2884-4f9e-83f0-8d7c5626725d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30091614-31e9-4803-8538-ca7778d45285", "a9e282f3-944a-4e34-a626-fef5668baaa7", "Shopper", "SHOPPER" });
        }
    }
}
