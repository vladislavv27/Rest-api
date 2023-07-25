using Bbit2taks.Model;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.ModelBinding;
using System.Web.Http;
using Bbit2taks.Data;
using Microsoft.EntityFrameworkCore;

namespace Bbit2taks.Services
{
    
        public class HouseService
        {
            private ApplicationDbContext _context;

            public HouseService(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<House>> GetHouses()
            {
                return await _context.Houses.ToListAsync();
            }

            public async Task<House> GetHouseById(int id)
            {
                return await _context.Houses.FirstOrDefaultAsync(h => h.Id == id);
            }

            public async Task CreateHouse(House house)
            {
                _context.Houses.Add(house);
                await _context.SaveChangesAsync();
            }

        public async Task UpdateHouse(int id, House updatedHouse)
        {
            var house = await _context.Houses.FindAsync(id);

            if (house == null)
            {
                return;
            }

            house.Number = updatedHouse.Number;
            house.Street = updatedHouse.Street;
            house.City = updatedHouse.City;
            house.Country = updatedHouse.Country;
            house.Postcode = updatedHouse.Postcode;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteHouse(int id)
            {
                House house = await _context.Houses.FirstOrDefaultAsync(h => h.Id == id);
                if (house != null)
                {
                    _context.Houses.Remove(house);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<List<Apartment>> GetHouseApartments(int houseId)
            {
                return await _context.Apartments.Where(p => p.HouseId == houseId).ToListAsync();
            }

        }

        

    
}
