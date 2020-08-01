using Application.Models.Beverage;
using Application.Utility;
using AutoMapper;
using Domain.BeverageAggregate.Entities;
using System;

namespace Application.AutoMapper
{
    public class BeverageProfile : Profile
    {
        public BeverageProfile()
        {
            CreateMap<CreateBeverageRequest, Beverage>()
                .BeforeMap((s, d) => d.Code = Code.Create("bvg_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Active = true);

            CreateMap<Beverage, GetBeverageResponse>();

            CreateMap<UpdateBeverageRequest, Beverage>()
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow);
        }
    }
}