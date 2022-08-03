using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendlyGames.DataAccess.Migrations
{
    public partial class ChangedDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Szukam osób do gry w kosza", "Koszykówka" });

            migrationBuilder.UpdateData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Orlikowe granie", "Piłka Nożna" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "SurfaceCategoryId", "SurroundingCategoryId" },
                values: new object[] { "Koszykówka", 6, 2 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Piła Nożna");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nickname",
                value: "DzikiNapastnik");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nickname",
                value: "SzatańskiBramkarz");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nickname",
                value: "SzybkaOsa");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nickname",
                value: "GroźnyNiedźwiedz");

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 14, 22, 34, 448, DateTimeKind.Local).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 14, 22, 34, 448, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 14, 22, 34, 448, DateTimeKind.Local).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 14, 22, 34, 448, DateTimeKind.Local).AddTicks(9792));

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Synthetic");

            migrationBuilder.InsertData(
                table: "SurfaceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Others" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Wilki");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Owce");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Biegi krótkie, długie i takie sobie...", "Bieg" });

            migrationBuilder.UpdateData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nic się nie stało, rodacy nic się nie stało", "Mecz piłki nożnej" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "SurfaceCategoryId", "SurroundingCategoryId" },
                values: new object[] { "Runmageddon", 1, 1 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "My kontra Wy");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nickname",
                value: "JD");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nickname",
                value: "AS");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nickname",
                value: "DJ");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nickname",
                value: "SA");

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 14, 12, 56, 431, DateTimeKind.Local).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 14, 12, 56, 431, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 14, 12, 56, 431, DateTimeKind.Local).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 14, 12, 56, 431, DateTimeKind.Local).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Others");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "My");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Wy");
        }
    }
}
