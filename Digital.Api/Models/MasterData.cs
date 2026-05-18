using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class MasterData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Category { get; set; } = string.Empty; // e.g. "Payment Mode", "State", "City", "Expense"

        [Required]
        [MaxLength(255)]
        public string Value { get; set; } = string.Empty; // e.g. "GPAY", "Andhra Pradesh"

        public string Description { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public string ShortName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string GstStateCode { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
