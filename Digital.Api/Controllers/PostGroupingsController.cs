using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostGroupingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostGroupingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PostGroupings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostGrouping>>> GetPostGroupings()
        {
            return await _context.PostGroupings
                .Include(pg => pg.PostGroupingItems)
                    .ThenInclude(p => p.Post)
                .OrderByDescending(pg => pg.CreatedAt)
                .ToListAsync();
        }

        // POST: api/PostGroupings
        [HttpPost]
        public async Task<ActionResult<PostGrouping>> PostPostGrouping(PostGroupingInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Name))
            {
                return BadRequest("Grouping Name is required.");
            }

            if (input.PostIds == null || input.PostIds.Distinct().Count() < 2)
            {
                return BadRequest("At least 2 unique posts must be selected for grouping.");
            }

            // Verify all selected posts exist
            var uniquePostIds = input.PostIds.Distinct().ToList();
            var existingPostsCount = await _context.Posts.CountAsync(p => uniquePostIds.Contains(p.Id));
            if (existingPostsCount != uniquePostIds.Count)
            {
                return BadRequest("One or more selected posts do not exist.");
            }

            // Create new grouping
            var grouping = new PostGrouping
            {
                Name = input.Name.Trim(),
                Description = input.Description?.Trim() ?? string.Empty,
                CreatedAt = DateTime.UtcNow
            };

            _context.PostGroupings.Add(grouping);
            await _context.SaveChangesAsync();

            // Create junction items
            foreach (var postId in uniquePostIds)
            {
                var item = new PostGroupingItem
                {
                    PostGroupingId = grouping.Id,
                    PostId = postId
                };
                _context.PostGroupingItems.Add(item);
            }
            await _context.SaveChangesAsync();

            // Load full relationships for returning
            var fullyLoaded = await _context.PostGroupings
                .Include(pg => pg.PostGroupingItems)
                    .ThenInclude(p => p.Post)
                .FirstOrDefaultAsync(pg => pg.Id == grouping.Id);

            return CreatedAtAction(nameof(GetPostGroupings), new { id = grouping.Id }, fullyLoaded);
        }

        // DELETE: api/PostGroupings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostGrouping(int id)
        {
            var grouping = await _context.PostGroupings.FindAsync(id);
            if (grouping == null)
            {
                return NotFound();
            }

            _context.PostGroupings.Remove(grouping);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class PostGroupingInput
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<int> PostIds { get; set; } = new List<int>();
    }
}
