using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClipVault.Migrations
{
    /// <inheritdoc />
    public partial class AddSecondSeedDataToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "DateAdded", "Description", "ThumbnailUrl", "Title", "VideoUrl" },
                values: new object[] { 2, new DateTime(2025, 10, 24, 19, 0, 0, 0, DateTimeKind.Unspecified), "The second trailer for the next franchise of Grand Theft Auto.", "https://www.rockstargames.com/VI/_next/image?url=%2FVI%2F_next%2Fstatic%2Fmedia%2FGTAVI_Trailer2_poster.8aced7fd.jpg&w=3840&q=75", "GTA 6 Trailer 2", "https://www.youtube.com/watch?v=VQRLujxTm3c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
