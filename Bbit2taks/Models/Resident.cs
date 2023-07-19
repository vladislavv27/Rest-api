using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bbit2taks.Model
{
    public class Resident
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsOwner { get; set; }

        [ForeignKey("ApartmentId")]
        public int ApartmentId { get; set; }

    }
}
