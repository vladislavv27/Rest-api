using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bbit2taks.Model;
using Bbit2taks.Models;

namespace Bbit2taks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DzivoklisController : ControllerBase
    {
        private readonly MajaContext _context;

        public DzivoklisController(MajaContext context)
        {
            _context = context;
        }

        // GET: api/Dzivoklis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dzivoklis>>> GetDzivoklis()
        {
            if (_context.Dzivoklis == null)
            {
                return NotFound();
            }
            return await _context.Dzivoklis.ToListAsync();
        }

        // GET: api/Dzivoklis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dzivoklis>> GetDzivoklis(long id)
        {
            if (_context.Dzivoklis == null)
            {
                return NotFound();
            }
            var dzivoklis = await _context.Dzivoklis.FindAsync(id);

            if (dzivoklis == null)
            {
                return NotFound();
            }

            return dzivoklis;
        }

        // PUT: api/Dzivoklis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDzivoklis(long id, Dzivoklis dzivoklis)
        {
            if (id != dzivoklis.Id)
            {
                return BadRequest();
            }

            _context.Entry(dzivoklis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DzivoklisExists(id))
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

        // POST: api/Dzivoklis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dzivoklis>> PostDzivoklis(Dzivoklis dzivoklis)
        {
            if (_context.Dzivoklis == null)
            {
                return Problem("Entity set 'MajaContext.Dzivoklis'  is null.");
            }
            _context.Dzivoklis.Add(dzivoklis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDzivoklis", new { id = dzivoklis.Id }, dzivoklis);
        }

        // DELETE: api/Dzivoklis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDzivoklis(long id)
        {
            if (_context.Dzivoklis == null)
            {
                return NotFound();
            }
            var dzivoklis = await _context.Dzivoklis.FindAsync(id);
            if (dzivoklis == null)
            {
                return NotFound();
            }

            _context.Dzivoklis.Remove(dzivoklis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DzivoklisExists(long id)
        {
            return (_context.Dzivoklis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
