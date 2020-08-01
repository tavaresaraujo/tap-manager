using Application.Helpers;
using Application.Models.Credit;
using AutoMapper;
using Domain.Interfaces;
using Domain.UserAggregate.Entities;
using Domain.UserAggregate.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CreditAppService : ICreditAppService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Credit> _creditRepository;
        #endregion

        #region Constructors
        public CreditAppService(IMapper mapper, IAsyncRepository<Credit> creditRepository)
        {
            _mapper = mapper;
            _creditRepository = creditRepository;
        }
        #endregion

        #region Implmentations
        public async Task<GetCreditResponse> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _creditRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Credit).Name, "Item not found.");

                return _mapper.Map<GetCreditResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetCreditResponse> GetByCodeAsync(string code)
        {
            try
            {
                var entity = await _creditRepository.GetAsync(x => x.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Consumption).Name, "Item not found.");

                return _mapper.Map<GetCreditResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetCreditResponse> AddAsync(CreateCreditRequest model)
        {
            try
            {
                var entity = _mapper.Map<Credit>(model);
                var response = await _creditRepository.AddAsync(entity);

                return _mapper.Map<GetCreditResponse>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateAsync(string code, UpdateCreditRequest model)
        {
            try
            {
                var entity = await _creditRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Consumption).Name, "Item not found.");

                _mapper.Map(model, entity);

                await _creditRepository.UpdateAsync(entity);

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
                var entity = await _creditRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Consumption).Name, "Item not found.");

                entity.Active = false;
                entity.DeletedAt = DateTime.UtcNow;

                await _creditRepository.UpdateAsync(entity);

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
                var entity = await _creditRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Consumption).Name, "Item not found.");

                await _creditRepository.DeleteAsync(entity);

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