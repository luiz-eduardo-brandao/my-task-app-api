using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTaskApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnActiveProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt" },
                values: new object[] { new DateTime(2022, 10, 25, 15, 52, 0, 787, DateTimeKind.Utc).AddTicks(257), new DateTime(2024, 10, 25, 15, 52, 0, 787, DateTimeKind.Utc).AddTicks(253) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt" },
                values: new object[] { new DateTime(2022, 10, 25, 15, 49, 29, 64, DateTimeKind.Utc).AddTicks(1772), new DateTime(2024, 10, 25, 15, 49, 29, 64, DateTimeKind.Utc).AddTicks(1769) });
        }
    }
}
