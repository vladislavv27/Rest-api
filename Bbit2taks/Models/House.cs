using System.ComponentModel.DataAnnotations;

namespace Bbit2taks.Model
{
    public class House
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
    }
}
