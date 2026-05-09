using System.ComponentModel.DataAnnotations;

namespace Digital.Api.Models
{
    public class PurchaseInvoice
    {
        [Key]
        public int Id { get; set; }
        public string Designation { get; set; } = string.Empty;
        public string ExpenseType { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string InvoiceNo { get; set; } = string.Empty;
        public DateTime? InvoiceDate { get; set; }
        public string PanCard { get; set; } = string.Empty;
        
        public decimal TotalIgst { get; set; }
        public decimal TotalCgst { get; set; }
        public decimal TotalSgst { get; set; }
        public decimal AmountExclGst { get; set; }
        public decimal RoundOff { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        
        public string? InvoiceFilePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<PurchaseInvoiceItem> Items { get; set; } = new();
    }

    public class PurchaseInvoiceItem
    {
        [Key]
        public int Id { get; set; }
        public int PurchaseInvoiceId { get; set; }
        
        public string Category { get; set; } = string.Empty;
        public string Subcategory { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public string Hsn { get; set; } = string.Empty;
        public string Denom { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Mrp { get; set; }
        public decimal CostRate { get; set; }
        public decimal SellPrice { get; set; }
        public string SerialNo { get; set; } = string.Empty;
        public DateTime? ExpiryDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string PurchaseType { get; set; } = string.Empty; // Stock or Ecom
        
        public decimal Igst { get; set; }
        public decimal Cgst { get; set; }
        public decimal Sgst { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
    }
}
