using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesInvoicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalesInvoicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesInvoice>>> GetSalesInvoices()
        {
            return await _context.SalesInvoices
                .Include(i => i.Items)
                .OrderByDescending(i => i.InvoiceDate)
                .ToListAsync();
        }

        // GET: api/SalesInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesInvoice>> GetSalesInvoice(int id)
        {
            var salesInvoice = await _context.SalesInvoices
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (salesInvoice == null)
            {
                return NotFound();
            }

            return salesInvoice;
        }

        // POST: api/SalesInvoices
        [HttpPost]
        public async Task<ActionResult<SalesInvoice>> PostSalesInvoice(SalesInvoice salesInvoice)
        {
            if (salesInvoice.InvoiceDate.HasValue)
                salesInvoice.InvoiceDate = DateTime.SpecifyKind(salesInvoice.InvoiceDate.Value, DateTimeKind.Utc);
            
            _context.SalesInvoices.Add(salesInvoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesInvoice", new { id = salesInvoice.Id }, salesInvoice);
        }

        // DELETE: api/SalesInvoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesInvoice(int id)
        {
            var salesInvoice = await _context.SalesInvoices.FindAsync(id);
            if (salesInvoice == null)
            {
                return NotFound();
            }

            _context.SalesInvoices.Remove(salesInvoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
