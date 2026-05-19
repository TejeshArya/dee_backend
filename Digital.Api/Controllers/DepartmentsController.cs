using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _context.Departments
                .Include(d => d.Company)
                .OrderBy(d => d.Id)
                .ToListAsync();
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartments), new { id = department.Id }, department);
        }

        // POST: api/Departments/edit
        [HttpPost("edit")]
        public async Task<IActionResult> EditDepartment(Department department)
        {
            var existing = await _context.Departments.FindAsync(department.Id);
            if (existing == null) return NotFound();

            _context.Entry(existing).CurrentValues.SetValues(department);
            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var item = await _context.Departments.FindAsync(id);
            if (item == null) return NotFound();

            _context.Departments.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
