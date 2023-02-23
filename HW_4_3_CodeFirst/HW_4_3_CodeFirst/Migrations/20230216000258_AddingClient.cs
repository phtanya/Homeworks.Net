using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HW_4_3_CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddingClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedDate",
                table: "Project",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FoundedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "CompanyName", "Email", "FoundedDate", "Location" },
                values: new object[,]
                {
                    { 1, "Company-A", "copmpany-a@gmail.com", new DateTime(2021, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyiv" },
                    { 2, "Company-B", "company-b@gmail.com", new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kharkiv" },
                    { 3, "Company-C", "company-c@gmail.com", new DateTime(2013, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lviv" },
                    { 4, "Company-D", "company-d@gmail.com", new DateTime(2017, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madrid" },
                    { 5, "Company-E", "company-e@gmail.com", new DateTime(2020, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "London" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Budget", "ClientId", "Name", "StartedDate" },
                values: new object[,]
                {
                    { 1, 10000m, 1, "Project1", new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 20000m, 2, "Project2", new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 30000m, 3, "Project3", new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 40000m, 4, "Project4", new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 50000m, 5, "Project5", new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedDate",
                table: "Project",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
