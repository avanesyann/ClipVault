using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClipVault.Migrations
{
    /// <inheritdoc />
    public partial class AddVideosTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "DateAdded", "Description", "ThumbnailUrl", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 24, 18, 0, 0, 0, DateTimeKind.Unspecified), "The first trailer for the next franchise of Grand Theft Auto.", "https://www.rockstargames.com/VI/_next/image?url=%2FVI%2F_next%2Fstatic%2Fmedia%2FGTAVI_Trailer1_poster.0e2a6544.jpg&w=3840&q=75", "GTA 6 Trailer 1", "https://www.youtube.com/watch?v=QdBZY2fkU-0" },
                    { 2, new DateTime(2025, 10, 24, 19, 0, 0, 0, DateTimeKind.Unspecified), "The second trailer for the next franchise of Grand Theft Auto.", "https://www.rockstargames.com/VI/_next/image?url=%2FVI%2F_next%2Fstatic%2Fmedia%2FGTAVI_Trailer2_poster.8aced7fd.jpg&w=3840&q=75", "GTA 6 Trailer 2", "https://www.youtube.com/watch?v=VQRLujxTm3c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
