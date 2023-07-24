using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bbit2taks.DTO
{
    public class ApartmentDto
    {
       
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int NumberOfRooms { get; set; }
        public int Population { get; set; }
        public double FullArea { get; set; }
        public double LivingSpace { get; set; }  
        public int HouseId { get; set; }
    }
}
