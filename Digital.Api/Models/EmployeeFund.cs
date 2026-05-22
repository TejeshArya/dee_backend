using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital.Api.Models
{
    public class EmployeeFund
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime GivenDate { get; set; }

        [Required]
        [MaxLength(500)]
        public string Purpose { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Pending"; // e.g., Pending, Approved, Released, Rejected

        [Required]
        [MaxLength(100)]
        public string RefNo { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string RecordedBy { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
