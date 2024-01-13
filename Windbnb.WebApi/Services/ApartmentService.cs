using AutoMapper;
using Windbnb.WebApi.Exceptions;
using Windbnb.WebApi.Interfaces;
using Windbnb.WebApi.Models.DTOs.RequestDTOs;
using Windbnb.WebApi.Models.DTOs.RequestDTOs;
using Windbnb.WebApi.Models.DTOs.ResponseDTOs;
using Windbnb.WebApi.Models.Entities;
using Windbnb.WebApi.Repositories;
using System.Data;


namespace Windbnb.WebApi.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly IOwnerRepository _ownerRepository;

        public ApartmentService(IApartmentRepository apartmentRepository, IMapper mapper, IOwnerRepository ownerRepository)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _ownerRepository = ownerRepository;
        }

        public async Task<List<GetApartmentResponse>> GetApartments()
        {
            var apartments = await _apartmentRepository.GetApartmentsAsync();
            return apartments.Select(_mapper.Map<GetApartmentResponse>).ToList();
        }

        public async Task<GetApartmentResponse?> GetApartmentById(Guid id)
        {
            var apartment = await _apartmentRepository.GetApartmentByIdAsync(id) ?? throw new NotFoundException("Apartment not found.");
            return _mapper.Map<GetApartmentResponse>(apartment);
        }

        public async Task<Apartment> AddApartment(AddApartmentRequest request)
        {
            var apartment = await _apartmentRepository.GetApartmentByNameAsync(request.Name);
            if (apartment != null)
                throw new DuplicateValueException("Apartment with this name already exists.");

            var response = _mapper.Map<Apartment>(request);
            return await _apartmentRepository.AddApartmentAsync(response);
        }

        public async Task UpdateApartmentById(Guid id, UpdateApartmentRequest request)
        {
            var apartment = await _apartmentRepository.GetApartmentByIdAsync(id) ?? throw new NotFoundException("Apartment not found.");

            if (apartment.IsRented)
                throw new NotFoundException("Apartment out of stock.");

            if (apartment.Name != request.Name)
            {
                var duplicateNameApartment = await _apartmentRepository.GetApartmentByNameAsync(request.Name);
                if (duplicateNameApartment != null)
                    throw new DuplicateValueException("Apartment with name already exists.");
            }

            var response = _mapper.Map<Apartment>(request);
            await _apartmentRepository.UpdateApartmentByIdAsync(id, response);
        }

        public async Task DeleteApartmentById(Guid id)
        {
            var apartment = await _apartmentRepository.GetApartmentByIdAsync(id) ?? throw new NotFoundException("Apartment not found.");

            if (apartment.IsRented)
                throw new NotFoundException("Apartment out of stock.");

            await _apartmentRepository.DeleteApartmentByIdAsync(id);
        }

        public async Task AddApartmentToOwnerByIdAsync(Guid id, AddApartmentToOwnerRequest request)
        {
            var apartment = await _apartmentRepository.GetApartmentByIdAsync(id) ?? throw new NotFoundException("Apartment not found.");
            if (apartment.IsRented)
                throw new NotFoundException("Apartment out of stock.");

            _ = await _apartmentRepository.GetApartmentByIdAsync(request.ApartmentId) ?? throw new NotFoundException("Apartment not found.");

            apartment.OwnerId = request.ApartmentId;
            await _apartmentRepository.UpdateApartmentByIdAsync(id, apartment);
        }

        //public async Task DeleteApartmentFromOwnerByIdAsync(Guid id)
        //{
        //    var apartment = await _apartmentRepository.GetApartmentByIdAsync(id) ?? throw new NotFoundException("Apartment not found.");
        //    if (apartment.IsRented)
        //        throw new NotFoundException("Apartment out of stock.");

        //    _ = await _ownerRepository.GetOwnerByIdAsync(apartment.OwnerId) ?? throw new NotFoundException("Owner is not assigned to a apartment.");

        //    //apartment.OwnerId = null;
        //    await _apartmentRepository.UpdateApartmentByIdAsync(id, apartment);
        //}
    }
}