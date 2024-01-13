using Windbnb.WebApi.Models.Entities;

namespace Windbnb.WebApi.Interfaces
{
    public interface IOwnerRepository
    {
        Task<Owner> AddOwnerAsync(Owner Owner);

        Task DeleteOwnerByIdAsync(Guid id);

        Task<Owner?> GetOwnerByIdAsync(Guid? id);

        Task<Owner?> GetOwnerByNameAsync(string name);

        Task<List<Owner>> GetOwnersAsync();

        Task UpdateOwnerByIdAsync(Guid id, Owner owner);
    }
}