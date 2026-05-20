using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class SubGst
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string CompanyName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
        public string OfficerName { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string DepartmentOfficer { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string GstNumber { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
