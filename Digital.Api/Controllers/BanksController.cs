using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BanksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Banks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank>>> GetBanks()
        {
            return await _context.Banks.OrderByDescending(b => b.CreatedAt).ToListAsync();
        }

        // POST: api/Banks
        [HttpPost]
        public async Task<ActionResult<Bank>> PostBank(Bank bank)
        {
            _context.Banks.Add(bank);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBanks), new { id = bank.Id }, bank);
        }

        // POST: api/Banks/edit
        [HttpPost("edit")]
        public async Task<IActionResult> EditBank(Bank bank)
        {
            var existing = await _context.Banks.FindAsync(bank.Id);
            if (existing == null) return NotFound();

            _context.Entry(existing).CurrentValues.SetValues(bank);
            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        // DELETE: api/Banks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank(int id)
        {
            var bank = await _context.Banks.FindAsync(id);
            if (bank == null) return NotFound();

            _context.Banks.Remove(bank);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
