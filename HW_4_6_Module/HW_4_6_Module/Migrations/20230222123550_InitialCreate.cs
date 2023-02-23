using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HW_4_6_Module.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "date", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(320)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(320)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "date", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SongArtists",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongArtists", x => new { x.SongId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_SongArtists_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongArtists_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "DateOfBirth", "DateOfDeath", "Email", "InstagramUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1967, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "email1@gmail.com", "instagram.com/artist1", "Artist1", "+380849519323" },
                    { 2, new DateTime(1999, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "email2@gmail.com", "instagram.com/artist2", "Artist2", "+38090329002" },
                    { 3, new DateTime(1944, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "email3@gmail.com", "instagram.com/artist3", "Artist3", "+38084900003" },
                    { 4, new DateTime(1983, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "email4@gmail.com", "instagram.com/artist4", "Artist4", "+38084950004" },
                    { 5, new DateTime(1972, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "email5@gmail.com", "instagram.com/artist5", "Artist5", "+380819510005" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Pop" },
                    { 2, "Rock" },
                    { 3, "Jazz" },
                    { 4, "Hip-Hop" },
                    { 5, "Metal" }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "Duration", "GenreId", "ReleasedDate", "Title" },
                values: new object[,]
                {
                    { 4, 3.22m, null, new DateTime(1872, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song4" },
                    { 1, 3.22m, 1, new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song1" },
                    { 2, 2.53m, 2, new DateTime(2002, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song2" },
                    { 3, 2.02m, 3, new DateTime(1959, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song3" },
                    { 5, 4.11m, 5, new DateTime(2010, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song5" }
                });

            migrationBuilder.InsertData(
                table: "SongArtists",
                columns: new[] { "ArtistId", "SongId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 1, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_GenreId",
                table: "Song",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SongArtists_ArtistId",
                table: "SongArtists",
                column: "ArtistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongArtists");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
