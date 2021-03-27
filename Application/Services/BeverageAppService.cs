using Application.Helpers;
using Application.Models.Beverage;
using AutoMapper;
using Domain.AccountAggregate.Entities;
using Domain.BeverageAggregate.Entities;
using Domain.BeverageAggregate.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BeverageAppService : IBeverageAppService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Beverage> _beverageRepository;
        private readonly IAsyncRepository<BeveragePrice> _beveragePriceRepository;
        private readonly IAsyncRepository<Account> _accountRepository;
        #endregion

        #region Constructors
        public BeverageAppService(IMapper mapper, IAsyncRepository<Beverage> beverageRepository, IAsyncRepository<BeveragePrice> beveragePriceRepository, 
            IAsyncRepository<Account> accountRepository)
        {
            _mapper = mapper;
            _beverageRepository = beverageRepository;
            _beveragePriceRepository = beveragePriceRepository;
            _accountRepository = accountRepository;
        }
        #endregion

        #region Implementations
        public async Task<List<GetBeverageResponse>> Get()
        {
            try
            {
                var entity = await _beverageRepository.ListAllAsync();
                //if (entity == null)
                //    throw new NotFoundException(typeof(Tap).Name, "Item not found.");

                return _mapper.Map<List<GetBeverageResponse>>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetBeverageResponse> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _beverageRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Beverage).Name, "Item not found.");

                return _mapper.Map<GetBeverageResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetBeverageResponse> GetByCodeAsync(string code)
        {
            try
            {
                var entity = await _beverageRepository.GetAsync(x => x.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Beverage).Name, "Item not found.");

                return _mapper.Map<GetBeverageResponse>(entity);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetBeverageResponse> AddAsync(CreateBeverageRequest model)
        {
            try
            {
                var entity = _mapper.Map<Beverage>(model);
                var response = await _beverageRepository.AddAsync(entity);

                return _mapper.Map<GetBeverageResponse>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public async Task<bool> UpdateAsync(string code, UpdateBeverageRequest model)
        {
            try
            {
                var entity = await _beverageRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Beverage).Name, "Item not found.");

                _mapper.Map(model, entity);

                await _beverageRepository.UpdateAsync(entity);

                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> LogicDeleteAsync(string code)
        {
            try
            {
                var entity = await _beverageRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Beverage).Name, "Item not found.");

                entity.Active = false;
                entity.DeletedAt = DateTime.UtcNow;

                await _beverageRepository.UpdateAsync(entity);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _beverageRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Beverage).Name, "Item not found.");

                await _beverageRepository.DeleteAsync(entity);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetBeveragePriceResponse> CreateBeveragePriceAsync(string code, CreateBeveragePriceRequest model)
        {
            try
            {
                var beverage = await _beverageRepository.GetAsync(p => p.Code == code);
                if (beverage == null)
                    throw new KeyNotFoundException("Invalid beverage.");

                //Todo: isso tem que vir de header
                var account = await _accountRepository.GetAsync(p => p.Code == model.AccountCode);
                var entity = _mapper.Map<BeveragePrice>(model);
                entity.Beverage= beverage ?? throw new KeyNotFoundException("Invalid account.");

                var response = await _beveragePriceRepository.AddAsync(entity);

                return _mapper.Map<GetBeveragePriceResponse>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}