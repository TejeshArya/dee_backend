using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProjectsController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        // GET: api/Projects/PRJ-2024-01
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(string id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject([FromForm] ProjectUploadRequest request)
        {
            var project = new Project
            {
                ProjectId = request.ProjectId,
                Name = request.Name,
                Wing = request.Wing ?? "",
                Department = request.Department ?? "",
                Location = request.Location ?? "",
                Post = request.Post ?? "",
                CreatedBy = request.CreatedBy ?? "System",
                Client = request.Client,
                Gst = request.Gst ?? "",
                Value = request.Value ?? "0",
                StartDate = request.StartDate?.ToUniversalTime(),
                EndDate = request.EndDate?.ToUniversalTime(),
                Status = request.Status ?? "Planning",
                Priority = request.Priority ?? "Medium",
                Description = request.Description ?? ""
            };

            if (request.File != null && request.File.Length > 0)
            {
                string uploadsFolder = Path.Combine(_environment.ContentRootPath, "wwwroot", "uploads", "projects");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.File.CopyToAsync(fileStream);
                }

                project.FilePath = "/uploads/projects/" + uniqueFileName;
            }

            _context.Projects.Add(project);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectExists(project.ProjectId)) return Conflict(new { message = "Project ID already exists" });
                throw;
            }

            return CreatedAtAction("GetProject", new { id = project.ProjectId }, project);
        }

        public class ProjectUploadRequest
        {
            public string ProjectId { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string? Wing { get; set; }
            public string? Department { get; set; }
            public string? Location { get; set; }
            public string? Post { get; set; }
            public string? CreatedBy { get; set; }
            public string Client { get; set; } = string.Empty;
            public string? Gst { get; set; }
            public string? Value { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Status { get; set; }
            public string? Priority { get; set; }
            public string? Description { get; set; }
            public IFormFile? File { get; set; }
        }

        // PUT: api/Projects/PRJ-2024-01
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(string id, Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // DELETE: api/Projects/PRJ-2024-01
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(string id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
    }
}
