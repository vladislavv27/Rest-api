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
    [Route("api/apartments")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly HouseContext _context;

        public ApartmentsController(HouseContext context)
        {
            _context = context;
        }

        // GET: api/apartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartment>>> GetApartments()
        {
            if (_context.Apartments == null)
            {
                return NotFound();
            }
            return await _context.Apartments.ToListAsync();
        }

        // GET: api/apartments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartment>> GetApartment(int id)
        {
            if (_context.Apartments == null)
            {
                return NotFound();
            }
            var apartment = await _context.Apartments.FindAsync(id);

            if (apartment == null)
            {
                return NotFound();
            }

            return Ok(apartment);
        }

        // PUT: api/apartments/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartment(int id, Apartment apartment)
        {
            if (id != apartment.Id)
            {
                return BadRequest();
            }

            _context.Entry(apartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentExists(id))
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

        // POST: api/apartments{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Apartment>> PostApartment(Apartment apartment)
        {
            if (_context.Apartments == null)
            {
                return Problem("Entity set 'HouseContext.Apartments'  is null.");
            }
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApartment", new { id = apartment.Id }, apartment);
        }

        // DELETE: api/apartments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            if (_context.Apartments == null)
            {
                return NotFound();
            }
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }

            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApartmentExists(int id)
        {
            return (_context.Apartments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
