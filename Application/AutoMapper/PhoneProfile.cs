using Application.Models.Phone;
using Application.Utility;
using AutoMapper;
using Domain.PhoneAggregate.Entities;
using System;

namespace Application.AutoMapper
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile()
        {
            CreateMap<CreatePhoneRequest, Phone>()
                .BeforeMap((s, d) => d.Code = Code.Create("pho_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Active = true);

            CreateMap<Phone, GetPhoneResponse>();

            CreateMap<UpdatePhoneRequest, Phone>()
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow);
        }
    }
}