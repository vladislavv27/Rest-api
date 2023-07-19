using Bbit2taks.Model;
using Microsoft.EntityFrameworkCore;

namespace Bbit2taks.Data
{
    public class HouseContext : DbContext
    {
        public HouseContext(DbContextOptions<HouseContext> options)
            : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Resident> Residents { get; set; }

    }
}
