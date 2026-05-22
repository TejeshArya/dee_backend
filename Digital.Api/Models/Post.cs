using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public int GroupId { get; set; }

        [Required]
        [MaxLength(100)]
        public string GroupName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Wing { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Dept { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Desc { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
