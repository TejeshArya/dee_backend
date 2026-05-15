using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class Quotation
    {
        [Key]
        public int Id { get; set; }
        public string QuotationNumber { get; set; } = string.Empty;
        public string ExpenseType { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public string Wing { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Post { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? InvoiceDate { get; set; }
        public string ValidityDays { get; set; } = string.Empty;
        public string DeliveryDays { get; set; } = string.Empty;
        public string WarrantyDays { get; set; } = string.Empty;
        public string InquiryNo { get; set; } = string.Empty;
        public DateTime? InquiryDate { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public string GstType { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
        
        public decimal TotalIgst { get; set; }
        public decimal TotalCgst { get; set; }
        public decimal TotalSgst { get; set; }
        public decimal AmountExclGst { get; set; }
        public decimal RoundOff { get; set; }
        public decimal TotalAmount { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<QuotationItem> Items { get; set; } = new();
    }

    public class QuotationItem
    {
        [Key]
        public int Id { get; set; }
        public int QuotationId { get; set; }
        
        public string Category { get; set; } = string.Empty;
        public string Subcategory { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public string Hsn { get; set; } = string.Empty;
        public string Denom { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
        public decimal Igst { get; set; }
        public decimal Cgst { get; set; }
        public decimal Sgst { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
    }
}
