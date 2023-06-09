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
    public class IedzivotajsController : ControllerBase
    {
        private readonly MajaContext _context;

        public IedzivotajsController(MajaContext context)
        {
            _context = context;
        }

        // GET: api/Iedzivotajs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Iedzivotajs>>> GetIedzivotajs()
        {
            if (_context.Iedzivotajs == null)
            {
                return NotFound();
            }
            return await _context.Iedzivotajs.ToListAsync();
        }

        // GET: api/Iedzivotajs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Iedzivotajs>> GetIedzivotajs(long id)
        {
            if (_context.Iedzivotajs == null)
            {
                return NotFound();
            }
            var iedzivotajs = await _context.Iedzivotajs.FindAsync(id);

            if (iedzivotajs == null)
            {
                return NotFound();
            }

            return iedzivotajs;
        }

        // PUT: api/Iedzivotajs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIedzivotajs(long id, Iedzivotajs iedzivotajs)
        {
            if (id != iedzivotajs.Id)
            {
                return BadRequest();
            }

            _context.Entry(iedzivotajs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IedzivotajsExists(id))
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

        // POST: api/Iedzivotajs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Iedzivotajs>> PostIedzivotajs(Iedzivotajs iedzivotajs)
        {
            if (_context.Iedzivotajs == null)
            {
                return Problem("Entity set 'MajaContext.Iedzivotajs'  is null.");
            }
            _context.Iedzivotajs.Add(iedzivotajs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIedzivotajs", new { id = iedzivotajs.Id }, iedzivotajs);
        }

        // DELETE: api/Iedzivotajs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIedzivotajs(long id)
        {
            if (_context.Iedzivotajs == null)
            {
                return NotFound();
            }
            var iedzivotajs = await _context.Iedzivotajs.FindAsync(id);
            if (iedzivotajs == null)
            {
                return NotFound();
            }

            _context.Iedzivotajs.Remove(iedzivotajs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IedzivotajsExists(long id)
        {
            return (_context.Iedzivotajs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
