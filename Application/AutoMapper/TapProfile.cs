using Application.Models.Tap;
using Application.Utility;
using AutoMapper;
using Domain.TapAggregate.Entities;
using Domain.TapAggregate.Enumerations;
using System;

namespace Application.AutoMapper
{
    public class TapProfile : Profile
    {
        public TapProfile()
        {
            CreateMap<CreateTapRequest, Tap>()
                .BeforeMap((s, d) => d.Code = Code.Create("tap_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Volume = 0)
                .BeforeMap((s, d) => d.Status = StatusEnum.WatingSync)
                .BeforeMap((s, d) => d.Active = true);

            CreateMap<Tap, GetTapResponse>();

            CreateMap<UpdateTapRequest, Tap>()
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow);
        }
    }
}