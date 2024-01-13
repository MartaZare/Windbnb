using AutoMapper;
using Windbnb.WebApi.Exceptions;
using Windbnb.WebApi.Interfaces;
using Windbnb.WebApi.Models.DTOs.RequestDTOs;
using Windbnb.WebApi.Models.Entities;
using Windbnb.WebApi.Repositories;

namespace Windbnb.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IJsonPlaceholderClient _client;
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IRentalHistoryRepository _purchaseHistoryRepository;
        private readonly IOwnerRepository _ownerRepository;

        public UserService(IJsonPlaceholderClient client, IMapper mapper, IApartmentRepository apartmentRepository, IRentalHistoryRepository purchaseHistoryRepository, IOwnerRepository ownerRepository)
        {
            _client = client;
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
            _purchaseHistoryRepository = purchaseHistoryRepository;
            _ownerRepository = ownerRepository;
        }

        public async Task<List<User>?> GetUsersAsync()
        {
            var usersResult = await _client.GetUsersAsync();
            if (!usersResult.IsSuccessful)
                throw new Exception("Users not retrieved.");

            return usersResult.Data;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var usersResult = await _client.GetUserByIdAsync(id);
            if (!usersResult.IsSuccessful)
                throw new NotFoundException("User not found.");

            return _mapper.Map<User>(usersResult.Data);
        }

        public async Task RentApartment(int userId, Guid apartmentId)
        {
            var apartment = await _apartmentRepository.GetApartmentByIdAsync(apartmentId) ?? throw new NotFoundException("Apartment not found.");
            _ = await _apartmentRepository.GetApartmentByIdAsync(apartment.OwnerId) ?? throw new NotFoundException("Apartment is not sold in apartments.");
            var user = await _client.GetUserByIdAsync(userId);
            if (!user.IsSuccessful)
                throw new NotFoundException("User not found.");

            RentalHistory newPurchase = new()
            {
                UserId = userId,
                ApartmentId = apartmentId,
                ApartmentName = apartment.Name,
                Price = apartment.Price
            };

            apartment.IsRented = true;

            await _apartmentRepository.UpdateApartmentByIdAsync(apartmentId, apartment);
            await _purchaseHistoryRepository.RentApartment(newPurchase);
        }
    }
}