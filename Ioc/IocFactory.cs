using Application.AutoMapper;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Data;
using Data.Reposiotries;
using Domain.AccountAggregate.Repository;
using Domain.AddressAggregate.Interfaces;
using Domain.AddressAggregate.Repository;
using Domain.BeverageAggregate.Interfaces;
using Domain.BeverageAggregate.Repository;
using Domain.Interfaces;
using Domain.MerchantAggregate.Interfaces;
using Domain.MerchantAggregate.Repository;
using Domain.PhoneAggregate.Interfaces;
using Domain.PhoneAggregate.Repository;
using Domain.TapAggregate.Interfaces;
using Domain.TapAggregate.Repository;
using Domain.UserAggregate.Interfaces;
using Domain.UserAggregate.Repository;
using Domain.UsereAggregate.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Ioc
{
    public static class IocFactory
    {
        public static void Configure(IServiceCollection services)
        {
            //AppServices
            services.AddScoped<IAccountAppService, AccountAppService>();
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<IBeverageAppService, BeverageAppService>();
            services.AddScoped<IConsumptionAppService, ConsumptionAppService>();
            services.AddScoped<ISupplyAppService, SupplyAppService>();
            services.AddScoped<IMerchantAppService, MerchantAppService>();
            services.AddScoped<IPhoneAppService, PhoneAppService>();
            services.AddScoped<ITapAppService, TapAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ITransactionAppService, TransactionAppService>();

            //Repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountBeverageRepository, AccountBeverageRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBeverageRepository, BeverageRepository>();
            services.AddScoped<IBeveragePriceRepository, BeveragePriceRepository>();
            services.AddScoped<IConsumptionRepository, ConsumptionRepository>();
            services.AddScoped<ICreditRepository, CreditRepository>();
            services.AddScoped<IMerchantRepository, MerchantRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<ISupplyRepository, SupplyRepository>();
            services.AddScoped<ITapRepository, TapRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));

            //Auto Mapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}