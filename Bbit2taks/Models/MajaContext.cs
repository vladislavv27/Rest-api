using Bbit2taks.Model;
using Microsoft.EntityFrameworkCore;

namespace Bbit2taks.Models
{
    public class MajaContext:DbContext
    {
        public MajaContext(DbContextOptions<MajaContext> options)
            :base(options)
        {
        }

        public DbSet<Maja> Majas { get; set; } 
        public DbSet<Dzivoklis> Dzivoklis { get; set; } 
        public DbSet<Iedzivotajs> Iedzivotajs { get; set; }

    }
}
