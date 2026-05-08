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

        // POST: api/CompanyGsts
        [HttpPost]
        public async Task<ActionResult<CompanyGst>> PostCompanyGst(CompanyGst companyGst)
        {
            if (companyGst.CompanyEstablished.HasValue)
            {
                companyGst.CompanyEstablished = DateTime.SpecifyKind(companyGst.CompanyEstablished.Value, DateTimeKind.Utc);
            }

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
        public async Task<IActionResult> PutCompanyGst(string id, CompanyGst companyGst)
        {
            if (id != companyGst.GstNumber)
            {
                return BadRequest();
            }

            if (companyGst.CompanyEstablished.HasValue)
            {
                companyGst.CompanyEstablished = DateTime.SpecifyKind(companyGst.CompanyEstablished.Value, DateTimeKind.Utc);
            }

            _context.Entry(companyGst).State = EntityState.Modified;

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
}
