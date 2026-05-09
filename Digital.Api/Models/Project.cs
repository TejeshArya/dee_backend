using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class Project
    {
        [Key]
        public string ProjectId { get; set; } = string.Empty; // e.g., PRJ-2024-01
        
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        
        public string Wing { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Post { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public string Client { get; set; } = string.Empty;
        public string Gst { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        
        public string Status { get; set; } = "Planning"; // Planning, In Progress, Completed
        public string Priority { get; set; } = "Medium"; // Low, Medium, High, Critical
        
        public string Description { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
