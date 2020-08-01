using Application.Models.Supply;
using Application.Utility;
using AutoMapper;
using Domain.BeverageAggregate.Entities;
using System;

namespace Application.AutoMapper
{
    public class SupplyProfile : Profile
    {
        public SupplyProfile()
        {
            CreateMap<CreateSupplyRequest, Supply>()
                .BeforeMap((s, d) => d.Code = Code.Create("spp_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Active = true);

            CreateMap<Supply, GetSupplyResponse>()
                .BeforeMap((s, d) => d.TapCode = s.Tap.Code);

        }
    }
}