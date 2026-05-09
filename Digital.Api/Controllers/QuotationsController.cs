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

                // Generate a simple quotation number if not provided
                if (string.IsNullOrEmpty(quotation.QuotationNumber))
                {
                    var count = await _context.Quotations.CountAsync() + 1;
                    quotation.QuotationNumber = $"QT-{DateTime.Now:yyyyMM}-{count:D4}";
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
