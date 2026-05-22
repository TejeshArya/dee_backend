using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class RoleAssignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GroupId { get; set; }

        [Required]
        [MaxLength(100)]
        public string GroupName { get; set; } = string.Empty;

        [Required]
        public int PostId { get; set; }

        [Required]
        [MaxLength(255)]
        public string PostTitle { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Wing { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Dept { get; set; } = string.Empty;

        [Required]
        public int LocationId { get; set; }

        [Required]
        [MaxLength(100)]
        public string LocationName { get; set; } = string.Empty;

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmployeeName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? EmployeeCode { get; set; } // e.g., DEE300426132

        [MaxLength(500)]
        public string? Desc { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
