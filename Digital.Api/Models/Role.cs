using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; // e.g. "admin", "HR"

        [MaxLength(100)]
        public string DisplayName { get; set; } = string.Empty; // e.g. "Administrator", "HR"

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public string Permissions { get; set; } = string.Empty; // Comma-separated or JSON string of permission keys
    }
}
