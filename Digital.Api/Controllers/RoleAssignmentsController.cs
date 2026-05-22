using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAssignmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoleAssignmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/roleassignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleAssignment>>> GetRoleAssignments()
        {
            return await _context.RoleAssignments.OrderByDescending(r => r.Date).ToListAsync();
        }

        // GET: api/roleassignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleAssignment>> GetRoleAssignment(int id)
        {
            var assignment = await _context.RoleAssignments.FindAsync(id);
            if (assignment == null) return NotFound();
            return assignment;
        }

        // POST: api/roleassignments
        [HttpPost]
        public async Task<ActionResult<RoleAssignment>> PostRoleAssignment(RoleAssignment assignment)
        {
            if (assignment.Date == default)
            {
                assignment.Date = DateTime.UtcNow;
            }

            _context.RoleAssignments.Add(assignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRoleAssignment), new { id = assignment.Id }, assignment);
        }

        // POST: api/roleassignments/edit
        [HttpPost("edit")]
        public async Task<IActionResult> EditRoleAssignment(RoleAssignment assignment)
        {
            var existing = await _context.RoleAssignments.FindAsync(assignment.Id);
            if (existing == null) return NotFound();

            _context.Entry(existing).CurrentValues.SetValues(assignment);
            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        // DELETE: api/roleassignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleAssignment(int id)
        {
            var assignment = await _context.RoleAssignments.FindAsync(id);
            if (assignment == null) return NotFound();

            _context.RoleAssignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
