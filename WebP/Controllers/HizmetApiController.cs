using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Programlama.Data;
using Web_Programlama.Models;


namespace Web_Programlama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HizmetApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HizmetApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HizmetApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hizmet>>> GetHizmetler()
        {
            return await _context.Hizmet.ToListAsync();
        }

        // GET: api/HizmetApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hizmet>> GetHizmet(int id)
        {
            var hizmet = await _context.Hizmet.FindAsync(id);

            if (hizmet == null)
            {
                return NotFound();
            }

            return hizmet;
        }

        
        [HttpPost]
        public async Task<ActionResult<Hizmet>> PostHizmet(Hizmet hizmet)
        {
            _context.Hizmet.Add(hizmet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHizmet", new { id = hizmet.Hizmetid }, hizmet);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHizmet(int id, Hizmet hizmet)
        {
            if (id != hizmet.Hizmetid)
            {
                return BadRequest();
            }

            _context.Entry(hizmet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Hizmet.Any(e => e.Hizmetid == id))
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

        // DELETE: api/HizmetApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHizmet(int id)
        {
            var hizmet = await _context.Hizmet.FindAsync(id);
            if (hizmet == null)
            {
                return NotFound();
            }

            _context.Hizmet.Remove(hizmet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
