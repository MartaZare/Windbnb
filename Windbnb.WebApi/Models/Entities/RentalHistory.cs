using Windbnb.WebApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windbnb.WebApi.Models.Entities
{
    [Table("rental-histories")]
    public class RentalHistory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("apartment_id")]
        public Guid ApartmentId { get; set; }

        public Apartment? Apartment { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("apartment_name")]
        public string? ApartmentName { get; set; }

        [Required]
        [Column("price")]
        public decimal Price { get; set; }
    }
}