using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bbit2taks.Model
{

    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int NumberOfRooms { get; set; }
        public int Population { get; set; }
        public double FullArea { get; set; }
        public double LivingSpace { get; set; }
        [ForeignKey("HouseId")]
        public int HouseId { get; set; }



    }
}
