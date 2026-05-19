using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationOfficersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DesignationOfficersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DesignationOfficers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesignationOfficer>>> GetDesignationOfficers()
        {
            return await _context.DesignationOfficers
                .OrderByDescending(d => d.Id)
                .ToListAsync();
        }

        // POST: api/DesignationOfficers
        [HttpPost]
        public async Task<ActionResult<DesignationOfficer>> PostDesignationOfficer(DesignationOfficer designationOfficer)
        {
            // If new officer is set to Present (EndTime is null)
            if (designationOfficer.EndTime == null)
            {
                // Find all existing records for the same DesignationName that are active (EndTime is null)
                var activePredecessors = await _context.DesignationOfficers
                    .Where(x => x.DesignationName.ToLower() == designationOfficer.DesignationName.ToLower() && x.EndTime == null)
                    .ToListAsync();

                foreach (var predecessor in activePredecessors)
                {
                    predecessor.EndTime = DateTime.UtcNow;
                }
            }

            _context.DesignationOfficers.Add(designationOfficer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDesignationOfficers), new { id = designationOfficer.Id }, designationOfficer);
        }

        // POST: api/DesignationOfficers/edit
        [HttpPost("edit")]
        public async Task<IActionResult> EditDesignationOfficer(DesignationOfficer designationOfficer)
        {
            var existing = await _context.DesignationOfficers.FindAsync(designationOfficer.Id);
            if (existing == null) return NotFound();

            // If transition from not Present to Present, or if we're setting it to Present now
            if (designationOfficer.EndTime == null && existing.EndTime != null)
            {
                // Find other active predecessors for this designation
                var activePredecessors = await _context.DesignationOfficers
                    .Where(x => x.Id != designationOfficer.Id && x.DesignationName.ToLower() == designationOfficer.DesignationName.ToLower() && x.EndTime == null)
                    .ToListAsync();

                foreach (var predecessor in activePredecessors)
                {
                    predecessor.EndTime = DateTime.UtcNow;
                }
            }

            _context.Entry(existing).CurrentValues.SetValues(designationOfficer);
            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        // DELETE: api/DesignationOfficers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesignationOfficer(int id)
        {
            var item = await _context.DesignationOfficers.FindAsync(id);
            if (item == null) return NotFound();

            _context.DesignationOfficers.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
