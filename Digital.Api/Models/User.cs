using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Role { get; set; } = "User"; // Admin, Manager, User

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
