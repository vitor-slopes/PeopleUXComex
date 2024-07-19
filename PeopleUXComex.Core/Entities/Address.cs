using System.ComponentModel.DataAnnotations;

namespace PeopleUXComex.Core.Entities
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }

        [Required]
        [StringLength(200)]
        public string Street { get; set; }

        [Required]
        [StringLength(8)]
        public string CEP { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }
    }
}
