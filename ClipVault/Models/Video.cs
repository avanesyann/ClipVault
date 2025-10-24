using System.ComponentModel.DataAnnotations;

namespace ClipVault.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? VideoUrl { get; set; }
        [Required]
        public string? ThumbnailUrl { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
