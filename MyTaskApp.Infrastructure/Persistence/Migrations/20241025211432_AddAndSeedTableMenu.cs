using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyTaskApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAndSeedTableMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFatherMenu = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_IdFatherMenu",
                        column: x => x.IdFatherMenu,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Icon", "IdFatherMenu", "Route", "Title" },
                values: new object[,]
                {
                    { 1, "mdi-home", null, "/", "Home" },
                    { 2, "mdi-email", null, "/projects", "Projetos" },
                    { 3, "mdi-check-outline", null, "/tasks", "Tarefas" },
                    { 4, "mdi-monitor-dashboard", null, null, "Overview (em breve)" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt" },
                values: new object[] { new DateTime(2022, 10, 25, 21, 14, 31, 539, DateTimeKind.Utc).AddTicks(1719), new DateTime(2024, 10, 25, 21, 14, 31, 539, DateTimeKind.Utc).AddTicks(1715) });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Icon", "IdFatherMenu", "Route", "Title" },
                values: new object[,]
                {
                    { 5, "mdi-view-dashboard-edit-outline", 4, null, "Dashboard" },
                    { 6, "mdi-chart-line", 4, null, "Relatório" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_IdFatherMenu",
                table: "Menus",
                column: "IdFatherMenu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt" },
                values: new object[] { new DateTime(2022, 10, 25, 15, 52, 0, 787, DateTimeKind.Utc).AddTicks(257), new DateTime(2024, 10, 25, 15, 52, 0, 787, DateTimeKind.Utc).AddTicks(253) });
        }
    }
}
