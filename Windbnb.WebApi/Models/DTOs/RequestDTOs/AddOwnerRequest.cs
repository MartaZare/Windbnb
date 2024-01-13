using System.ComponentModel.DataAnnotations;

namespace Windbnb.WebApi.Models.DTOs.RequestDTOs
{
    public class AddOwnerRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string ContactNumber { get; set; }
    }
}