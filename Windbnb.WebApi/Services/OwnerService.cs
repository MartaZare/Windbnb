using AutoMapper;
using Windbnb.WebApi.Exceptions;
using Windbnb.WebApi.Interfaces;
using Windbnb.WebApi.Models.DTOs.RequestDTOs;
using Windbnb.WebApi.Models.DTOs.ResponseDTOs;
using Windbnb.WebApi.Models.Entities;

namespace OwnerStore.WebApi.csproj.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public async Task<Owner> AddOwnerAsync(AddOwnerRequest request)
        {
            var owner = await _ownerRepository.GetOwnerByNameAsync(request.Name);
            if (owner != null)
                throw new DuplicateValueException("Owner with this name already exists.");

            var newOwner = _mapper.Map<Owner>(request);
            return await _ownerRepository.AddOwnerAsync(newOwner);
        }

        public async Task<List<GetOwnerResponse>> GetOwnersAsync()
        {
            var owners = await _ownerRepository.GetOwnersAsync();
            return owners.Select(Owner => _mapper.Map<GetOwnerResponse>(Owner)).ToList();
        }

        public async Task<GetOwnerResponse> GetOwnerByIdAsync(Guid id)
        {
            var owner = await _ownerRepository.GetOwnerByIdAsync(id) ?? throw new NotFoundException("Owner not found.");
            return _mapper.Map<GetOwnerResponse>(owner);
        }

        public async Task UpdateOwnerByIdAsync(Guid id, UpdateOwnerRequest request)
        {
            var owner = await _ownerRepository.GetOwnerByIdAsync(id) ?? throw new NotFoundException("Owner not found.");

            if (owner.Name != request.Name)
            {
                var OwnerWithSameName = await _ownerRepository.GetOwnerByNameAsync(request.Name);
                if (OwnerWithSameName != null)
                    throw new DuplicateValueException("Owner with name already exists.");
            }

            var updatedOwner = _mapper.Map<Owner>(request);
            await _ownerRepository.UpdateOwnerByIdAsync(id, updatedOwner);
        }

        public async Task DeleteOwnerByIdAsync(Guid id)
        {
            _ = await _ownerRepository.GetOwnerByIdAsync(id) ?? throw new NotFoundException("Owner not found.");
            await _ownerRepository.DeleteOwnerByIdAsync(id);
        }
    }
}