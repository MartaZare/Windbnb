using Windbnb.WebApi.Models.DTOs.RequestDTOs;
using Windbnb.WebApi.Models.Entities;

namespace Windbnb.WebApi.Interfaces
{
    public interface IUserService
    {
        Task<List<User>?> GetUsersAsync();

        Task<User?> GetUserByIdAsync(int id);

        Task RentApartment(int userId, Guid apartmentId);
    }
}