using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;
using System.Text.Json;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseInvoicesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PurchaseInvoicesController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseInvoice>>> GetPurchaseInvoices()
        {
            return await _context.PurchaseInvoices.Include(p => p.Items).OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<PurchaseInvoice>> PostPurchaseInvoice([FromForm] string data, IFormFile? file)
        {
            try
            {
                var invoice = JsonSerializer.Deserialize<PurchaseInvoice>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (invoice == null) return BadRequest("Invalid invoice data.");

                // Handle Date Kind for Postgres
                if (invoice.InvoiceDate.HasValue)
                    invoice.InvoiceDate = DateTime.SpecifyKind(invoice.InvoiceDate.Value, DateTimeKind.Utc);
                
                foreach(var item in invoice.Items)
                {
                    if (item.ExpiryDate.HasValue)
                        item.ExpiryDate = DateTime.SpecifyKind(item.ExpiryDate.Value, DateTimeKind.Utc);
                }

                if (file != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "purchases");
                    if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);
                    
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    invoice.InvoiceFilePath = "/uploads/purchases/" + uniqueFileName;
                }

                _context.PurchaseInvoices.Add(invoice);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPurchaseInvoices", new { id = invoice.Id }, invoice);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, inner = ex.InnerException?.Message });
            }
        }
    }
}
