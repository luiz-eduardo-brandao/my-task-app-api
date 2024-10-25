using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTaskApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnImageUrlProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt" },
                values: new object[] { new DateTime(2022, 10, 25, 15, 49, 29, 64, DateTimeKind.Utc).AddTicks(1772), new DateTime(2024, 10, 25, 15, 49, 29, 64, DateTimeKind.Utc).AddTicks(1769) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedAt" },
                values: new object[] { new DateTime(2022, 10, 25, 13, 20, 35, 391, DateTimeKind.Utc).AddTicks(4239), new DateTime(2024, 10, 25, 13, 20, 35, 391, DateTimeKind.Utc).AddTicks(4234) });
        }
    }
}
