using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/wings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wing>>> GetWings()
        {
            return await _context.Wings.OrderByDescending(w => w.Id).ToListAsync();
        }

        // GET: api/wings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wing>> GetWing(int id)
        {
            var wing = await _context.Wings.FindAsync(id);
            if (wing == null) return NotFound();
            return wing;
        }

        // POST: api/wings
        [HttpPost]
        public async Task<ActionResult<Wing>> PostWing(Wing wing)
        {
            _context.Wings.Add(wing);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWing), new { id = wing.Id }, wing);
        }

        // POST: api/wings/edit
        [HttpPost("edit")]
        public async Task<IActionResult> EditWing(Wing wing)
        {
            var existing = await _context.Wings.FindAsync(wing.Id);
            if (existing == null) return NotFound();

            _context.Entry(existing).CurrentValues.SetValues(wing);
            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        // DELETE: api/wings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWing(int id)
        {
            var wing = await _context.Wings.FindAsync(id);
            if (wing == null) return NotFound();

            _context.Wings.Remove(wing);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
