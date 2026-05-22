using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LocationsController(AppDbContext context) => _context = context;

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            return await _context.Locations.OrderByDescending(l => l.Id).ToListAsync();
        }

        // POST: api/Locations
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            location.CreatedAt = DateTime.UtcNow;
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLocations), new { id = location.Id }, location);
        }

        // POST: api/Locations/edit
        [HttpPost("edit")]
        public async Task<IActionResult> EditLocation(Location location)
        {
            var existing = await _context.Locations.FindAsync(location.Id);
            if (existing == null) return NotFound();

            existing.Name = location.Name;
            existing.Description = location.Description;
            // keep existing CreatedAt

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null) return NotFound();

            // Set LocationId to null for any employees assigned to this location
            var employees = await _context.Employees.Where(e => e.LocationId == id).ToListAsync();
            foreach (var employee in employees)
            {
                employee.LocationId = null;
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
