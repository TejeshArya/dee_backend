using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmployeeEmail { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;
        
        public string SubCategory { get; set; } = string.Empty;
        public string SubSubCategory { get; set; } = string.Empty;

        [Required]
        public string DocumentName { get; set; } = string.Empty;

        [Required]
        public string FilePath { get; set; } = string.Empty;

        public string FileType { get; set; } = string.Empty;
        public long FileSize { get; set; }
        
        public string Remarks { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
