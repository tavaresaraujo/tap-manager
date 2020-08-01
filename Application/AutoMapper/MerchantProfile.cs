using Application.Models.Merchant;
using Application.Utility;
using AutoMapper;
using Domain.MerchantAggregate.Entities;
using System;

namespace Application.AutoMapper
{
    public class MerchantProfile : Profile
    {
        public MerchantProfile()
        {
            CreateMap<CreateMerchantRequest, Merchant>()
                .BeforeMap((s, d) => d.Code = Code.Create("mch_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Active = true);

            CreateMap<Merchant, UpdateMerchantRequest>();

            CreateMap<UpdateMerchantRequest, Merchant>()
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow);
        }
    }
}