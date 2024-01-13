using AutoMapper;
using Windbnb.WebApi.Models.DTOs.RequestDTOs;
using Windbnb.WebApi.Models.DTOs.ResponseDTOs;
using Windbnb.WebApi.Models.Entities;

namespace Windbnb.WebApi.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddApartmentRequest, Apartment>();

            CreateMap<UpdateApartmentRequest, Apartment>();

            CreateMap<Apartment, GetApartmentResponse>();

            CreateMap<AddOwnerRequest, Owner>();

            CreateMap<Owner, GetOwnerResponse>();

            CreateMap<UpdateOwnerRequest, Owner>();
        }
    }
}