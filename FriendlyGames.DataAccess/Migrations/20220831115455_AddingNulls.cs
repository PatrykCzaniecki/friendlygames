using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendlyGames.DataAccess.Migrations
{
    public partial class AddingNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 13, 54, 55, 387, DateTimeKind.Local).AddTicks(54));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 13, 54, 55, 387, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 13, 54, 55, 387, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 13, 54, 55, 387, DateTimeKind.Local).AddTicks(103));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 13, 54, 55, 387, DateTimeKind.Local).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 4, 4 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 13, 54, 55, 387, DateTimeKind.Local).AddTicks(128));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 5, 5 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 13, 54, 55, 387, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 6, 6 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 13, 54, 55, 387, DateTimeKind.Local).AddTicks(144));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3045));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 4, 4 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 5, 5 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 6, 6 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3166));
        }
    }
}
