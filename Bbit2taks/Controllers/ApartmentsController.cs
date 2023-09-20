using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bbit2taks.Data;
using Bbit2taks.Model;
using Bbit2taks.Services;
using Microsoft.AspNetCore.Authorization;

namespace Bbit2taks.Controllers
{
    [Route("api/apartments")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly ApartmentService _apartmentService;

        public ApartmentsController(ApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        // GET api/apartments
        [HttpGet]


        public async Task<ActionResult<IEnumerable<Apartment>>> GetApartments()
        {
            var apartments = await _apartmentService.GetApartments();
            return Ok(apartments);
        }

        // GET api/apartments/{id}
        [HttpGet("{id}")]


        public async Task<ActionResult<Apartment>> GetApartmentById(int id)
        {
            var apartment = await _apartmentService.GetApartmentById(id);

            if (apartment == null)
            {
                return NotFound();
            }

            return Ok(apartment);
        }

        // POST api/apartments
        [HttpPost]
        [Authorize(Roles = "Manager")]

        public async Task<IActionResult> PostApartment(Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _apartmentService.CreateApartment(apartment);

            return CreatedAtAction(nameof(GetApartmentById), new { id = apartment.Id }, apartment);
        }

        // PUT api/apartments/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]

        public async Task<IActionResult> PutApartment(int id, Apartment updatedApartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _apartmentService.UpdateApartment(id, updatedApartment);

            return NoContent();
        }

        // DELETE api/apartments/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]

        public async Task<IActionResult> DeleteApartment(int id)
        {
            await _apartmentService.DeleteApartment(id);

            return Ok();
        }
        // GET api/apartments/{id}/residents
        [HttpGet("{apartmentId}/residents")]

        public async Task<ActionResult<List<Resident>>> GetApartmentsResident(int apartmentId)
        {
            var residents = await _apartmentService.GetApartmentsResident(apartmentId);
            return Ok(residents);
        }
    }
}
