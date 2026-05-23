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

        // ─────────────────────────────────────────
        // GET: api/Employees
        // ─────────────────────────────────────────
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetEmployees()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Location)
                .Include(e => e.FamilyMembers)
                .OrderByDescending(e => e.CreatedAt)
                .Select(e => new
                {
                    e.Id, e.EmployeeId, e.Name, e.Email, e.Role, e.Status,
                    e.Designation, e.DateOfJoining, e.Qualification, e.AnnualSalary,
                    e.MobileNumber, e.Gender, e.BloodGroup, e.MaritalStatus, e.Category,
                    DepartmentName = e.Department != null ? e.Department.Name : null,
                    LocationName   = e.Location   != null ? e.Location.Name   : null,
                    FamilyMembersCount = e.FamilyMembers != null ? e.FamilyMembers.Count : 0,
                    e.CreatedAt
                })
                .ToListAsync();
        }

        // GET: api/Employees/email/{email}
        [HttpGet("email/{email}")]
        public async Task<ActionResult<Employee>> GetEmployeeByEmail(string email)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Location)
                .Include(e => e.FamilyMembers)
                .FirstOrDefaultAsync(e => e.Email == email);

            if (employee == null) return NotFound();
            return employee;
        }

        // GET: api/Employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetEmployee(int id)
        {
            var e = await _context.Employees
                .Include(emp => emp.Department)
                .Include(emp => emp.Location)
                .Include(emp => emp.FamilyMembers)
                .FirstOrDefaultAsync(emp => emp.Id == id);

            if (e == null) return NotFound();

            return Ok(new
            {
                e.Id, e.EmployeeId, e.Name, e.Email, e.Role, e.Status,
                e.Designation, e.DateOfJoining, e.Qualification, e.AnnualSalary, e.Remarks,
                e.DateOfBirth, e.Gender, e.MaritalStatus, e.BloodGroup, e.Religion, e.Category,
                e.MobileNumber, e.AlternateNumber,
                e.CurrentAddress, e.PermanentAddress,
                e.AadharNumber, e.PanNumber, e.UanNumber, e.EsicNumber,
                e.PassportNumber, e.PassportValidUpto,
                e.PvcNumber, e.PvcValidUpto,
                e.BankName, e.AccountNumber, e.IfscCode, e.BranchName, e.AccountType,
                e.EmergencyContactName, e.EmergencyContactPhone, e.EmergencyContactRelation,
                e.NomineeName, e.NomineeRelation, e.NomineeDOB,
                DepartmentName = e.Department != null ? e.Department.Name : null,
                LocationName   = e.Location   != null ? e.Location.Name   : null,
                FamilyMembers  = e.FamilyMembers,
                e.CreatedAt, e.UpdatedAt
            });
        }

        // ─────────────────────────────────────────
        // POST: api/Employees  — Create a new employee from form
        // ─────────────────────────────────────────
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] CreateEmployeeDto dto)
        {
            // Email uniqueness check
            if (await _context.Employees.AnyAsync(e => e.Email == dto.Email))
                return Conflict(new { message = "An employee with this official email already exists." });

            // Resolve DepartmentId from name if provided
            int? departmentId = null;
            if (!string.IsNullOrWhiteSpace(dto.Department))
            {
                var dept = await _context.Departments
                    .FirstOrDefaultAsync(d => d.Name.ToLower() == dto.Department.ToLower());
                departmentId = dept?.Id;
            }

            // Resolve LocationId from name if provided
            int? locationId = null;
            if (!string.IsNullOrWhiteSpace(dto.Location))
            {
                var loc = await _context.Locations
                    .FirstOrDefaultAsync(l => l.Name.ToLower() == dto.Location.ToLower());
                locationId = loc?.Id;
            }

            var employee = new Employee
            {
                Name                    = dto.Name,
                Email                   = dto.Email,
                Role                    = dto.Role ?? "Employee",
                Status                  = "Pending",
                TemporaryPassword       = dto.TemporaryPassword,
                AnnualSalary            = dto.AnnualSalary,
                Qualification           = dto.Qualification,
                Remarks                 = dto.Remarks,
                DepartmentId            = departmentId,
                LocationId              = locationId,
                Designation             = dto.Designation,
                DateOfJoining           = dto.DateOfJoining,
                DateOfBirth             = dto.DateOfBirth,
                Gender                  = dto.Gender,
                MaritalStatus           = dto.MaritalStatus,
                BloodGroup              = dto.BloodGroup,
                Religion                = dto.Religion,
                Category                = dto.Category,
                MobileNumber            = dto.MobileNumber,
                AlternateNumber         = dto.AlternateNumber,
                CurrentAddress          = dto.CurrentAddress,
                PermanentAddress        = dto.PermanentAddress,
                AadharNumber            = dto.AadharNumber,
                PanNumber               = dto.PanNumber,
                UanNumber               = dto.UanNumber,
                EsicNumber              = dto.EsicNumber,
                PassportNumber          = dto.PassportNumber,
                PassportValidUpto       = dto.PassportValidUpto,
                PvcNumber               = dto.PvcNumber,
                PvcValidUpto            = dto.PvcValidUpto,
                BankName                = dto.BankName,
                AccountNumber           = dto.AccountNumber,
                IfscCode                = dto.IfscCode,
                BranchName              = dto.BranchName,
                AccountType             = dto.AccountType,
                EmergencyContactName    = dto.EmergencyContactName,
                EmergencyContactPhone   = dto.EmergencyContactPhone,
                EmergencyContactRelation= dto.EmergencyContactRelation,
                NomineeName             = dto.NomineeName,
                NomineeRelation         = dto.NomineeRelation,
                NomineeDOB              = dto.NomineeDOB,
                CreatedAt               = DateTime.UtcNow,
                UpdatedAt               = DateTime.UtcNow,
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            // Save family members
            if (dto.FamilyMembers != null && dto.FamilyMembers.Count > 0)
            {
                foreach (var fm in dto.FamilyMembers.Where(m => !string.IsNullOrWhiteSpace(m.Name)))
                {
                    _context.EmployeeFamilyMembers.Add(new EmployeeFamilyMember
                    {
                        EmployeeId  = employee.Id,
                        Name        = fm.Name,
                        Relation    = fm.Relation,
                        DateOfBirth = fm.DateOfBirth,
                        MealType    = fm.MealType,
                        CreatedAt   = DateTime.UtcNow
                    });
                }
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id },
                new { message = "Employee registered successfully", id = employee.Id, status = employee.Status });
        }

        // ─────────────────────────────────────────
        // POST: api/Employees/approve/{id}
        // ─────────────────────────────────────────
        [HttpPost("approve/{id}")]
        public async Task<IActionResult> ApproveEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            string dateStr = DateTime.Now.ToString("ddMMyy");
            int approvedCount = await _context.Employees.CountAsync(e => e.Status == "Active" || e.Status == "Approved");
            employee.EmployeeId = $"DEE{dateStr}{approvedCount + 101}";
            employee.Status     = "Active";
            employee.UpdatedAt  = DateTime.UtcNow;

            var user = new User
            {
                Email        = employee.Email,
                PasswordHash = employee.TemporaryPassword ?? "Welcome@123",
                FullName     = employee.Name,
                RoleId       = 18,
                CreatedAt    = DateTime.UtcNow
            };

            if (!await _context.Users.AnyAsync(u => u.Email == user.Email))
                _context.Users.Add(user);

            await _context.SaveChangesAsync();
            return Ok(new { message = "Employee approved and account created", employeeId = employee.EmployeeId });
        }

        // POST: api/Employees/reject/{id}
        [HttpPost("reject/{id}")]
        public async Task<IActionResult> RejectEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            employee.Status    = "Rejected";
            employee.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Employee request rejected" });
        }

        // PUT: api/Employees/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();

            _context.Entry(employee).State = EntityState.Modified;
            employee.UpdatedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Employees/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            // Cascade-delete family members
            var members = _context.EmployeeFamilyMembers.Where(m => m.EmployeeId == id);
            _context.EmployeeFamilyMembers.RemoveRange(members);

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EmployeeExists(int id) => _context.Employees.Any(e => e.Id == id);
    }

    // ─────────────────────────────────────────
    // DTOs
    // ─────────────────────────────────────────
    public class CreateEmployeeDto
    {
        // Basic
        public string Name              { get; set; } = string.Empty;
        public string Email             { get; set; } = string.Empty;
        public string? EmployeeCode     { get; set; }
        public string? Role             { get; set; }
        public string? Department       { get; set; }
        public string? Location         { get; set; }
        public string? Designation      { get; set; }
        public string? DateOfJoining    { get; set; }
        public string? Qualification    { get; set; }
        public string? AnnualSalary     { get; set; }
        public string? Remarks          { get; set; }
        public string? TemporaryPassword{ get; set; }

        // Personal
        public string? DateOfBirth      { get; set; }
        public string? Gender           { get; set; }
        public string? MaritalStatus    { get; set; }
        public string? BloodGroup       { get; set; }
        public string? Religion         { get; set; }
        public string? Category         { get; set; }
        public string? MobileNumber     { get; set; }
        public string? AlternateNumber  { get; set; }

        // Address
        public string? CurrentAddress   { get; set; }
        public string? PermanentAddress { get; set; }

        // Govt IDs
        public string? AadharNumber     { get; set; }
        public string? PanNumber        { get; set; }
        public string? UanNumber        { get; set; }
        public string? EsicNumber       { get; set; }
        public string? PassportNumber   { get; set; }
        public string? PassportValidUpto{ get; set; }
        public string? PvcNumber        { get; set; }
        public string? PvcValidUpto     { get; set; }

        // Bank
        public string? BankName         { get; set; }
        public string? AccountNumber    { get; set; }
        public string? IfscCode         { get; set; }
        public string? BranchName       { get; set; }
        public string? AccountType      { get; set; }

        // Emergency
        public string? EmergencyContactName     { get; set; }
        public string? EmergencyContactPhone    { get; set; }
        public string? EmergencyContactRelation { get; set; }

        // Nominee
        public string? NomineeName      { get; set; }
        public string? NomineeRelation  { get; set; }
        public string? NomineeDOB       { get; set; }

        // Family
        public List<FamilyMemberDto>? FamilyMembers { get; set; }
    }

    public class FamilyMemberDto
    {
        public string Name          { get; set; } = string.Empty;
        public string? Relation     { get; set; }
        public string? DateOfBirth  { get; set; }
        public string? MealType     { get; set; }
    }
}
