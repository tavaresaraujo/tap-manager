using Application.Models.Beverage;
using Application.Utility;
using AutoMapper;
using Domain.BeverageAggregate.Entities;
using System;

namespace Application.AutoMapper
{
    public class BeveragePriceProfile : Profile
    {
        public BeveragePriceProfile()
        {
            CreateMap<CreateBeveragePriceRequest, BeveragePrice>()
                .BeforeMap((s, d) => d.Code = Code.Create("bvp_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Active = true);

            CreateMap<BeveragePrice, GetBeveragePriceResponse>();

            //CreateMap<UpdateBeveragePriceRequest, BeveragePrice>()
            //    .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow);
        }
    }
}