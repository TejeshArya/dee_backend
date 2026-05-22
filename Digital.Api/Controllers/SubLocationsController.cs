using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubLocationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubLocationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SubLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubLocation>>> GetSubLocations()
        {
            return await _context.SubLocations
                .Include(s => s.Location)
                .OrderByDescending(s => s.Id)
                .ToListAsync();
        }

        // POST: api/SubLocations
        [HttpPost]
        public async Task<ActionResult<SubLocation>> PostSubLocation(SubLocation subLocation)
        {
            subLocation.CreatedAt = DateTime.UtcNow;
            _context.SubLocations.Add(subLocation);
            await _context.SaveChangesAsync();

            // Load the Location relationship for returning
            await _context.Entry(subLocation).Reference(s => s.Location).LoadAsync();

            return CreatedAtAction(nameof(GetSubLocations), new { id = subLocation.Id }, subLocation);
        }

        // POST: api/SubLocations/edit
        [HttpPost("edit")]
        public async Task<IActionResult> EditSubLocation(SubLocation subLocation)
        {
            var existing = await _context.SubLocations.FindAsync(subLocation.Id);
            if (existing == null) return NotFound();

            existing.LocationId = subLocation.LocationId;
            existing.Name = subLocation.Name;
            existing.Description = subLocation.Description;
            // keep existing CreatedAt

            await _context.SaveChangesAsync();

            // Load reference
            await _context.Entry(existing).Reference(s => s.Location).LoadAsync();

            return Ok(existing);
        }

        // DELETE: api/SubLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubLocation(int id)
        {
            var subLocation = await _context.SubLocations.FindAsync(id);
            if (subLocation == null) return NotFound();

            _context.SubLocations.Remove(subLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
