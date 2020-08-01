using Application.Models.Credit;
using Application.Utility;
using AutoMapper;
using Domain.UserAggregate.Entities;
using System;

namespace Application.AutoMapper
{
    public class CreditProfile : Profile
    {
        public CreditProfile()
        {
            CreateMap<CreateCreditRequest, Credit>()
                .BeforeMap((s, d) => d.Code = Code.Create("crd_"))
                .BeforeMap((s, d) => d.CreatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.UpdatedAt = DateTime.UtcNow)
                .BeforeMap((s, d) => d.Active = true);

            CreateMap<Credit, GetCreditResponse>();
        }
    }
}