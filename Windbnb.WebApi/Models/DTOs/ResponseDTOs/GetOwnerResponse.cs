using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Windbnb.WebApi.Models.DTOs.ResponseDTOs
{
    public class GetOwnerResponse
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(15)]
        public required string ContactNumber { get; set; }
    }
}