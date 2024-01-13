using Windbnb.WebApi.Models.Entities;

namespace Windbnb.WebApi.Repositories
{
    public interface IApartmentRepository
    {
        Task<Apartment> AddApartmentAsync(Apartment apartment);

        Task DeleteApartmentByIdAsync(Guid id);

        Task<Apartment?> GetApartmentByIdAsync(Guid id);

        Task<Apartment?> GetApartmentByNameAsync(string name);

        Task<List<Apartment>> GetApartmentsAsync();

        Task UpdateApartmentByIdAsync(Guid id, Apartment apartment);
    }
}