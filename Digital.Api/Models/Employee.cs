using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string? EmployeeId { get; set; } // e.g., DEE300426132
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        
        public int? LocationId { get; set; }
        public Location? Location { get; set; }
        
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = "Active"; // Active, Pending, Rejected
        
        public string? TemporaryPassword { get; set; }
        public string? AnnualSalary { get; set; }
        public string? Qualification { get; set; }
        public string? Remarks { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
