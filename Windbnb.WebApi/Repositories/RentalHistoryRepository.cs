using Windbnb.WebApi.Interfaces;
using Windbnb.WebApi.Models.Entities;
using Windbnb.WebApi.Contexts;

namespace Windbnb.WebApi.Repositories
{
    public class RentalHistoryRepository : IRentalHistoryRepository
    {
        private readonly DataContext _dataContext;

        public RentalHistoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> RentApartment(RentalHistory purchase)
        {
            _dataContext.RentalHistories.Add(purchase);
            await _dataContext.SaveChangesAsync();
            return purchase.Id;
        }
    }
}