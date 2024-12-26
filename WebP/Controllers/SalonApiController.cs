using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebP.Data;
using WebP.Models;

namespace WebP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalonApiController(AppDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salon>>> GetSalonlar()
        {
            return await _context.Salon.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Salon>> GetSalon(int id)
        {
            var salon = await _context.Salon.FindAsync(id);

            if (salon == null)
            {
                return NotFound();
            }

            return salon;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalon(int id, Salon salon)
        {
            if (id != salon.salonid)
            {
                return BadRequest();
            }

            _context.Entry(salon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalonExists(id))
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

        // POST: api/SalonApi
        [HttpPost]
        public async Task<ActionResult<Salon>> PostSalon(Salon salon)
        {
            _context.Salon.Add(salon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalon", new { id = salon.salonid }, salon);
        }

        // DELETE: api/SalonApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalon(int id)
        {
            var salon = await _context.Salon.FindAsync(id);
            if (salon == null)
            {
                return NotFound();
            }

            _context.Salon.Remove(salon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalonExists(int id)
        {
            return _context.Salon.Any(e => e.salonid == id);
        }
    }
}
