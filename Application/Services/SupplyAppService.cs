using Application.Helpers;
using Application.Models.Supply;
using AutoMapper;
using Domain.BeverageAggregate.Entities;
using Domain.BeverageAggregate.Interfaces;
using Domain.Interfaces;
using Domain.TapAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SupplyAppService : ISupplyAppService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Supply> _supplyRepository;
        private readonly IAsyncRepository<Tap> _tapRepository;
        #endregion

        #region Constructors
        public SupplyAppService(IMapper mapper, IAsyncRepository<Supply> supplyRepository, IAsyncRepository<Tap> tapRepository)
        {
            _mapper = mapper;
            _supplyRepository = supplyRepository;
            _tapRepository = tapRepository;
        }
        #endregion

        #region Implmentations
        public async Task<GetSupplyResponse> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _supplyRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Supply).Name, "Item not found.");

                return _mapper.Map<GetSupplyResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetSupplyResponse> GetByCodeAsync(string code)
        {
            try
            {
                var entity = await _supplyRepository.GetAsync(x => x.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Supply).Name, "Item not found.");

                return _mapper.Map<GetSupplyResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetSupplyResponse> AddAsync(CreateSupplyRequest model)
        {
            try
            {
                var tap = await _tapRepository.GetAsync(p => p.Code == model.TapCode);
                var entity = _mapper.Map<Supply>(model);
                entity.Tap = tap ?? throw new KeyNotFoundException("Invalid tap");

                var response = await _supplyRepository.AddAsync(entity);

                tap.Volume += model.Volume;
                await _tapRepository.UpdateAsync(tap);

                return _mapper.Map<GetSupplyResponse>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateAsync(string code, UpdateSupplyRequest model)
        {
            try
            {
                var entity = await _supplyRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Supply).Name, "Item not found.");

                _mapper.Map(model, entity);

                await _supplyRepository.UpdateAsync(entity);

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
                var entity = await _supplyRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Supply).Name, "Item not found.");

                entity.Active = false;
                entity.DeletedAt = DateTime.UtcNow;

                await _supplyRepository.UpdateAsync(entity);

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
                var entity = await _supplyRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Supply).Name, "Item not found.");

                await _supplyRepository.DeleteAsync(entity);

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