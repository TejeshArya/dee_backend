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
    public class EmployeeFundsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeFundsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeFunds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeFund>>> GetEmployeeFunds(
            [FromQuery] int? employeeId = null,
            [FromQuery] string? status = null,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            var query = _context.EmployeeFunds
                .Include(ef => ef.Employee)
                .AsQueryable();

            if (employeeId.HasValue && employeeId.Value > 0)
            {
                query = query.Where(ef => ef.EmployeeId == employeeId.Value);
            }

            if (!string.IsNullOrWhiteSpace(status) && status != "All Statuses")
            {
                query = query.Where(ef => ef.Status.ToLower() == status.Trim().ToLower());
            }

            if (fromDate.HasValue)
            {
                query = query.Where(ef => ef.GivenDate >= fromDate.Value.Date);
            }

            if (toDate.HasValue)
            {
                query = query.Where(ef => ef.GivenDate <= toDate.Value.Date.AddDays(1).AddTicks(-1));
            }

            return await query
                .OrderByDescending(ef => ef.GivenDate)
                .ThenByDescending(ef => ef.Id)
                .ToListAsync();
        }

        // GET: api/EmployeeFunds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeFund>> GetEmployeeFund(int id)
        {
            var fund = await _context.EmployeeFunds
                .Include(ef => ef.Employee)
                .FirstOrDefaultAsync(ef => ef.Id == id);

            if (fund == null)
            {
                return NotFound();
            }

            return fund;
        }

        // POST: api/EmployeeFunds
        [HttpPost]
        public async Task<ActionResult<EmployeeFund>> PostEmployeeFund(EmployeeFundInput input)
        {
            if (input.EmployeeId <= 0)
            {
                return BadRequest("A valid Employee must be selected.");
            }

            if (input.Amount <= 0)
            {
                return BadRequest("Amount must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(input.Purpose))
            {
                return BadRequest("Purpose is required.");
            }

            var employeeExists = await _context.Employees.AnyAsync(e => e.Id == input.EmployeeId);
            if (!employeeExists)
            {
                return BadRequest("Selected employee does not exist.");
            }

            string refNo = string.IsNullOrWhiteSpace(input.RefNo) 
                ? $"FT-{new Random().Next(100000, 999999)}"
                : input.RefNo.Trim();

            var fund = new EmployeeFund
            {
                EmployeeId = input.EmployeeId,
                Amount = input.Amount,
                GivenDate = input.GivenDate ?? DateTime.UtcNow.Date,
                Purpose = input.Purpose.Trim(),
                Status = string.IsNullOrWhiteSpace(input.Status) ? "Pending" : input.Status.Trim(),
                RefNo = refNo,
                RecordedBy = string.IsNullOrWhiteSpace(input.RecordedBy) ? "AMANTU" : input.RecordedBy.Trim(),
                CreatedAt = DateTime.UtcNow
            };

            _context.EmployeeFunds.Add(fund);
            await _context.SaveChangesAsync();

            var fullyLoaded = await _context.EmployeeFunds
                .Include(ef => ef.Employee)
                .FirstOrDefaultAsync(ef => ef.Id == fund.Id);

            return CreatedAtAction(nameof(GetEmployeeFund), new { id = fund.Id }, fullyLoaded);
        }

        // PUT: api/EmployeeFunds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeFund(int id, EmployeeFundInput input)
        {
            var fund = await _context.EmployeeFunds.FindAsync(id);
            if (fund == null)
            {
                return NotFound();
            }

            if (input.EmployeeId <= 0)
            {
                return BadRequest("A valid Employee must be selected.");
            }

            if (input.Amount <= 0)
            {
                return BadRequest("Amount must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(input.Purpose))
            {
                return BadRequest("Purpose is required.");
            }

            var employeeExists = await _context.Employees.AnyAsync(e => e.Id == input.EmployeeId);
            if (!employeeExists)
            {
                return BadRequest("Selected employee does not exist.");
            }

            fund.EmployeeId = input.EmployeeId;
            fund.Amount = input.Amount;
            fund.GivenDate = input.GivenDate ?? fund.GivenDate;
            fund.Purpose = input.Purpose.Trim();
            fund.Status = string.IsNullOrWhiteSpace(input.Status) ? fund.Status : input.Status.Trim();
            if (!string.IsNullOrWhiteSpace(input.RefNo))
            {
                fund.RefNo = input.RefNo.Trim();
            }
            if (!string.IsNullOrWhiteSpace(input.RecordedBy))
            {
                fund.RecordedBy = input.RecordedBy.Trim();
            }

            _context.Entry(fund).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/EmployeeFunds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeFund(int id)
        {
            var fund = await _context.EmployeeFunds.FindAsync(id);
            if (fund == null)
            {
                return NotFound();
            }

            _context.EmployeeFunds.Remove(fund);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class EmployeeFundInput
    {
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? GivenDate { get; set; }
        public string Purpose { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public string RefNo { get; set; } = string.Empty;
        public string RecordedBy { get; set; } = "AMANTU";
    }
}
