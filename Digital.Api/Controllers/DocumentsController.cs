using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;
using System.IO;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public DocumentsController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: api/Documents/employee/user@example.com
        [HttpGet("employee/{email}")]
        public async Task<ActionResult<IEnumerable<Document>>> GetEmployeeDocuments(string email)
        {
            return await _context.Documents
                .Where(d => d.EmployeeEmail == email)
                .OrderByDescending(d => d.UploadedAt)
                .ToListAsync();
        }

        // POST: api/Documents/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadDocument([FromForm] DocumentUploadRequest request)
        {
            if (request.File == null || request.File.Length == 0)
                return BadRequest("No file uploaded.");

            try
            {
                // Ensure upload directory exists
                string uploadsFolder = Path.Combine(_environment.ContentRootPath, "wwwroot", "uploads", "documents");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate unique filename
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save file to disk
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.File.CopyToAsync(fileStream);
                }

                // Save metadata to database
                var document = new Document
                {
                    EmployeeEmail = request.EmployeeEmail,
                    Category = request.Category,
                    SubCategory = request.SubCategory ?? "",
                    SubSubCategory = request.SubSubCategory ?? "",
                    DocumentName = request.DocumentName,
                    FilePath = "/uploads/documents/" + uniqueFileName, // Relative URL
                    FileType = Path.GetExtension(request.File.FileName),
                    FileSize = request.File.Length,
                    Remarks = request.Remarks ?? "",
                    UploadedAt = DateTime.UtcNow
                };

                _context.Documents.Add(document);
                await _context.SaveChangesAsync();

                return Ok(document);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null) return NotFound();

            // Delete physical file
            string fullPath = Path.Combine(_environment.ContentRootPath, "wwwroot", document.FilePath.TrimStart('/'));
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class DocumentUploadRequest
    {
        public IFormFile File { get; set; } = null!;
        public string EmployeeEmail { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string SubCategory { get; set; } = string.Empty;
        public string SubSubCategory { get; set; } = string.Empty;
        public string DocumentName { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
