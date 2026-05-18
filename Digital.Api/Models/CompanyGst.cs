using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class CompanyGst
    {
        [Key]
        [MaxLength(50)]
        public string GstNumber { get; set; } = string.Empty;

        public string GstStateCode { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(255)]
        public string CompanyName { get; set; } = string.Empty;
        
        public string PanNumber { get; set; } = string.Empty;
        public string TanNumber { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string StateName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;
        public string CompanyAddress { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public DateTime? CompanyEstablished { get; set; }
        public string City { get; set; } = string.Empty;
        public string GstType { get; set; } = "GST";
        public string DealsIn { get; set; } = string.Empty;

        public string SecondaryMobileNo { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string LogoPath { get; set; } = string.Empty;
        public string HeaderPath { get; set; } = string.Empty;
        public string FooterPath { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
