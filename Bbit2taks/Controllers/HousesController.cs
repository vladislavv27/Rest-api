using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bbit2taks.Model;
using Bbit2taks.Services;
using Microsoft.EntityFrameworkCore.Internal;


namespace Bbit2taks.Controllers
{
    [Route("api/houses")]
    public class HousesController : ControllerBase
    {
        private HouseService _houseService;

        public HousesController(HouseService houseService)
        {
            _houseService = houseService;
        }

        // GET api/houses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
            var houses=await _houseService.GetHouses();
            return Ok(houses);
        }

        // GET api/houses/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouseById(int id)
        {
            var house = await _houseService.GetHouseById(id);

            if (house == null)
            {
                return NotFound();
            }

            return Ok(house);
        }

        // POST api/houses
        [HttpPost]
        public async Task<IActionResult> PostHouse([FromBody] House house)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _houseService.CreateHouse(house);

            return NoContent();
        }

        // PUT api/house/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(int id, [FromBody] House updatedHouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _houseService.UpdateHouse(id, updatedHouse);

            return NoContent();
        }




        // DELETE api/houses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            await _houseService.DeleteHouse(id);

            return Ok();
        }
        // GET api/houses/{id}/apartments
        [HttpGet("{houseId}/apartments")]
        public async Task<ActionResult<List<Resident>>> GetHouseApartments(int houseId)
        {
            var apartments = await _houseService.GetHouseApartments(houseId);
            return Ok(apartments);
        }
    }
}
