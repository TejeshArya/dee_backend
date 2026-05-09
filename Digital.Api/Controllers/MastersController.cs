using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HsnCodesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public HsnCodesController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HsnCode>>> GetHsnCodes()
        {
            return await _context.HsnCodes.ToListAsync();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class DenominationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DenominationsController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Denomination>>> GetDenominations()
        {
            return await _context.Denominations.ToListAsync();
        }
    }
}
