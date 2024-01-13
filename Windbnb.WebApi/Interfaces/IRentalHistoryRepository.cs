using Windbnb.WebApi.Models.Entities;

namespace Windbnb.WebApi.Interfaces
{
    public interface IRentalHistoryRepository
    {
        Task<int> RentApartment(RentalHistory purchase);
    }
}