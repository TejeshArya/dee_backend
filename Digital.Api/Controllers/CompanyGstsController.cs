using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyGstsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompanyGstsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyGsts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyGst>>> GetCompanyGsts()
        {
            return await _context.CompanyGsts.ToListAsync();
        }

        // GET: api/CompanyGsts/33ANVES1111A1Z1
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyGst>> GetCompanyGst(string id)
        {
            var companyGst = await _context.CompanyGsts.FindAsync(id);

            if (companyGst == null)
            {
                return NotFound();
            }

            return companyGst;
        }

        private async Task<string> SaveFileAsync(IFormFile? file, string folder)
        {
            if (file == null) return string.Empty;
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", folder);
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploads, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"/uploads/{folder}/{fileName}";
        }

        // POST: api/CompanyGsts
        [HttpPost]
        public async Task<ActionResult<CompanyGst>> PostCompanyGst([FromForm] CompanyGstForm form)
        {
            var companyGst = System.Text.Json.JsonSerializer.Deserialize<CompanyGst>(form.Data, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (companyGst == null) return BadRequest("Invalid data");

            if (companyGst.CompanyEstablished.HasValue)
            {
                companyGst.CompanyEstablished = DateTime.SpecifyKind(companyGst.CompanyEstablished.Value, DateTimeKind.Utc);
            }

            var logoPath = await SaveFileAsync(form.Logo, "company");
            if (!string.IsNullOrEmpty(logoPath)) companyGst.LogoPath = logoPath;
            
            var headerPath = await SaveFileAsync(form.Header, "company");
            if (!string.IsNullOrEmpty(headerPath)) companyGst.HeaderPath = headerPath;

            var footerPath = await SaveFileAsync(form.Footer, "company");
            if (!string.IsNullOrEmpty(footerPath)) companyGst.FooterPath = footerPath;

            _context.CompanyGsts.Add(companyGst);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompanyGstExists(companyGst.GstNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompanyGst", new { id = companyGst.GstNumber }, companyGst);
        }

        // PUT: api/CompanyGsts/33ANVES1111A1Z1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyGst(string id, [FromForm] CompanyGstForm form)
        {
            var companyGst = System.Text.Json.JsonSerializer.Deserialize<CompanyGst>(form.Data, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (companyGst == null || id != companyGst.GstNumber)
            {
                return BadRequest();
            }

            if (companyGst.CompanyEstablished.HasValue)
            {
                companyGst.CompanyEstablished = DateTime.SpecifyKind(companyGst.CompanyEstablished.Value, DateTimeKind.Utc);
            }

            var logoPath = await SaveFileAsync(form.Logo, "company");
            if (!string.IsNullOrEmpty(logoPath)) companyGst.LogoPath = logoPath;
            
            var headerPath = await SaveFileAsync(form.Header, "company");
            if (!string.IsNullOrEmpty(headerPath)) companyGst.HeaderPath = headerPath;

            var footerPath = await SaveFileAsync(form.Footer, "company");
            if (!string.IsNullOrEmpty(footerPath)) companyGst.FooterPath = footerPath;

            // In EF Core, if we receive an object via FromForm, we might need to query the existing entity and map properties,
            // or just attach it. Since we allow partial updates on files, let's pull existing to not overwrite unchanged files.
            var existingCompany = await _context.CompanyGsts.FindAsync(id);
            if (existingCompany == null) return NotFound();

            // Copy all properties
            _context.Entry(existingCompany).CurrentValues.SetValues(companyGst);

            // Retain old paths if new files weren't provided
            if (string.IsNullOrEmpty(logoPath)) existingCompany.LogoPath = companyGst.LogoPath ?? existingCompany.LogoPath;
            if (string.IsNullOrEmpty(headerPath)) existingCompany.HeaderPath = companyGst.HeaderPath ?? existingCompany.HeaderPath;
            if (string.IsNullOrEmpty(footerPath)) existingCompany.FooterPath = companyGst.FooterPath ?? existingCompany.FooterPath;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyGstExists(id))
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

        // DELETE: api/CompanyGsts/33ANVES1111A1Z1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyGst(string id)
        {
            var companyGst = await _context.CompanyGsts.FindAsync(id);
            if (companyGst == null)
            {
                return NotFound();
            }

            _context.CompanyGsts.Remove(companyGst);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyGstExists(string id)
        {
            return _context.CompanyGsts.Any(e => e.GstNumber == id);
        }
    }

    public class CompanyGstForm
    {
        public string Data { get; set; } = string.Empty;
        public IFormFile? Logo { get; set; }
        public IFormFile? Header { get; set; }
        public IFormFile? Footer { get; set; }
    }
}
