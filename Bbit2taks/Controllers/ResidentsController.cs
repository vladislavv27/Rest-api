using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bbit2taks.Data;
using Bbit2taks.Model;

namespace Bbit2taks.Controllers
{
    [Route("api/residents")]
    [ApiController]
    public class ResidentsController : ControllerBase
    {
        private readonly HouseContext _context;

        public ResidentsController(HouseContext context)
        {
            _context = context;
        }

        // GET: api/residents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resident>>> GetResidents()
        {
          if (_context.Residents == null)
          {
              return NotFound();
          }
            return await _context.Residents.ToListAsync();
        }

        // GET: api/residents/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Resident>> GetResident(int id)
        {
          if (_context.Residents == null)
          {
              return NotFound();
          }
            var resident = await _context.Residents.FindAsync(id);

            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident);
        }

        // PUT: api/residents/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResident(int id, Resident resident)
        {
            if (id != resident.Id)
            {
                return BadRequest();
            }

            _context.Entry(resident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentExists(id))
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

        // POST: api/residents
        [HttpPost]
        public async Task<ActionResult<Resident>> PostResident(Resident resident)
        {
          if (_context.Residents == null)
          {
              return Problem("Entity set 'HouseContext.Residents'  is null.");
          }
            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResident", new { id = resident.Id }, resident);
        }

        // DELETE: api/residents/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResident(int id)
        {
            if (_context.Residents == null)
            {
                return NotFound();
            }
            var resident = await _context.Residents.FindAsync(id);
            if (resident == null)
            {
                return NotFound();
            }

            _context.Residents.Remove(resident);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResidentExists(int id)
        {
            return (_context.Residents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
