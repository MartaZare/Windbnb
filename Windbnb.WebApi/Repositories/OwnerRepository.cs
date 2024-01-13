using Windbnb.WebApi.Interfaces;
using Windbnb.WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Windbnb.WebApi.Contexts;

namespace Windbnb.WebApi.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _dataContext;

        public OwnerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Owner>> GetOwnersAsync()
        {
            return await _dataContext.Owners.ToListAsync();
        }

        public async Task<Owner?> GetOwnerByIdAsync(Guid? id)
        {
            return await _dataContext.Owners.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Owner?> GetOwnerByNameAsync(string name)
        {
            return await _dataContext.Owners.FirstOrDefaultAsync(i => i.Name == name);
        }

        public async Task<Owner> AddOwnerAsync(Owner Owner)
        {
            _dataContext.Owners.Add(Owner);
            await _dataContext.SaveChangesAsync();
            return Owner;
        }

        public async Task UpdateOwnerByIdAsync(Guid id, Owner Owner)
        {
            var OwnerToUpdate = await _dataContext.Owners.FirstOrDefaultAsync(i => i.Id == id);
            if (OwnerToUpdate == null)
                return;

            OwnerToUpdate.Name = Owner.Name;
            OwnerToUpdate.ContactNumber = Owner.ContactNumber;
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteOwnerByIdAsync(Guid id)
        {
            var OwnerToDelete = await _dataContext.Owners.FirstOrDefaultAsync(i => i.Id == id);
            if (OwnerToDelete == null)
                return;

            _dataContext.Remove(OwnerToDelete);
            await _dataContext.SaveChangesAsync();
        }
    }
}