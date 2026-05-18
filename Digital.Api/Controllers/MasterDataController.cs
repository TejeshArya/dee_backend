using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MasterDataController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MasterData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterData>>> GetAllMasterData()
        {
            return await _context.MasterData.OrderBy(m => m.Category).ThenBy(m => m.Value).ToListAsync();
        }

        // GET: api/MasterData/category/Payment Mode
        [HttpGet("category/{categoryName}")]
        public async Task<ActionResult<IEnumerable<MasterData>>> GetByCategory(string categoryName)
        {
            return await _context.MasterData
                .Where(m => m.Category.ToLower() == categoryName.ToLower())
                .OrderBy(m => m.Value)
                .ToListAsync();
        }

        // POST: api/MasterData
        [HttpPost]
        public async Task<ActionResult<MasterData>> PostMasterData([FromForm] MasterDataForm form)
        {
            var masterData = System.Text.Json.JsonSerializer.Deserialize<MasterData>(form.Data, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (masterData == null) return BadRequest("Invalid data");

            if (masterData.Category == "State")
            {
                if (await _context.MasterData.AnyAsync(m => m.Category == "State" && m.ShortName == masterData.ShortName))
                {
                    return BadRequest("State code already exists. Duplicates are not allowed.");
                }
                masterData.GstStateCode = $"{masterData.ShortName} - {masterData.Value}";
            }

            if (form.File != null)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "masters");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(form.File.FileName)}";
                var filePath = Path.Combine(uploads, fileName);
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await form.File.CopyToAsync(stream);
                }
                masterData.PhotoPath = $"/uploads/masters/{fileName}";
            }

            _context.MasterData.Add(masterData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllMasterData", new { id = masterData.Id }, masterData);
        }

        // PUT: api/MasterData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasterData(int id, [FromForm] MasterDataForm form)
        {
            var updatedData = System.Text.Json.JsonSerializer.Deserialize<MasterData>(form.Data, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (updatedData == null || id != updatedData.Id) return BadRequest();

            var masterData = await _context.MasterData.FindAsync(id);
            if (masterData == null) return NotFound();

            if (masterData.Category == "State")
            {
                if (await _context.MasterData.AnyAsync(m => m.Category == "State" && m.ShortName == updatedData.ShortName && m.Id != id))
                {
                    return BadRequest("State code already exists. Duplicates are not allowed.");
                }
                masterData.GstStateCode = $"{updatedData.ShortName} - {updatedData.Value}";
            }

            masterData.Value = updatedData.Value;
            masterData.Description = updatedData.Description;
            masterData.ShortName = updatedData.ShortName;
            masterData.Location = updatedData.Location;
            masterData.ParentId = updatedData.ParentId;
            
            if (form.File != null)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "masters");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(form.File.FileName)}";
                var filePath = Path.Combine(uploads, fileName);
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await form.File.CopyToAsync(stream);
                }
                masterData.PhotoPath = $"/uploads/masters/{fileName}";
            }

            _context.Entry(masterData).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/MasterData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasterData(int id)
        {
            var masterData = await _context.MasterData.FindAsync(id);
            if (masterData == null)
            {
                return NotFound();
            }

            _context.MasterData.Remove(masterData);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool CompanyGstExists(string id)
        {
            return _context.CompanyGsts.Any(e => e.GstNumber == id);
        }
    }

    public class MasterDataForm
    {
        public string Data { get; set; } = string.Empty;
        public IFormFile? File { get; set; }
    }
}
