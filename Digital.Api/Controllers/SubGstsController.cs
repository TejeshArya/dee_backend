using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubGstsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubGstsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SubGsts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubGst>>> GetSubGsts()
        {
            return await _context.SubGsts.OrderByDescending(s => s.CreatedAt).ToListAsync();
        }

        // POST: api/SubGsts
        [HttpPost]
        public async Task<ActionResult<SubGst>> PostSubGst(SubGst subGst)
        {
            _context.SubGsts.Add(subGst);

            if (!string.IsNullOrWhiteSpace(subGst.Department) && !string.IsNullOrWhiteSpace(subGst.OfficerName))
            {
                string deptOfficerName = $"{subGst.Department.Trim()} - {subGst.OfficerName.Trim()}";
                var exists = await _context.Departments.AnyAsync(d => d.Name.ToLower() == deptOfficerName.ToLower());
                if (!exists)
                {
                    _context.Departments.Add(new Department { Name = deptOfficerName });
                }
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSubGsts), new { id = subGst.Id }, subGst);
        }

        // POST: api/SubGsts/edit
        [HttpPost("edit")]
        public async Task<IActionResult> EditSubGst(SubGst subGst)
        {
            var existing = await _context.SubGsts.FindAsync(subGst.Id);
            if (existing == null) return NotFound();

            _context.Entry(existing).CurrentValues.SetValues(subGst);

            if (!string.IsNullOrWhiteSpace(subGst.Department) && !string.IsNullOrWhiteSpace(subGst.OfficerName))
            {
                string deptOfficerName = $"{subGst.Department.Trim()} - {subGst.OfficerName.Trim()}";
                var exists = await _context.Departments.AnyAsync(d => d.Name.ToLower() == deptOfficerName.ToLower());
                if (!exists)
                {
                    _context.Departments.Add(new Department { Name = deptOfficerName });
                }
            }

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        // DELETE: api/SubGsts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubGst(int id)
        {
            var subGst = await _context.SubGsts.FindAsync(id);
            if (subGst == null) return NotFound();

            _context.SubGsts.Remove(subGst);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
