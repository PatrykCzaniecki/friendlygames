using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendlyGames.DataAccess.Migrations
{
    public partial class AddLocationToEventAndSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 19, 18, 644, DateTimeKind.Local).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 19, 18, 644, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 19, 18, 644, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 19, 18, 644, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 19, 18, 644, DateTimeKind.Local).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 4, 4 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 19, 18, 644, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 5, 5 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 19, 18, 644, DateTimeKind.Local).AddTicks(573));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 6, 6 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 19, 18, 644, DateTimeKind.Local).AddTicks(583));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 9, 14, 979, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 9, 14, 979, DateTimeKind.Local).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 9, 14, 979, DateTimeKind.Local).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 9, 14, 979, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 9, 14, 979, DateTimeKind.Local).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 4, 4 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 9, 14, 979, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 5, 5 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 9, 14, 979, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 6, 6 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 11, 9, 14, 979, DateTimeKind.Local).AddTicks(4957));
        }
    }
}
