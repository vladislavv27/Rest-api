﻿using System;
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
    [Route("api/houses")]
    public class HousesController : ControllerBase
    {
        private readonly HouseContext _context;

        public HousesController(HouseContext context)
        {
            _context = context;
        }

        // GET: api/Houses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
            if (_context.Houses == null)
            {
                return NotFound();
            }
            return await _context.Houses.ToListAsync();
        }

        // GET: api/houses/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouse(int id)
        {
            if (_context.Houses == null)
            {
                return NotFound();
            }
            var house = await _context.Houses.FindAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            return Ok(house);
        }

        // PUT: api/houses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(int id, House house)
        {
            if (id != house.Id)
            {
                return BadRequest();
            }

            _context.Entry(house).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(id))
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

        // POST: api/houses{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<House>> PostHouse(House house)
        {
            if (_context.Houses == null)
            {
                return Problem("Entity set 'HouseContext.Houses'  is null.");
            }
            _context.Houses.Add(house);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHouse", new { id = house.Id }, house);
        }

        // DELETE: api/houses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            if (_context.Houses == null)
            {
                return NotFound();
            }
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HouseExists(int id)
        {
            return (_context.Houses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
