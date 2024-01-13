using System.ComponentModel.DataAnnotations;

namespace Windbnb.WebApi.Models.DTOs.RequestDTOs
{
    public class AddApartmentToOwnerRequest
    {
        [Range(1, int.MaxValue)]
        public Guid ApartmentId { get; set; }
    }
}