using System.ComponentModel.DataAnnotations;

namespace Windbnb.WebApi.Models.DTOs.RequestDTOs
{
    public class AddUserRequest
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
    }
}