﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bbit2taks.Data;
using Bbit2taks.Model;
using Bbit2taks.Services;

namespace Bbit2taks.Controllers
{
    [Route("api/residents")]
    [ApiController]
    public class ResidentsController : ControllerBase
    {
        private readonly ResidentService _residentService;

        public ResidentsController(ResidentService residentService)
        {
            _residentService = residentService;
        }

        // GET api/residents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resident>>> GetResidents()
        {
            var residents = await _residentService.GetResidents();
            return Ok(residents);
        }

        // GET api/residents/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Resident>> GetResidentById(int id)
        {
            var resident = await _residentService.GetResidentById(id);

            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident);
        }

        // POST api/residents
        [HttpPost]
        public async Task<IActionResult> PostResident(Resident resident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _residentService.CreateResident(resident);

            return CreatedAtAction(nameof(GetResidentById), new { id = resident.Id }, resident);
        }

        // PUT api/residents/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResident(int id, Resident updatedResident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _residentService.UpdateResident(id, updatedResident);

            return NoContent();
        }

        // DELETE api/residents/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResident(int id)
        {
            await _residentService.DeleteResident(id);

            return Ok();
        }
    }
}
