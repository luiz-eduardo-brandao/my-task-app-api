using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTaskApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InsertUserAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Bio", "BirthDate", "CreatedAt", "Email", "FullName", "Password", "PhoneNumber", "ProfileImage", "Role" },
                values: new object[] { 1, true, "", new DateTime(2022, 10, 25, 13, 20, 35, 391, DateTimeKind.Utc).AddTicks(4239), new DateTime(2024, 10, 25, 13, 20, 35, 391, DateTimeKind.Utc).AddTicks(4234), "admin@gmail.com", "MyTaskApp", "admin123", "", "", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
