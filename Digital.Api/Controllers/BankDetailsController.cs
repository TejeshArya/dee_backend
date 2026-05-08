using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BankDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BankDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankDetail>>> GetBankDetails()
        {
            return await _context.BankDetails.OrderByDescending(b => b.CreatedAt).ToListAsync();
        }

        // POST: api/BankDetails
        [HttpPost]
        public async Task<ActionResult<BankDetail>> PostBankDetail(BankDetail bankDetail)
        {
            _context.BankDetails.Add(bankDetail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBankDetails), new { id = bankDetail.Id }, bankDetail);
        }

        // POST: api/BankDetails/edit
        [HttpPost("edit")]
        public async Task<IActionResult> EditBankDetail(BankDetail bankDetail)
        {
            var existing = await _context.BankDetails.FindAsync(bankDetail.Id);
            if (existing == null) return NotFound();

            _context.Entry(existing).CurrentValues.SetValues(bankDetail);
            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        // DELETE: api/BankDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankDetail(int id)
        {
            var bankDetail = await _context.BankDetails.FindAsync(id);
            if (bankDetail == null) return NotFound();

            _context.BankDetails.Remove(bankDetail);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
