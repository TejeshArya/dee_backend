using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class DeliveryDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string CompanyName { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
