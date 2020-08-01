using Application.Helpers;
using Application.Models.Merchant;
using AutoMapper;
using Domain.Interfaces;
using Domain.MerchantAggregate.Entities;
using Domain.MerchantAggregate.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MerchantAppService : IMerchantAppService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Merchant> _merchantRepository;
        #endregion

        #region Constructors
        public MerchantAppService(IMapper mapper, IAsyncRepository<Merchant> merchantRepository)
        {
            _mapper = mapper;
            _merchantRepository = merchantRepository;
        }
        #endregion

        #region Implementations
        public async Task<GetMerchantResponse> GetByIdAsync(int id)
        {
            var entity = await _merchantRepository.GetByIdAsync(id);

            if (entity == null)
                throw new NotFoundException(typeof(Merchant).Name, "Item not found.");

            return _mapper.Map<GetMerchantResponse>(entity);
        }

        public async Task<GetMerchantResponse> GetByCodeAsync(string code)
        {
            var entity = await _merchantRepository.GetAsync(p => p.Code == code && p.Active == true);

            if (entity == null)
                throw new NotFoundException(typeof(Merchant).Name, "Item not found.");

            return _mapper.Map<GetMerchantResponse>(entity);
        }

        public async Task<GetMerchantResponse> AddAsync(CreateMerchantRequest model)
        {
            var entity = _mapper.Map<Merchant>(model);
            var response = await _merchantRepository.AddAsync(entity);

            return _mapper.Map<GetMerchantResponse>(response);
        }

        public async Task<bool> UpdateAsync(string code, UpdateMerchantRequest model)
        {
            var entity = await _merchantRepository.GetAsync(p => p.Code == code && p.Active == true);

            if (entity == null)
                throw new NotFoundException(typeof(Merchant).Name, "Item not found.");

            _mapper.Map(model, entity);

            await _merchantRepository.UpdateAsync(entity);

            return true;
        }

        public async Task<bool> LogicDeleteAsync(string code)
        {
            var entity = await _merchantRepository.GetAsync(p => p.Code == code && p.Active == true);
            if (entity == null)
                throw new NotFoundException(typeof(Merchant).Name, "Item not found.");

            entity.Active = false;
            entity.DeletedAt = DateTime.UtcNow;

            await _merchantRepository.UpdateAsync(entity);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _merchantRepository.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException(typeof(Merchant).Name, "Item not found.");

            if (entity.Active == false)
                throw new PreconditionFailedException(typeof(Merchant).Name, "Item already deleted.");

            await _merchantRepository.DeleteAsync(entity);

            return true;
        }
        #endregion
    }
}