using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var totalEmployees = await _context.Employees.CountAsync();
            var totalProjects = await _context.Projects.CountAsync();
            
            // For now, we'll mock revenue and pending since we haven't built those tables yet
            var revenue = 428500; 
            var pending = 18;

            return Ok(new
            {
                totalEmployees,
                totalProjects,
                revenue,
                pending
            });
        }
    }
}
