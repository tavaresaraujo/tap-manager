using Application.Models.Account;
using Application.Utility;
using AutoMapper;
using Domain.AccountAggregate.Entities;
using System;

namespace Application.AutoMapper
{
    public class AccountBeverageProfile : Profile
    {
        public AccountBeverageProfile()
        {
            CreateMap<CreateAccountBeverageRequest, AccountBeverage>()
                .BeforeMap((s, d) => d.Code = Code.Create("acb_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Active = true);

            //CreateMap<AccountBeverage, GetAccountBeverageResponse>();

            //CreateMap<UpdateAccountBeverageRequest, AccountBeverage>()
            //    .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow);

            CreateMap<AccountBeverage, GetAccountBeverageResponse>()
                .BeforeMap((s, d) => d.BeverageCode = s.BeveragePrice.Code)
                .BeforeMap((s, d) => d.BeveragePriceCode = s.Account.Code);
        }
    }
}