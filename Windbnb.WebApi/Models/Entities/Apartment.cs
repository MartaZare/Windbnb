using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windbnb.WebApi.Models.Entities
{
    [Table("apartments")]
    public class Apartment
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public required string Name { get; set; }

        [MaxLength(255)]
        [Column("address")]
        public required string Address { get; set; }

        [MaxLength(1000)]
        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Column("is_rented")]
        public bool IsRented { get; set; } = false;

        [Column("owner_id")]
        public Guid OwnerId { get; set; }

        public Owner? Owner { get; set; }
    }
}