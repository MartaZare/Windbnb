using Windbnb.WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Windbnb.WebApi.Contexts;

namespace Windbnb.WebApi.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly DataContext _dataContext;

        public ApartmentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Apartment>> GetApartmentsAsync()
        {
            return await _dataContext.Apartments.ToListAsync();
        }

        public async Task<Apartment?> GetApartmentByIdAsync(Guid id)
        {
            return await _dataContext.Apartments.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Apartment?> GetApartmentByNameAsync(string name)
        {
            return await _dataContext.Apartments.FirstOrDefaultAsync(i => i.Name == name);
        }

        public async Task<Apartment> AddApartmentAsync(Apartment apartment)
        {
            _dataContext.Apartments.Add(apartment);
            await _dataContext.SaveChangesAsync();
            return apartment;
        }

        public async Task UpdateApartmentByIdAsync(Guid id, Apartment apartment)
        {
            var apartmentToUpdate = await _dataContext.Apartments.FirstOrDefaultAsync(i => i.Id == id);
            if (apartmentToUpdate == null)
                return;

            apartmentToUpdate.Name = apartment.Name;
            apartmentToUpdate.Address = apartment.Address;
            apartmentToUpdate.Description = apartment.Description;
            apartmentToUpdate.Price = apartment.Price;
            apartmentToUpdate.OwnerId = apartment.OwnerId;
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteApartmentByIdAsync(Guid id)
        {
            var apartmentToDelete = await _dataContext.Apartments.FirstOrDefaultAsync(i => i.Id == id);
            if (apartmentToDelete == null)
                return;

            _dataContext.Remove(apartmentToDelete);
            await _dataContext.SaveChangesAsync();
        }
    }
}