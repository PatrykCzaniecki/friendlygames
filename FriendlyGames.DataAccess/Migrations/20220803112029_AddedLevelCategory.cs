using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendlyGames.DataAccess.Migrations
{
    public partial class AddedLevelCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_RegistrationCategory_RegistrationCategoryId",
                table: "Registrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrationCategory",
                table: "RegistrationCategory");

            migrationBuilder.RenameTable(
                name: "RegistrationCategory",
                newName: "RegistrationCategories");

            migrationBuilder.AddColumn<int>(
                name: "LevelCategoryId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrationCategories",
                table: "RegistrationCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LevelCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LevelCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Easy" },
                    { 2, "Medium" },
                    { 3, "Advanced" }
                });

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 13, 20, 29, 360, DateTimeKind.Local).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 13, 20, 29, 360, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 13, 20, 29, 360, DateTimeKind.Local).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 13, 20, 29, 360, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "LevelCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "LevelCategoryId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Events_LevelCategoryId",
                table: "Events",
                column: "LevelCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_LevelCategories_LevelCategoryId",
                table: "Events",
                column: "LevelCategoryId",
                principalTable: "LevelCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_RegistrationCategories_RegistrationCategoryId",
                table: "Registrations",
                column: "RegistrationCategoryId",
                principalTable: "RegistrationCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_LevelCategories_LevelCategoryId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_RegistrationCategories_RegistrationCategoryId",
                table: "Registrations");

            migrationBuilder.DropTable(
                name: "LevelCategories");

            migrationBuilder.DropIndex(
                name: "IX_Events_LevelCategoryId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrationCategories",
                table: "RegistrationCategories");

            migrationBuilder.DropColumn(
                name: "LevelCategoryId",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "RegistrationCategories",
                newName: "RegistrationCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrationCategory",
                table: "RegistrationCategory",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 13, 9, 39, 220, DateTimeKind.Local).AddTicks(7162));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 13, 9, 39, 220, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 13, 9, 39, 220, DateTimeKind.Local).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "RegistrationDateTime",
                value: new DateTime(2022, 8, 3, 13, 9, 39, 220, DateTimeKind.Local).AddTicks(7266));

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_RegistrationCategory_RegistrationCategoryId",
                table: "Registrations",
                column: "RegistrationCategoryId",
                principalTable: "RegistrationCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
