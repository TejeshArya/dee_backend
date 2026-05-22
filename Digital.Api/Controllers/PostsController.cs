using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.OrderByDescending(p => p.Id).ToListAsync();
        }

        // GET: api/posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();
            return post;
        }

        // POST: api/posts
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            post.Date = DateTime.UtcNow;
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        // POST: api/posts/edit
        [HttpPost("edit")]
        public async Task<IActionResult> EditPost(Post post)
        {
            var existing = await _context.Posts.FindAsync(post.Id);
            if (existing == null) return NotFound();

            // Retain original date if not provided
            if (post.Date == default)
            {
                post.Date = existing.Date;
            }

            _context.Entry(existing).CurrentValues.SetValues(post);
            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        // DELETE: api/posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
