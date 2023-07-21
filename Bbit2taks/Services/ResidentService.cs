using Bbit2taks.Data;
using Bbit2taks.Model;
using Microsoft.EntityFrameworkCore;

namespace Bbit2taks.Services
{
    public class ResidentService
    {
        private readonly ApplicationDbContext _context; 

        public ResidentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Resident>> GetResidents()
        {
            return await _context.Residents.ToListAsync();
        }

        public async Task<Resident> GetResidentById(int id)
        {
            return await _context.Residents.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task CreateResident(Resident resident)
        {
            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateResident(int id, Resident updatedResident)
        {
            var resident = await _context.Residents.FindAsync(id);

            if (resident == null)
            {
                return;
            }

            resident.Name = updatedResident.Name;
            resident.Surname = updatedResident.Surname;
            resident.PersonalCode = updatedResident.PersonalCode;
            resident.DateOfBirth = updatedResident.DateOfBirth;
            resident.Phone = updatedResident.Phone;
            resident.Email = updatedResident.Email;
            resident.IsOwner = updatedResident.IsOwner;
            resident.ApartmentId = updatedResident.ApartmentId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteResident(int id)
        {
            var resident = await _context.Residents.FindAsync(id);

            if (resident != null)
            {
                _context.Residents.Remove(resident);
                await _context.SaveChangesAsync();
            }
        }
    }
}
