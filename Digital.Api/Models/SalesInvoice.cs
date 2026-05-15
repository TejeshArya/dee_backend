using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class SalesInvoice
    {
        [Key]
        public int Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string InvoiceNo { get; set; } = string.Empty;
        public DateTime? InvoiceDate { get; set; }
        
        public decimal Amount { get; set; }
        public decimal GstAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PayAmount { get; set; }
        
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<SalesInvoiceItem> Items { get; set; } = new();
    }

    public class SalesInvoiceItem
    {
        [Key]
        public int Id { get; set; }
        public int SalesInvoiceId { get; set; }
        
        public string Description { get; set; } = string.Empty;
        public string Hsn { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal GstPercentage { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
    }
}
