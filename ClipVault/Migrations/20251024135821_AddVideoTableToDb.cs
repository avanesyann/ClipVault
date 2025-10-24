using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClipVault.Migrations
{
    /// <inheritdoc />
    public partial class AddVideoTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 10, 24, 18, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 10, 24, 17, 52, 16, 778, DateTimeKind.Local).AddTicks(5978));
        }
    }
}
