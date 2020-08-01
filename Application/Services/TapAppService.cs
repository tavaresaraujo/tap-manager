using Application.Helpers;
using Application.Models.Tap;
using AutoMapper;
using Domain.BeverageAggregate.Entities;
using Domain.Interfaces;
using Domain.TapAggregate.Entities;
using Domain.TapAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TapAppService : ITapAppService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Tap> _tapRepository;
        private readonly IAsyncRepository<BeveragePrice> _beveragePriceRepository;
        #endregion

        #region Constructors
        public TapAppService(IMapper mapper, IAsyncRepository<Tap> tapRepository, IAsyncRepository<BeveragePrice> beveragePrice)
        {
            _mapper = mapper;
            _tapRepository = tapRepository;
            _beveragePriceRepository = beveragePrice;
        }
        #endregion

        #region Implmentations
        public async Task<GetTapResponse> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _tapRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Tap).Name, "Item not found.");

                return _mapper.Map<GetTapResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetTapResponse> GetByCodeAsync(string code)
        {
            try
            {
                var entity = await _tapRepository.GetAsync(x => x.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Tap).Name, "Item not found.");

                return _mapper.Map<GetTapResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetTapResponse> AddAsync(CreateTapRequest model)
        {
            try
            {
                var beveragePrice = await _beveragePriceRepository.GetAsync(p => p.Code == model.BeveragePriceCode);

                //Todo: Verificar regra
                var entity = _mapper.Map<Tap>(model);
                entity.BeveragePrice = beveragePrice ?? throw new KeyNotFoundException("Invalid beveragePrice.");

                return _mapper.Map<GetTapResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateAsync(string code, UpdateTapRequest model)
        {
            try
            {
                var entity = await _tapRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Tap).Name, "Item not found.");

                _mapper.Map(model, entity);

                await _tapRepository.UpdateAsync(entity);

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
                var entity = await _tapRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Tap).Name, "Item not found.");

                entity.Active = false;
                entity.DeletedAt = DateTime.UtcNow;

                await _tapRepository.UpdateAsync(entity);

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
                var entity = await _tapRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Tap).Name, "Item not found.");

                await _tapRepository.DeleteAsync(entity);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
