using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendlyGames.DataAccess.Migrations
{
    public partial class CreatingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "RegistrationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationCategories", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    EventCategoryId = table.Column<int>(type: "int", nullable: false),
                    LevelCategoryId = table.Column<int>(type: "int", nullable: false),
                    SurfaceCategoryId = table.Column<int>(type: "int", nullable: false),
                    SurroundingCategoryId = table.Column<int>(type: "int", nullable: false),
                    MaxNumberOfPlayers = table.Column<int>(type: "int", nullable: false),
                    PriceForEvent = table.Column<double>(type: "float", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageForEvent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventCategories_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_LevelCategories_LevelCategoryId",
                        column: x => x.LevelCategoryId,
                        principalTable: "LevelCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_SurfaceCategories_SurfaceCategoryId",
                        column: x => x.SurfaceCategoryId,
                        principalTable: "SurfaceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_SurroundingCategories_SurroundingCategoryId",
                        column: x => x.SurroundingCategoryId,
                        principalTable: "SurroundingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Registrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registrations_RegistrationCategories_RegistrationCategoryId",
                        column: x => x.RegistrationCategoryId,
                        principalTable: "RegistrationCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EventCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Szukam osób do gry w kosza", "Koszykówka" },
                    { 2, "Orlikowe granie", "Piłka Nożna" },
                    { 3, "Ciężki trening", "Siłownia" },
                    { 4, "Sprinty na 200m", "Bieganie" },
                    { 5, "Nauka jazdy na jednym kole", "Rower" },
                    { 6, "Mecz o wszystko", "Siatkówka" },
                    { 7, "1 vs 1", "Tenis" },
                    { 8, "Brak stołu.., ktoś coś?", "Ping Pong" },
                    { 9, "Sobotni chill", "Kręgielnia" }
                });

            migrationBuilder.InsertData(
                table: "LevelCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Łatwy" },
                    { 2, "Średni" },
                    { 3, "Zaawanzowany" }
                });

            migrationBuilder.InsertData(
                table: "RegistrationCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Oczekujące" },
                    { 2, "Zaakceptowane" },
                    { 3, "Odrzucone" }
                });

            migrationBuilder.InsertData(
                table: "SurfaceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Trawa" },
                    { 2, "Kort" },
                    { 3, "Piasek" },
                    { 4, "Hala" },
                    { 5, "Basen" },
                    { 6, "Syntetyczna" },
                    { 7, "Inne" }
                });

            migrationBuilder.InsertData(
                table: "SurroundingCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Węwnątrz" },
                    { 2, "Na zewnątrz" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Adam", "Smith" },
                    { 3, "Franek", "Stopka" },
                    { 4, "Asia", "Szul" },
                    { 5, "Tomek", "Broda" },
                    { 6, "Grzegorz", "Wisła" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "City", "CreatorId", "EndDateTime", "EventCategoryId", "ImageForEvent", "LevelCategoryId", "MaxNumberOfPlayers", "Name", "PriceForEvent", "StartDateTime", "Street", "SurfaceCategoryId", "SurroundingCategoryId" },
                values: new object[,]
                {
                    { 1, "Tarnów", 1, new DateTime(2022, 8, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, "basketball-box.png", 2, 8, "Koszykówka", 30.0, new DateTime(2022, 8, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Piłsudskiego 24", 6, 2 },
                    { 2, "Kraków", 2, new DateTime(2022, 8, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, "footbal-box.png", 1, 10, "Piłka Nożna", 0.0, new DateTime(2022, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Grzegórzecka 24", 1, 2 },
                    { 3, "Żywiec", 3, new DateTime(2022, 8, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, "footbal-box.png", 2, 10, "Siłownia", 0.0, new DateTime(2022, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Kazimierza Tetmajera 75", 3, 2 },
                    { 4, "Wrocław", 4, new DateTime(2022, 8, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, "footbal-box.png", 3, 3, "Bieganie", 0.0, new DateTime(2022, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Różanka", 7, 2 },
                    { 5, "Szczecin", 5, new DateTime(2022, 8, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 5, "footbal-box.png", 2, 15, "Rower", 10.0, new DateTime(2022, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Modra 104", 7, 2 },
                    { 6, "Warszawa", 6, new DateTime(2022, 8, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 9, "footbal-box.png", 1, 4, "Kręgle", 16.0, new DateTime(2022, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Vincenta van Gogha 1", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "EventId", "UserId", "RegistrationCategoryId", "RegistrationDateTime" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3045) },
                    { 1, 2, 1, new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3083) },
                    { 2, 1, 3, new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3131) },
                    { 2, 2, 2, new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3092) },
                    { 3, 3, 2, new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3141) },
                    { 4, 4, 2, new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3150) },
                    { 5, 5, 2, new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3158) },
                    { 6, 6, 2, new DateTime(2022, 8, 31, 12, 6, 4, 461, DateTimeKind.Local).AddTicks(3166) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatorId",
                table: "Events",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventCategoryId",
                table: "Events",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LevelCategoryId",
                table: "Events",
                column: "LevelCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SurfaceCategoryId",
                table: "Events",
                column: "SurfaceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SurroundingCategoryId",
                table: "Events",
                column: "SurroundingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_RegistrationCategoryId",
                table: "Registrations",
                column: "RegistrationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_UserId",
                table: "Registrations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "RegistrationCategories");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropTable(
                name: "LevelCategories");

            migrationBuilder.DropTable(
                name: "SurfaceCategories");

            migrationBuilder.DropTable(
                name: "SurroundingCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
