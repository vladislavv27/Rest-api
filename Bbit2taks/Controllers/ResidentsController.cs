using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bbit2taks.Data;
using Bbit2taks.Model;
using Bbit2taks.Services;
using Microsoft.AspNetCore.Authorization;
using Bbit2taks.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Bbit2taks.Controllers
{
    [Route("api/residents")]
    [ApiController]
    public class ResidentsController : ControllerBase
    {
        private readonly ResidentService _residentService;
        private readonly IHttpContextAccessor _httpContextAccessor; // Add this field

        public ResidentsController(ResidentService residentService, IHttpContextAccessor httpContextAccessor)
        {
            _residentService = residentService;
            _httpContextAccessor = httpContextAccessor;
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
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""));
            var datafromtoken = token.Payload.Values.ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (datafromtoken[18].ToString() == "Manager")
            {
                resident.Id = 0;
                await _residentService.CreateResident(resident);

            }

            return CreatedAtAction(nameof(GetResidentById), new { id = resident.Id }, resident);
        }

        // PUT api/residents/{id}
        [HttpPut("{id}")]

        public async Task<IActionResult> PutResident(int id, Resident resident)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""));
            var datafromtoken = token.Payload.Values.ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (datafromtoken[18].ToString() == "Manager" || int.Parse(datafromtoken[17].ToString()) == id && datafromtoken[18].ToString() == "Resident")
            {
                await _residentService.UpdateResident(id, resident);

            }

            return NoContent();
        }





        // DELETE api/residents/{id}
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteResident(int id)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""));
            var datafromtoken = token.Payload.Values.ToList();
            if (datafromtoken[18].ToString() == "Manager" || int.Parse(datafromtoken[17].ToString()) == id && datafromtoken[18].ToString() == "Resident")
            {
                await _residentService.DeleteResident(id);

            }

            return Ok();
        }
    }
}
