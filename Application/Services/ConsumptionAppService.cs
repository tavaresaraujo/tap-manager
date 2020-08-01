using Application.Helpers;
using Application.Models.Consumption;
using AutoMapper;
using Domain.BeverageAggregate.Interfaces;
using Domain.Interfaces;
using Domain.UserAggregate.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ConsumptionAppService : IConsumptionAppService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Consumption> _consumptionRepository;
        #endregion

        #region Constructors
        public ConsumptionAppService(IMapper mapper, IAsyncRepository<Consumption> consumptionRepository)
        {
            _mapper = mapper;
            _consumptionRepository = consumptionRepository;
        }
        #endregion

        #region Implmentations
        public async Task<GetConsumptionResponse> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _consumptionRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Consumption).Name, "Item not found.");

                return _mapper.Map<GetConsumptionResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetConsumptionResponse> GetByCodeAsync(string code)
        {
            try
            {
                var entity = await _consumptionRepository.GetAsync(x => x.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Consumption).Name, "Item not found.");

                return _mapper.Map<GetConsumptionResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetConsumptionResponse> AddAsync(CreateConsumptionRequest model)
        {
            try
            {
                var entity = _mapper.Map<Consumption>(model);
                var response = await _consumptionRepository.AddAsync(entity);

                return _mapper.Map<GetConsumptionResponse>(response);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateAsync(string code, UpdateConsumptionRequest model)
        {
            try
            {
                var entity = await _consumptionRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Consumption).Name, "Item not found.");

                _mapper.Map(model, entity);

                await _consumptionRepository.UpdateAsync(entity);

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
                var entity = await _consumptionRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Consumption).Name, "Item not found.");

                entity.Active = false;
                entity.DeletedAt = DateTime.UtcNow;

                await _consumptionRepository.UpdateAsync(entity);

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
                var entity = await _consumptionRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Consumption).Name, "Item not found.");

                await _consumptionRepository.DeleteAsync(entity);

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