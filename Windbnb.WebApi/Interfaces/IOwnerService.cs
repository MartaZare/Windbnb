using Windbnb.WebApi.Models.DTOs.RequestDTOs;
using Windbnb.WebApi.Models.DTOs.ResponseDTOs;
using Windbnb.WebApi.Models.Entities;

namespace OwnerStore.WebApi.csproj.Services
{
    public interface IOwnerService
    {
        Task<Owner> AddOwnerAsync(AddOwnerRequest request);

        Task DeleteOwnerByIdAsync(Guid id);

        Task<List<GetOwnerResponse>> GetOwnersAsync();

        Task<GetOwnerResponse> GetOwnerByIdAsync(Guid id);

        Task UpdateOwnerByIdAsync(Guid id, UpdateOwnerRequest request);
    }
}