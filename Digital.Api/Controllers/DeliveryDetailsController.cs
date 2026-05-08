using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeliveryDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryDetail>>> GetDeliveryDetails()
        {
            return await _context.DeliveryDetails.OrderByDescending(d => d.CreatedAt).ToListAsync();
        }

        // POST: api/DeliveryDetails
        [HttpPost]
        public async Task<ActionResult<DeliveryDetail>> PostDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            _context.DeliveryDetails.Add(deliveryDetail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDeliveryDetails), new { id = deliveryDetail.Id }, deliveryDetail);
        }

        // POST: api/DeliveryDetails/edit
        [HttpPost("edit")]
        public async Task<IActionResult> EditDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            var existing = await _context.DeliveryDetails.FindAsync(deliveryDetail.Id);
            if (existing == null) return NotFound();

            _context.Entry(existing).CurrentValues.SetValues(deliveryDetail);
            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        // DELETE: api/DeliveryDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryDetail(int id)
        {
            var deliveryDetail = await _context.DeliveryDetails.FindAsync(id);
            if (deliveryDetail == null) return NotFound();

            _context.DeliveryDetails.Remove(deliveryDetail);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
