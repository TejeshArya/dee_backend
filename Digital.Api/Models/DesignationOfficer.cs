using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class DesignationOfficer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string DesignationName { get; set; } = string.Empty;

        public int? DepartmentId { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public Department? Department { get; set; }

        [Required]
        [MaxLength(255)]
        public string OfficerName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string OfficerId { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string MobileNumber { get; set; } = string.Empty;

        public bool Status { get; set; } = true;

        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime? EndTime { get; set; } = null;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
