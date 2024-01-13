using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windbnb.WebApi.Models.DTOs.RequestDTOs
{
    public class AddApartmentRequest
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(255)]
        public required string Address { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [Column("owner_id")]
        public Guid OwnerId { get; set; }
    }
}