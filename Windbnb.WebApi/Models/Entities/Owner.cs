using Windbnb.WebApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windbnb.WebApi.Models.Entities
{
    [Table("owners")]
    public class Owner
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public required string Name { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("contacts")]
        public required string ContactNumber { get; set; }

        public ICollection<Apartment> Apartments { get; } = new List<Apartment>();
    }
}