using Application.Models.Account;
using Application.Utility;
using AutoMapper;
using Domain.AccountAggregate.Entities;
using System;

namespace Application.AutoMapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountRequest, Account>()
                .BeforeMap((s, d) => d.Code = Code.Create("acc_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Active = true);

            CreateMap<CreateAccountFullRequest, Account>()
                //.ForMember(x => x.Blarg, opt => opt.Ignore())
                .BeforeMap((s, d) => d.Code = Code.Create("acc_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Active = true);

            CreateMap<Account, GetAccountResponse>()
                .BeforeMap((s, d) => d.MerchantCode = s.Merchant.Code)
                .BeforeMap((s, d) => d.PhoneCode = s.Phone.Code)
                .BeforeMap((s, d) => d.AddressCode = s.Address.Code);

            CreateMap<Account, GetAccountFullResponse>()
                .BeforeMap((s, d) => d.MerchantCode = s.Merchant.Code)
                .BeforeMap((s, d) => d.PhoneCode = s.Phone.Code)
                .BeforeMap((s, d) => d.AddressCode = s.Address.Code);
        }
    }
}