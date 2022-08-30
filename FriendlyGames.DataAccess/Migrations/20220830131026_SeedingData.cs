using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendlyGames.DataAccess.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 3, "Ciężki trening", "Siłownia" },
                    { 4, "Sprinty na 200m", "Bieganie" },
                    { 5, "Nauka jazdy na jednym kole", "Rower" },
                    { 6, "Mecz o wszystko", "Siatkówka" },
                    { 7, "1 vs 1", "Tenis" },
                    { 8, "Brak stołu.., ktoś coś?", "Ping Pong" },
                    { 9, "Sobotni chill", "Kręgielnia" }
                });

            migrationBuilder.UpdateData(
                table: "LevelCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Łatwy");

            migrationBuilder.UpdateData(
                table: "LevelCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Średni");

            migrationBuilder.UpdateData(
                table: "LevelCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Zaawanzowany");

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "City", "EventId", "Street" },
                values: new object[,]
                {
                    { 3, "Żywiec", 3, "Kazimierza Tetmajera 75" },
                    { 4, "Wrocław", 4, "Różanka" },
                    { 5, "Szczecin", 5, "Modra 104" },
                    { 6, "Warszawa", 6, "Vincenta van Gogha 1" }
                });

            migrationBuilder.UpdateData(
                table: "RegistrationCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Oczekujące");

            migrationBuilder.UpdateData(
                table: "RegistrationCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Zaakceptowane");

            migrationBuilder.UpdateData(
                table: "RegistrationCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Odrzucone");

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 30, 15, 10, 26, 138, DateTimeKind.Local).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 30, 15, 10, 26, 138, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 30, 15, 10, 26, 138, DateTimeKind.Local).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 30, 15, 10, 26, 138, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Trawa");

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Kort");

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Piasek");

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Hala");

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Basen");

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Syntetyczna");

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Inne");

            migrationBuilder.UpdateData(
                table: "SurroundingCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Węwnątrz");

            migrationBuilder.UpdateData(
                table: "SurroundingCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Na zewnątrz");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 3, "Franek", "Stopka" },
                    { 4, "Asia", "Szul" },
                    { 5, "Tomek", "Broda" },
                    { 6, "Grzegorz", "Wisła" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatorId", "EndDateTime", "EventCategoryId", "ImageForEvent", "LevelCategoryId", "LocationId", "MaxNumberOfPlayers", "Name", "PriceForEvent", "StartDateTime", "SurfaceCategoryId", "SurroundingCategoryId" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2022, 8, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, "footbal-box.png", 2, 3, 10, "Siłownia", 0.0, new DateTime(2022, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 4, 4, new DateTime(2022, 8, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, "footbal-box.png", 3, 4, 3, "Bieganie", 0.0, new DateTime(2022, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 5, 5, new DateTime(2022, 8, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 5, "footbal-box.png", 2, 5, 15, "Rower", 10.0, new DateTime(2022, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 6, 6, new DateTime(2022, 8, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 9, "footbal-box.png", 1, 6, 4, "Kręgle", 16.0, new DateTime(2022, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "EventId", "UserId", "RegistrationCategoryId", "RegistrationDateTime" },
                values: new object[,]
                {
                    { 3, 3, 2, new DateTime(2022, 8, 30, 15, 10, 26, 138, DateTimeKind.Local).AddTicks(9165) },
                    { 4, 4, 2, new DateTime(2022, 8, 30, 15, 10, 26, 138, DateTimeKind.Local).AddTicks(9175) },
                    { 5, 5, 2, new DateTime(2022, 8, 30, 15, 10, 26, 138, DateTimeKind.Local).AddTicks(9185) },
                    { 6, 6, 2, new DateTime(2022, 8, 30, 15, 10, 26, 138, DateTimeKind.Local).AddTicks(9194) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "LevelCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Easy");

            migrationBuilder.UpdateData(
                table: "LevelCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Medium");

            migrationBuilder.UpdateData(
                table: "LevelCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Advanced");

            migrationBuilder.UpdateData(
                table: "RegistrationCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Waiting");

            migrationBuilder.UpdateData(
                table: "RegistrationCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Accepted");

            migrationBuilder.UpdateData(
                table: "RegistrationCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Rejected");

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 30, 11, 16, 21, 350, DateTimeKind.Local).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 30, 11, 16, 21, 350, DateTimeKind.Local).AddTicks(1587));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 30, 11, 16, 21, 350, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 30, 11, 16, 21, 350, DateTimeKind.Local).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Grass");

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Court");

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Sand");

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Hall");

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Pool");

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Synthetic");

            migrationBuilder.UpdateData(
                table: "SurfaceCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Others");

            migrationBuilder.UpdateData(
                table: "SurroundingCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Indoor");

            migrationBuilder.UpdateData(
                table: "SurroundingCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Outdoor");
        }
    }
}
