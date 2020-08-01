using Application.Models.Address;
using Application.Models.Phone;
using Application.Models.User;
using Application.Utility;
using AutoMapper;
using Domain.AddressAggregate.Entities;
using Domain.PhoneAggregate.Entities;
using Domain.UserAggregate.Entities;
using System;

namespace Application.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequest, User>()
                .BeforeMap((s, d) => d.Code = Code.Create("usr_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Active = true);

            CreateMap<User, GetUserResponse>();

            CreateMap<UpdateAddressRequest, Address>()
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow);

            CreateMap<UpdatePhoneRequest, Phone>()
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow);
        }
    }
}