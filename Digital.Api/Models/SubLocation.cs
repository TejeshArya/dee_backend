using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class SubLocation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LocationId { get; set; }
        
        public Location? Location { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
