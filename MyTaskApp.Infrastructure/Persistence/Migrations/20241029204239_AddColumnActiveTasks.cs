using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTaskApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnActiveTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt" },
                values: new object[] { new DateTime(2022, 10, 29, 20, 42, 38, 568, DateTimeKind.Utc).AddTicks(2290), new DateTime(2024, 10, 29, 20, 42, 38, 568, DateTimeKind.Utc).AddTicks(2286) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt" },
                values: new object[] { new DateTime(2022, 10, 25, 21, 14, 31, 539, DateTimeKind.Utc).AddTicks(1719), new DateTime(2024, 10, 25, 21, 14, 31, 539, DateTimeKind.Utc).AddTicks(1715) });
        }
    }
}
