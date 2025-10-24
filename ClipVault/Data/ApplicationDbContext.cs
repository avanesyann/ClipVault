using ClipVault.Models;
using Microsoft.EntityFrameworkCore;

namespace ClipVault.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>().HasData(
                new Video() { 
                    Id = 1, 
                    Title = "GTA 6 Trailer 1", 
                    Description = "The first trailer for the next franchise of Grand Theft Auto.", 
                    DateAdded = new DateTime(2025, 10, 24, 18, 0, 0), 
                    VideoUrl = @"https://www.youtube.com/watch?v=QdBZY2fkU-0", 
                    ThumbnailUrl = @"https://www.rockstargames.com/VI/_next/image?url=%2FVI%2F_next%2Fstatic%2Fmedia%2FGTAVI_Trailer1_poster.0e2a6544.jpg&w=3840&q=75"
                    },
                new Video()
                {
                    Id = 2,
                    Title = "GTA 6 Trailer 2",
                    Description = "The second trailer for the next franchise of Grand Theft Auto.",
                    DateAdded = new DateTime(2025, 10, 24, 19, 0, 0),
                    VideoUrl = @"https://www.youtube.com/watch?v=VQRLujxTm3c",
                    ThumbnailUrl = @"https://www.rockstargames.com/VI/_next/image?url=%2FVI%2F_next%2Fstatic%2Fmedia%2FGTAVI_Trailer2_poster.8aced7fd.jpg&w=3840&q=75"
                }
                );
        }
    }
}
