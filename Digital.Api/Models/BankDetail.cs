using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class BankDetail
    {
        [Key]
        public int Id { get; set; }

        public string EmpId { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public string IfscCode { get; set; } = string.Empty;
        public string SwiftCode { get; set; } = string.Empty;
        public string MicrCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string AccountHolder { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
