using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuotationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Quotations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quotation>>> GetQuotations()
        {
            return await _context.Quotations.Include(q => q.Items).OrderByDescending(q => q.CreatedAt).ToListAsync();
        }

        // GET: api/Quotations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quotation>> GetQuotation(int id)
        {
            var quotation = await _context.Quotations.Include(q => q.Items).FirstOrDefaultAsync(q => q.Id == id);

            if (quotation == null)
            {
                return NotFound();
            }

            return quotation;
        }

        // POST: api/Quotations
        [HttpPost]
        public async Task<ActionResult<Quotation>> PostQuotation(Quotation quotation)
        {
            try
            {
                // Ensure dates are UTC for Postgres
                if (quotation.InvoiceDate.HasValue)
                    quotation.InvoiceDate = DateTime.SpecifyKind(quotation.InvoiceDate.Value, DateTimeKind.Utc);
                if (quotation.InquiryDate.HasValue)
                    quotation.InquiryDate = DateTime.SpecifyKind(quotation.InquiryDate.Value, DateTimeKind.Utc);

                quotation.Status = "Pending";
                quotation.CreatedAt = DateTime.UtcNow;

                // Generate a simple quotation number if not provided
                if (string.IsNullOrEmpty(quotation.QuotationNumber))
                {
                    var count = await _context.Quotations.CountAsync() + 1;
                    quotation.QuotationNumber = $"Q{DateTime.Now:yyMM}-{count:D2}"; // Format like Q2627-19
                }

                _context.Quotations.Add(quotation);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetQuotation", new { id = quotation.Id }, quotation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveQuotation(int id)
        {
            var quotation = await _context.Quotations.Include(q => q.Items).FirstOrDefaultAsync(q => q.Id == id);
            if (quotation == null) return NotFound();

            if (quotation.Status == "Approved") return BadRequest("Quotation is already approved.");

            quotation.Status = "Approved";

            // Generate Invoice from Quotation
            var invoice = new SalesInvoice
            {
                ClientName = quotation.CompanyName,
                InvoiceNo = quotation.QuotationNumber.Replace("Q", "INV"), 
                InvoiceDate = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                Amount = quotation.AmountExclGst,
                GstAmount = quotation.TotalIgst + quotation.TotalCgst + quotation.TotalSgst,
                TotalAmount = quotation.TotalAmount,
                PayAmount = 0,
                Status = "Pending",
                Items = quotation.Items.Select(item => new SalesInvoiceItem
                {
                    Description = item.Description,
                    Hsn = item.Hsn,
                    Quantity = item.Quantity,
                    Rate = item.Price,
                    Amount = item.Amount,
                    Total = item.Total,
                    GstPercentage = (item.Amount > 0) ? Math.Round((item.Total - item.Amount) / item.Amount * 100) : 18 // Default to 18 if calculation fails
                }).ToList()
            };

            _context.SalesInvoices.Add(invoice);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Quotation approved and invoice generated", invoiceId = invoice.Id });
        }

        // DELETE: api/Quotations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuotation(int id)
        {
            var quotation = await _context.Quotations.FindAsync(id);
            if (quotation == null)
            {
                return NotFound();
            }

            _context.Quotations.Remove(quotation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
