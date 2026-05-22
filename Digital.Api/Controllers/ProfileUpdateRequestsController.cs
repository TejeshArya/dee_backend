using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileUpdateRequestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfileUpdateRequestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProfileUpdateRequests?status=Pending
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeProfileUpdateRequest>>> GetProfileUpdateRequests(
            [FromQuery] string? status = null)
        {
            var query = _context.ProfileUpdateRequests
                .Include(r => r.Employee)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(status) && status.ToLower() != "all")
            {
                query = query.Where(r => r.Status.ToLower() == status.Trim().ToLower());
            }

            return await query
                .OrderByDescending(r => r.RequestedAt)
                .ToListAsync();
        }

        // GET: api/ProfileUpdateRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeProfileUpdateRequest>> GetProfileUpdateRequest(int id)
        {
            var request = await _context.ProfileUpdateRequests
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (request == null) return NotFound();

            return request;
        }

        // POST: api/ProfileUpdateRequests
        [HttpPost]
        public async Task<ActionResult<EmployeeProfileUpdateRequest>> CreateProfileUpdateRequest(
            ProfileUpdateRequestInput input)
        {
            if (input.EmployeeId <= 0)
                return BadRequest("A valid Employee must be selected.");

            if (string.IsNullOrWhiteSpace(input.FieldName))
                return BadRequest("FieldName is required.");

            if (string.IsNullOrWhiteSpace(input.NewValue))
                return BadRequest("NewValue is required.");

            var employeeExists = await _context.Employees.AnyAsync(e => e.Id == input.EmployeeId);
            if (!employeeExists)
                return BadRequest("The specified employee does not exist.");

            var request = new EmployeeProfileUpdateRequest
            {
                EmployeeId = input.EmployeeId,
                FieldName = input.FieldName.Trim(),
                OldValue = input.OldValue?.Trim(),
                NewValue = input.NewValue.Trim(),
                Status = "Pending",
                RequestedAt = DateTime.UtcNow
            };

            _context.ProfileUpdateRequests.Add(request);
            await _context.SaveChangesAsync();

            var loaded = await _context.ProfileUpdateRequests
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(r => r.Id == request.Id);

            return CreatedAtAction(nameof(GetProfileUpdateRequest), new { id = request.Id }, loaded);
        }

        // POST: api/ProfileUpdateRequests/5/approve
        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveRequest(int id, [FromBody] ReviewActionInput? input)
        {
            var request = await _context.ProfileUpdateRequests
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (request == null) return NotFound();
            if (request.Status != "Pending")
                return BadRequest("Only pending requests can be approved.");

            // Apply the change to the actual Employee record
            var employee = await _context.Employees.FindAsync(request.EmployeeId);
            if (employee != null)
            {
                ApplyFieldChange(employee, request.FieldName, request.NewValue);
                employee.UpdatedAt = DateTime.UtcNow;
                _context.Entry(employee).State = EntityState.Modified;
            }

            request.Status = "Approved";
            request.ReviewedAt = DateTime.UtcNow;
            request.ReviewedBy = input?.ReviewedBy ?? "AMANTU";

            await _context.SaveChangesAsync();

            return Ok(new { message = $"Request #{id} approved and employee record updated." });
        }

        // POST: api/ProfileUpdateRequests/5/reject
        [HttpPost("{id}/reject")]
        public async Task<IActionResult> RejectRequest(int id, [FromBody] ReviewActionInput? input)
        {
            var request = await _context.ProfileUpdateRequests.FindAsync(id);

            if (request == null) return NotFound();
            if (request.Status != "Pending")
                return BadRequest("Only pending requests can be rejected.");

            request.Status = "Rejected";
            request.RejectionReason = input?.RejectionReason?.Trim();
            request.ReviewedAt = DateTime.UtcNow;
            request.ReviewedBy = input?.ReviewedBy ?? "AMANTU";

            await _context.SaveChangesAsync();

            return Ok(new { message = $"Request #{id} has been rejected." });
        }

        // DELETE: api/ProfileUpdateRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileUpdateRequest(int id)
        {
            var request = await _context.ProfileUpdateRequests.FindAsync(id);
            if (request == null) return NotFound();

            _context.ProfileUpdateRequests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Applies a field change to an Employee entity by field name (case-insensitive).
        /// Only safe, whitelisted fields are supported.
        /// </summary>
        private static void ApplyFieldChange(Employee employee, string fieldName, string newValue)
        {
            switch (fieldName.ToLower().Trim())
            {
                case "email":
                    employee.Email = newValue;
                    break;
                case "role":
                    employee.Role = newValue;
                    break;
                case "qualification":
                    employee.Qualification = newValue;
                    break;
                case "annualsalary":
                case "salary":
                    employee.AnnualSalary = newValue;
                    break;
                case "remarks":
                    employee.Remarks = newValue;
                    break;
                case "name":
                    employee.Name = newValue;
                    break;
                // Additional safe fields can be added here
                default:
                    // Unknown/unsupported field — skip the DB write but still approve the request
                    break;
            }
        }
    }

    public class ProfileUpdateRequestInput
    {
        public int EmployeeId { get; set; }
        public string FieldName { get; set; } = string.Empty;
        public string? OldValue { get; set; }
        public string NewValue { get; set; } = string.Empty;
    }

    public class ReviewActionInput
    {
        public string? RejectionReason { get; set; }
        public string? ReviewedBy { get; set; }
    }
}
