using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationHeadsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocationHeadsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LocationHeads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationHead>>> GetLocationHeads()
        {
            return await _context.LocationHeads
                .Include(lh => lh.Location)
                .Include(lh => lh.Employee)
                .OrderByDescending(lh => lh.AssignedAt)
                .ToListAsync();
        }

        // POST: api/LocationHeads
        [HttpPost]
        public async Task<ActionResult<LocationHead>> PostLocationHead(LocationHead input)
        {
            if (input.LocationId <= 0 || input.EmployeeId <= 0)
            {
                return BadRequest("Invalid Location or Employee selection.");
            }

            // Verify both entities exist
            var locationExists = await _context.Locations.AnyAsync(l => l.Id == input.LocationId);
            var employeeExists = await _context.Employees.AnyAsync(e => e.Id == input.EmployeeId);

            if (!locationExists || !employeeExists)
            {
                return BadRequest("Selected Location or Employee does not exist.");
            }

            // Find if there is already an assignment for this Location
            var existing = await _context.LocationHeads
                .FirstOrDefaultAsync(lh => lh.LocationId == input.LocationId);

            if (existing != null)
            {
                // Update existing record (Upsert)
                existing.EmployeeId = input.EmployeeId;
                existing.AssignedAt = DateTime.UtcNow;
                
                await _context.SaveChangesAsync();

                // Load relationships
                await _context.Entry(existing).Reference(lh => lh.Location).LoadAsync();
                await _context.Entry(existing).Reference(lh => lh.Employee).LoadAsync();

                return Ok(existing);
            }
            else
            {
                // Create new assignment
                var newHead = new LocationHead
                {
                    LocationId = input.LocationId,
                    EmployeeId = input.EmployeeId,
                    AssignedAt = DateTime.UtcNow
                };

                _context.LocationHeads.Add(newHead);
                await _context.SaveChangesAsync();

                // Load relationships
                await _context.Entry(newHead).Reference(lh => lh.Location).LoadAsync();
                await _context.Entry(newHead).Reference(lh => lh.Employee).LoadAsync();

                return CreatedAtAction(nameof(GetLocationHeads), new { id = newHead.Id }, newHead);
            }
        }

        // DELETE: api/LocationHeads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationHead(int id)
        {
            var assignment = await _context.LocationHeads.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.LocationHeads.Remove(assignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
