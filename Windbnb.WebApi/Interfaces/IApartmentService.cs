using Windbnb.WebApi.Models.DTOs.RequestDTOs;
using Windbnb.WebApi.Models.DTOs.ResponseDTOs;
using Windbnb.WebApi.Models.Entities;

namespace Windbnb.WebApi.Services
{
    public interface IApartmentService
    {
        Task<Apartment> AddApartment(AddApartmentRequest apartment);

        Task DeleteApartmentById(Guid id);

        Task<GetApartmentResponse?> GetApartmentById(Guid id);

        Task<List<GetApartmentResponse>> GetApartments();

        Task UpdateApartmentById(Guid id, UpdateApartmentRequest updateRequest);

        Task AddApartmentToOwnerByIdAsync(Guid id, AddApartmentToOwnerRequest request);

        //Task DeleteApartmentFromOwnerByIdAsync(Guid id);
    }
}