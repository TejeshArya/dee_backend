using Microsoft.AspNetCore.Mvc;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SeedController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("employees")]
        public async Task<IActionResult> SeedEmployees()
        {
            if (_context.Employees.Any()) return BadRequest("Database already seeded");

            var employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = "DEE300426132",
                    Name = "TEJESH GUDLA",
                    Email = "tejeshgudla2@gmail.com",
                    LocationId = 1,
                    DepartmentId = 1,
                    Role = "IT",
                    Status = "Active",
                    CreatedAt = DateTime.SpecifyKind(DateTime.Parse("2026-04-30"), DateTimeKind.Utc)
                },
                new Employee
                {
                    EmployeeId = "DEE130426131",
                    Name = "GANDIBOINA GOWRI PRASAD",
                    Email = "gowriprasad111@gmail.com",
                    LocationId = 1,
                    DepartmentId = 1,
                    Role = "ASSISTANT MANAGER",
                    Status = "Active",
                    CreatedAt = DateTime.SpecifyKind(DateTime.Parse("2026-04-13"), DateTimeKind.Utc)
                },
                new Employee
                {
                    EmployeeId = "DEE040426130",
                    Name = "RAVENDRA SINGH",
                    Email = "ravendrasinghchouhan@gmail.com",
                    LocationId = 2,
                    DepartmentId = 2,
                    Role = "SENIOR MANAGER",
                    Status = "Active",
                    CreatedAt = DateTime.SpecifyKind(DateTime.Parse("2026-04-04"), DateTimeKind.Utc)
                }
            };

            _context.Employees.AddRange(employees);
            await _context.SaveChangesAsync();

            return Ok("Sample employees seeded successfully");
        }

        [HttpPost("projects")]
        public async Task<IActionResult> SeedProjects()
        {
            if (_context.Projects.Any()) return BadRequest("Database already seeded");

            var projects = new List<Project>
            {
                new Project
                {
                    ProjectId = "PRJ-2024-01",
                    Name = "OFFICE RENOVATION AND SETUP",
                    Wing = "FACILITIES",
                    Department = "Engineering",
                    Location = "Headquarters",
                    Post = "PROJECT LEAD",
                    CreatedBy = "JOHN DOE",
                    Client = "ACME CORP",
                    Gst = "00ABCDE1234...",
                    Value = "2,500,000",
                    StartDate = DateTime.SpecifyKind(DateTime.Parse("2024-04-20"), DateTimeKind.Utc),
                    EndDate = DateTime.SpecifyKind(DateTime.Parse("2024-10-20"), DateTimeKind.Utc),
                    Status = "In Progress",
                    Priority = "High",
                    Description = "Complete renovation of the 4th floor office space including new furniture, networking, and interior design."
                },
                new Project
                {
                    ProjectId = "PRJ-2024-02",
                    Name = "DATA CENTER UPGRADE",
                    Wing = "IT INFRA",
                    Department = "Technology",
                    Location = "Data Center A",
                    Post = "INFRA LEAD",
                    CreatedBy = "JANE SMITH",
                    Client = "GLOBAL TECH",
                    Gst = "11FGHIJ5678...",
                    Value = "5,000,000",
                    StartDate = DateTime.SpecifyKind(DateTime.Parse("2024-05-01"), DateTimeKind.Utc),
                    EndDate = DateTime.SpecifyKind(DateTime.Parse("2024-12-31"), DateTimeKind.Utc),
                    Status = "Planning",
                    Priority = "Critical",
                    Description = "Upgrading the core server racks and cooling systems in Data Center A."
                }
            };

            _context.Projects.AddRange(projects);
            await _context.SaveChangesAsync();

            return Ok("Sample projects seeded successfully");
        }
        [HttpPost("companygsts")]
        public async Task<IActionResult> SeedCompanyGst()
        {
            if (_context.CompanyGsts.Any()) return BadRequest("Database already seeded");

            var companyGsts = new List<CompanyGst>
            {
                new CompanyGst { GstNumber = "33ANVES1111A1Z1", CompanyName = "INS ANVESH", StateName = "TAMIL NADU", MobileNumber = "8912578000", Email = "anvesh-navy@gov.in", GstStateCode = "33" },
                new CompanyGst { GstNumber = "37COMNC1111A1Z1", CompanyName = "COMMUNICATION NETWORK CENTER", StateName = "ANDHRA PRADESH", MobileNumber = "8912812630", Email = "netwarcom_suff_csc@navy.mil", GstStateCode = "37" },
                new CompanyGst { GstNumber = "27TABAR1111A1Z1", CompanyName = "INS TABAR", StateName = "MAHARASHTRA", MobileNumber = "9409520932", Email = "TABAR-NAVY@GOV.IN", GstStateCode = "27" },
                new CompanyGst { GstNumber = "27BGIPG2942N1Z2", CompanyName = "FLEET MAINTENANCE UNIT MUMBAI", StateName = "MAHARASHTRA", MobileNumber = "9161224444", Email = "fmipl@fleetship.com", GstStateCode = "27" },
                new CompanyGst { GstNumber = "20AAECC7652H1ZU", CompanyName = "Eekakshara Projects Pvt Ltd", StateName = "JHARKHAND", MobileNumber = "9234600666", Email = "jatz1986@gmail.com", GstStateCode = "20" },
                new CompanyGst { GstNumber = "27WEDMA1111A1Z1", CompanyName = "WED MANKHURD", StateName = "MAHARASHTRA", MobileNumber = "9956562952", Email = "wed@navy.gov.in", GstStateCode = "27" }
            };

            _context.CompanyGsts.AddRange(companyGsts);
            await _context.SaveChangesAsync();

            return Ok("Sample companies seeded successfully");
        }
    }
}
