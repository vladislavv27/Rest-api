using Bbit2taks.Model;
using Microsoft.EntityFrameworkCore;

namespace Bbit2taks.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public static void SeedData(ApplicationDbContext context)
        {
            var house1 = new House { Number = 1, Street = "Pils iela 2", City = "Jelgava", Country = "Latvia", Postcode = "LV-3005" };
            var house2 = new House { Number = 2, Street = "Atmodas iela 12", City = "Jelgava", Country = "Latvia", Postcode = "LV-3007" };
            context.Houses.AddRange(house1, house2);

            var apartments = new List<Apartment>
        {
            new Apartment { Number = 101, Floor = 1, NumberOfRooms = 3, Population = 2, FullArea = 80.5, LivingSpace = 70.0, HouseId = house1.Id },
            new Apartment { Number = 102, Floor = 1, NumberOfRooms = 4, Population = 4, FullArea = 100.0, LivingSpace = 90.0, HouseId = house1.Id },
            new Apartment { Number = 201, Floor = 2, NumberOfRooms = 2, Population = 1, FullArea = 60.0, LivingSpace = 50.0, HouseId = house2.Id },
            new Apartment { Number = 202, Floor = 3, NumberOfRooms = 3, Population = 3, FullArea = 75.0, LivingSpace = 65.0, HouseId = house2.Id },
            new Apartment { Number = 203, Floor = 2, NumberOfRooms = 2, Population = 2, FullArea = 65.0, LivingSpace = 55.0, HouseId = house2.Id }
        };
            context.Apartments.AddRange(apartments);

            var residents = new List<Resident>
        {
            new Resident { Name = "Vladislavs", Surname = "Mihailovs", PersonalCode = "1234567890", DateOfBirth = new DateTime(1985, 5, 10), Phone = "26245165", Email = "john.doe@example.com", IsOwner = true, ApartmentId = apartments[0].Id },
            new Resident { Name = "Jane", Surname = "Smith", PersonalCode = "9876543210", DateOfBirth = new DateTime(1990, 7, 15), Phone = "26245190", Email = "jane.smith@example.com", IsOwner = true, ApartmentId = apartments[1].Id },
            new Resident { Name = "Alice", Surname = "Johnson", PersonalCode = "5555555555", DateOfBirth = new DateTime(1988, 3, 25), Phone = "26291165", Email = "alice.johnson@example.com", IsOwner = false, ApartmentId = apartments[2].Id },
            new Resident { Name = "Bob", Surname = "Williams", PersonalCode = "7777777777", DateOfBirth = new DateTime(1975, 12, 5), Phone = "29545165", Email = "bob.williams@example.com", IsOwner = true, ApartmentId = apartments[3].Id }
        };
            context.Residents.AddRange(residents);

            context.SaveChanges();
        }

    }
    
}
