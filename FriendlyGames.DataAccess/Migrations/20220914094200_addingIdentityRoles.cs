using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendlyGames.DataAccess.Migrations
{
    public partial class addingIdentityRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01277cac-ff43-44e2-a4bb-0691e4e70f2a", "88f77a96-7d94-4161-bd86-b7e3abea7fae", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44507b65-7943-422d-b43f-5296cf9d396d", "412e585f-27a5-478e-80db-a86543caf8a5", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01277cac-ff43-44e2-a4bb-0691e4e70f2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44507b65-7943-422d-b43f-5296cf9d396d");
        }
    }
}
