using Bbit2taks.Data;
using Bbit2taks.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bbit2taks.Services
{

    public class ApartmentService
    {
        private readonly ApplicationDbContext _context; // Replace "YourDbContext" with your actual DbContext class

        public ApartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Apartment>> GetApartments()
        {
            return await _context.Apartments.ToListAsync();
        }

        public async Task<Apartment> GetApartmentById(int id)
        {
            return await _context.Apartments.FirstOrDefaultAsync(a=>a.Id==id);
        }

        public async Task<Apartment> CreateApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();
            return apartment;
        }

        public async Task UpdateApartment(int id, Apartment updatedApartment)
        {
            var apartment = await _context.Apartments.FindAsync(id);

            if (apartment == null)
            {
                // Apartment not found
                return;
            }

            // Update apartment properties
            apartment.Number = updatedApartment.Number;
            apartment.Floor = updatedApartment.Floor;
            apartment.NumberOfRooms = updatedApartment.NumberOfRooms;
            apartment.Population = updatedApartment.Population;
            apartment.FullArea = updatedApartment.FullArea;
            apartment.LivingSpace = updatedApartment.LivingSpace;
            apartment.HouseId = updatedApartment.HouseId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteApartment(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);

            if (apartment != null)
            {
                _context.Apartments.Remove(apartment);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Resident>> GetApartmentsResident(int apartmentId)
        {
            return await _context.Residents.Where(p=>p.ApartmentId == apartmentId).ToListAsync();
        }

    }

}
