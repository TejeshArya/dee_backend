using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Location)
                .ToListAsync();
        }

        // GET: api/Employees/email/test@example.com
        [HttpGet("email/{email}")]
        public async Task<ActionResult<Employee>> GetEmployeeByEmail(string email)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Location)
                .FirstOrDefaultAsync(e => e.Email == email);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Location)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            // Check if email already exists
            if (await _context.Employees.AnyAsync(e => e.Email == employee.Email))
            {
                return Conflict(new { message = "An employee with this official email already exists." });
            }

            employee.CreatedAt = DateTime.UtcNow;
            employee.UpdatedAt = DateTime.UtcNow;
            employee.Status = "Pending"; // Always start as pending

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // POST: api/Employees/approve/5
        [HttpPost("approve/{id}")]
        public async Task<IActionResult> ApproveEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            // Generate Unique ID: DEE + DDMMYY + Index
            string dateStr = DateTime.Now.ToString("ddMMyy");
            int approvedCount = await _context.Employees.CountAsync(e => e.Status == "Active" || e.Status == "Approved");
            employee.EmployeeId = $"DEE{dateStr}{approvedCount + 101}";
            employee.Status = "Active";
            employee.UpdatedAt = DateTime.UtcNow;

            // Create User account for login
            var user = new User
            {
                Email = employee.Email,
                PasswordHash = employee.TemporaryPassword ?? "Welcome@123",
                FullName = employee.Name,
                Role = "User",
                CreatedAt = DateTime.UtcNow
            };

            if (!await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                _context.Users.Add(user);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Employee approved and account created", employeeId = employee.EmployeeId });
        }

        // POST: api/Employees/reject/5
        [HttpPost("reject/{id}")]
        public async Task<IActionResult> RejectEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            employee.Status = "Rejected";
            employee.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Employee request rejected" });
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;
            employee.UpdatedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
