using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;     
namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Roles.OrderByDescending(r => r.Id).ToListAsync();
        }

        // GET: api/roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return NotFound();
            return role;
        }

        // POST: api/roles
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            if (string.IsNullOrWhiteSpace(role.DisplayName))
            {
                role.DisplayName = role.Name;
            }

            // In PostgreSQL, if an explicit identity ID is passed and > 0,
            // we check if it already exists to prevent crashes.
            if (role.Id > 0)
            {
                var exists = await _context.Roles.AnyAsync(r => r.Id == role.Id);
                if (exists)
                {
                    return Conflict(new { message = $"Role with ID {role.Id} already exists." });
                }
            }

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
        }
      
        // POST: api/roles/edit
        [HttpPost("edit")]
        public async Task<IActionResult> EditRole(Role role)
        {
            var existing = await _context.Roles.FindAsync(role.Id);
            if (existing == null) return NotFound();

            if (string.IsNullOrWhiteSpace(role.DisplayName))
            {
                role.DisplayName = role.Name;
            }

            _context.Entry(existing).CurrentValues.SetValues(role);
            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        // DELETE: api/roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return NotFound();

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
