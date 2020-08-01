using Application.Models.Address;
using Application.Utility;
using AutoMapper;
using Domain.AddressAggregate.Entities;
using System;

namespace Application.AutoMapper
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressRequest, Address>()
                .BeforeMap((s, d) => d.Code = Code.Create("add_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Active = true);

            CreateMap<Address, GetAddressResponse>();

            CreateMap<UpdateAddressRequest, Address>()
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow);
        }
    }
}