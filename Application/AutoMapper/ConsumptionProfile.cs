using Application.Models.Consumption;
using Application.Utility;
using AutoMapper;
using Domain.UserAggregate.Entities;
using System;

namespace Application.AutoMapper
{
    public class ConsumptionProfile : Profile
    {
        public ConsumptionProfile()
        {
            CreateMap<CreateConsumptionRequest, Consumption>()
                .BeforeMap((s, d) => d.Code = Code.Create("con_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Active = true);

            CreateMap<Consumption, GetConsumptionResponse>();

        }
    }
}