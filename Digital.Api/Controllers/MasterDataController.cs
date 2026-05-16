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
        public async Task<ActionResult<MasterData>> PostMasterData([FromForm] string data, [FromForm] IFormFile? file)
        {
            var masterData = System.Text.Json.JsonSerializer.Deserialize<MasterData>(data, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (masterData == null) return BadRequest("Invalid data");

            if (file != null)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "masters");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(uploads, fileName);
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                masterData.PhotoPath = $"/uploads/masters/{fileName}";
            }

            _context.MasterData.Add(masterData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllMasterData", new { id = masterData.Id }, masterData);
        }

        // PUT: api/MasterData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasterData(int id, [FromForm] string data, [FromForm] IFormFile? file)
        {
            var updatedData = System.Text.Json.JsonSerializer.Deserialize<MasterData>(data, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (updatedData == null || id != updatedData.Id) return BadRequest();

            var masterData = await _context.MasterData.FindAsync(id);
            if (masterData == null) return NotFound();

            masterData.Value = updatedData.Value;
            masterData.Description = updatedData.Description;
            
            if (file != null)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "masters");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(uploads, fileName);
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
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
    }
}
