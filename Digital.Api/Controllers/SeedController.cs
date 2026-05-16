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

        [HttpPost("salesinvoices")]
        public async Task<IActionResult> SeedSalesInvoices()
        {
            _context.SalesInvoices.RemoveRange(_context.SalesInvoices);
            await _context.SaveChangesAsync();
            
            var invoices = new List<SalesInvoice>
            {
                new SalesInvoice
                {
                    ClientName = "INS TAMAL",
                    InvoiceNo = "DEE2627110",
                    InvoiceDate = DateTime.SpecifyKind(DateTime.Parse("2026-05-14"), DateTimeKind.Utc),
                    Amount = 44750.00m,
                    GstAmount = 2237.50m,
                    TotalAmount = 46987.50m,
                    PayAmount = 0.00m,
                    Status = "Pending"
                },
                new SalesInvoice
                {
                    ClientName = "INS TAMAL",
                    InvoiceNo = "DEE2627109",
                    InvoiceDate = DateTime.SpecifyKind(DateTime.Parse("2026-05-14"), DateTimeKind.Utc),
                    Amount = 45700.00m,
                    GstAmount = 2285.00m,
                    TotalAmount = 47985.00m,
                    PayAmount = 0.00m,
                    Status = "Pending"
                },
                new SalesInvoice
                {
                    ClientName = "INS TAMAL",
                    InvoiceNo = "DEE2627108",
                    InvoiceDate = DateTime.SpecifyKind(DateTime.Parse("2026-05-14"), DateTimeKind.Utc),
                    Amount = 330000.00m,
                    GstAmount = 16500.00m,
                    TotalAmount = 346500.00m,
                    PayAmount = 0.00m,
                    Status = "Pending"
                },
                new SalesInvoice
                {
                    ClientName = "FLEET MAINTENANCE UNIT VISAKHAPATNAM",
                    InvoiceNo = "DEE2627104",
                    InvoiceDate = DateTime.SpecifyKind(DateTime.Parse("2026-04-02"), DateTimeKind.Utc),
                    Amount = 231860.00m,
                    GstAmount = 11593.00m,
                    TotalAmount = 243453.00m,
                    PayAmount = 0.00m,
                    Status = "Pending"
                },
                new SalesInvoice
                {
                    ClientName = "THE ADMIRAL SUPERINTENDANT OF NAVAL DOCKYARD (VISAKHAPATNAM)",
                    InvoiceNo = "DEE2627101",
                    InvoiceDate = DateTime.SpecifyKind(DateTime.Parse("2026-04-01"), DateTimeKind.Utc),
                    Amount = 363808.00m,
                    GstAmount = 18190.40m,
                    TotalAmount = 381998.40m,
                    PayAmount = 0.00m,
                    Status = "Pending"
                },
                new SalesInvoice
                {
                    ClientName = "FLEET MAINTENANCE UNIT VISAKHAPATNAM",
                    InvoiceNo = "DEE2627103",
                    InvoiceDate = DateTime.SpecifyKind(DateTime.Parse("2026-05-01"), DateTimeKind.Utc),
                    Amount = 138214.24m,
                    GstAmount = 6910.71m,
                    TotalAmount = 145124.95m,
                    PayAmount = 0.00m,
                    Status = "Pending"
                },
                new SalesInvoice
                {
                    ClientName = "FLEET MAINTENANCE UNIT VISAKHAPATNAM",
                    InvoiceNo = "DEE2627102",
                    InvoiceDate = DateTime.SpecifyKind(DateTime.Parse("2026-04-02"), DateTimeKind.Utc),
                    Amount = 138214.24m,
                    GstAmount = 6910.71m,
                    TotalAmount = 145124.95m,
                    PayAmount = 0.00m,
                    Status = "Pending"
                },
                new SalesInvoice
                {
                    ClientName = "INS TAMAL",
                    InvoiceNo = "DEE2627107",
                    InvoiceDate = DateTime.SpecifyKind(DateTime.Parse("2026-05-14"), DateTimeKind.Utc),
                    Amount = 120000.00m,
                    GstAmount = 6000.00m,
                    TotalAmount = 126000.00m,
                    PayAmount = 0.00m,
                    Status = "Pending"
                },
                new SalesInvoice
                {
                    ClientName = "INS TAMAL",
                    InvoiceNo = "DEE2627106",
                    InvoiceDate = DateTime.SpecifyKind(DateTime.Parse("2026-05-14"), DateTimeKind.Utc),
                    Amount = 95000.00m,
                    GstAmount = 4750.00m,
                    TotalAmount = 99750.00m,
                    PayAmount = 0.00m,
                    Status = "Pending"
                }
            };

            _context.SalesInvoices.AddRange(invoices);
            await _context.SaveChangesAsync();

            return Ok("Sample sales invoices seeded successfully");
        }

        [HttpPost("users")]
        public async Task<IActionResult> SeedUsers()
        {
            if (_context.Users.Any()) return BadRequest("Users already exist");

            var users = new List<User>
            {
                new User 
                { 
                    Email = "admin@digital.com", 
                    PasswordHash = "Admin@123", 
                    FullName = "System Administrator", 
                    RoleId = 1 
                },
                new User 
                { 
                    Email = "hr@digital.com", 
                    PasswordHash = "HR@123", 
                    FullName = "HR Manager", 
                    RoleId = 4 
                },
                new User 
                { 
                    Email = "it@digital.com", 
                    PasswordHash = "IT@123", 
                    FullName = "IT Lead", 
                    RoleId = 5 
                }
            };

            _context.Users.AddRange(users);
            await _context.SaveChangesAsync();

            return Ok("Sample users seeded successfully");
        }

        [HttpPost("masterdata")]
        public async Task<IActionResult> SeedMasterData()
        {
            if (_context.MasterData.Any()) return BadRequest("Master data already exist");

            var masterData = new List<MasterData>
            {
                new MasterData { Category = "Payment Mode", Value = "GPAY", Description = "GPAY" },
                new MasterData { Category = "Payment Mode", Value = "ONLINE TRANSFER", Description = "ONLINE TRANSFER" },
                new MasterData { Category = "Payment Mode", Value = "CHEQUE PAYMENT", Description = "CHEQUE PAYMENT" },
                new MasterData { Category = "Payment Mode", Value = "CASH PAYMENT", Description = "CASH PAYMENT" },
                new MasterData { Category = "Payment Mode", Value = "PHONEPE", Description = "PHONEPE" },
                
                new MasterData { Category = "State", Value = "ANDHRA PRADESH" },
                new MasterData { Category = "State", Value = "MAHARASHTRA" },
                new MasterData { Category = "State", Value = "TAMIL NADU" },
                
                new MasterData { Category = "Expense", Value = "FUEL" },
                new MasterData { Category = "Expense", Value = "MAINTENANCE" },
                new MasterData { Category = "Expense", Value = "SALARY" },

                new MasterData { Category = "Category", Value = "HARDWARE", Description = "Computer Hardware" },
                new MasterData { Category = "Category", Value = "SOFTWARE", Description = "Software Licenses" },
                new MasterData { Category = "Category", Value = "FURNITURE", Description = "Office Furniture" },

                new MasterData { Category = "Brand", Value = "DELL", Description = "Dell Computers" },
                new MasterData { Category = "Brand", Value = "HP", Description = "HP Laptops" },
                new MasterData { Category = "Brand", Value = "LOGITECH", Description = "Logitech Accessories" },

                new MasterData { Category = "Sub Category", Value = "LAPTOPS", Description = "Portable Computers" },
                new MasterData { Category = "Sub Category", Value = "MONITORS", Description = "Computer Displays" },

                new MasterData { Category = "Post", Value = "DEVELOPER", Description = "Software Developer" },
                new MasterData { Category = "Post", Value = "MANAGER", Description = "Project Manager" },
                new MasterData { Category = "Post", Value = "ACCOUNTANT", Description = "Finance Team" },

                new MasterData { Category = "Location", Value = "OFFICE A", Description = "Main Office" },
                new MasterData { Category = "Location", Value = "WAREHOUSE", Description = "Primary Storage" }
            };

            _context.MasterData.AddRange(masterData);
            await _context.SaveChangesAsync();

            return Ok("Sample master data seeded successfully");
        }
    }
}
