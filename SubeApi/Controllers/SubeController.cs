using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubeApi.DataAccess;
using SubeApi.Models;

namespace SubeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubeController : ControllerBase
    {
        private readonly SubeDbContext _context;

        public SubeController(SubeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sube>>> GetSubes()
        {
            var sube = await _context.Sube.ToListAsync();
            return Ok(sube);
        }

        [HttpPost]
        public async Task<ActionResult<Sube>> CreateSube(Sube sube)
        {          
                _context.Sube.Add(sube);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetSubes), new { id = sube.Id }, sube);
        }
    }
}
    