using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string BankName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
