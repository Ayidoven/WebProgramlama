using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Programlama.Data;
using Web_Programlama.Models;

namespace Web_Programlama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandevuApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RandevuApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RandevuApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Randevu>>> GetRandevular()
        {
            return await _context.Randevu
                                 .Include(r => r.Çalışan)
                                 .Include(r => r.Hizmet)
                                 .ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Randevu>> GetRandevu(int id)
        {
            var randevu = await _context.Randevu
                                        .Include(r => r.Çalışan)
                                        .Include(r => r.Hizmet)
                                        .FirstOrDefaultAsync(r => r.Randevuid == id);

            if (randevu == null)
            {
                return NotFound();
            }

            return randevu;
        }

        // POST: api/RandevuApi
        [HttpPost]
        public async Task<ActionResult<Randevu>> PostRandevu(Randevu randevu)
        {
            _context.Randevu.Add(randevu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRandevu", new { id = randevu.Randevuid }, randevu);
        }

        // PUT: api/RandevuApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRandevu(int id, Randevu randevu)
        {
            if (id != randevu.Randevuid)
            {
                return BadRequest();
            }

            _context.Entry(randevu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Randevu.Any(e => e.Randevuid == id))
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

        // DELETE: api/RandevuApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRandevu(int id)
        {
            var randevu = await _context.Randevu.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }

            _context.Randevu.Remove(randevu);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
