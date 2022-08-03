using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendlyGames.DataAccess.Migrations
{
    public partial class SurfaceCategorySurroundingCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SurfaceCategoryId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurroundingCategoryId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SurfaceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfaceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurroundingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurroundingCategories", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "SurfaceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Grass" },
                    { 2, "Court" },
                    { 3, "Sand" },
                    { 4, "Hall" },
                    { 5, "Pool" },
                    { 6, "Others" }
                });

            migrationBuilder.InsertData(
                table: "SurroundingCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Indoor" },
                    { 2, "Outdoor" }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SurfaceCategoryId", "SurroundingCategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SurfaceCategoryId", "SurroundingCategoryId" },
                values: new object[] { 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Events_SurfaceCategoryId",
                table: "Events",
                column: "SurfaceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SurroundingCategoryId",
                table: "Events",
                column: "SurroundingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_SurfaceCategories_SurfaceCategoryId",
                table: "Events",
                column: "SurfaceCategoryId",
                principalTable: "SurfaceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_SurroundingCategories_SurroundingCategoryId",
                table: "Events",
                column: "SurroundingCategoryId",
                principalTable: "SurroundingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_SurfaceCategories_SurfaceCategoryId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_SurroundingCategories_SurroundingCategoryId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "SurfaceCategories");

            migrationBuilder.DropTable(
                name: "SurroundingCategories");

            migrationBuilder.DropIndex(
                name: "IX_Events_SurfaceCategoryId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_SurroundingCategoryId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SurfaceCategoryId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SurroundingCategoryId",
                table: "Events");

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
        }
    }
}
