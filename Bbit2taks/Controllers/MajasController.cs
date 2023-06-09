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
    public class MajasController : ControllerBase
    {
        private readonly MajaContext _context;

        public MajasController(MajaContext context)
        {
            _context = context;
        }

        // GET: api/Majas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maja>>> GetMajas()
        {
            if (_context.Majas == null)
            {
                return NotFound();
            }
            return await _context.Majas.ToListAsync();
        }

        // GET: api/Majas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maja>> GetMaja(long id)
        {
            if (_context.Majas == null)
            {
                return NotFound();
            }
            var maja = await _context.Majas.FindAsync(id);

            if (maja == null)
            {
                return NotFound();
            }

            return maja;
        }

        // PUT: api/Majas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaja(long id, Maja maja)
        {
            if (id != maja.Id)
            {
                return BadRequest();
            }

            _context.Entry(maja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajaExists(id))
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

        // POST: api/Majas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Maja>> PostMaja(Maja maja)
        {
            if (_context.Majas == null)
            {
                return Problem("Entity set 'MajaContext.Majas'  is null.");
            }
            _context.Majas.Add(maja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaja", new { id = maja.Id }, maja);
        }

        // DELETE: api/Majas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaja(long id)
        {
            if (_context.Majas == null)
            {
                return NotFound();
            }
            var maja = await _context.Majas.FindAsync(id);
            if (maja == null)
            {
                return NotFound();
            }

            _context.Majas.Remove(maja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MajaExists(long id)
        {
            return (_context.Majas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
