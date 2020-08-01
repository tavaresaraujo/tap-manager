using Application.Helpers;
using Application.Models.Phone;
using AutoMapper;
using Domain.Interfaces;
using Domain.PhoneAggregate.Entities;
using Domain.PhoneAggregate.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PhoneAppService : IPhoneAppService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Phone> _phoneRepository;
        #endregion

        #region Constructors
        public PhoneAppService(IMapper mapper, IAsyncRepository<Phone> phoneRepository)
        {
            _mapper = mapper;
            _phoneRepository = phoneRepository;
        }
        #endregion

        #region Implementations
        public async Task<GetPhoneResponse> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _phoneRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Phone).Name, "Item not found.");

                return _mapper.Map<GetPhoneResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetPhoneResponse> GetByCodeAsync(string code)
        {
            try
            {
                var entity = await _phoneRepository.GetAsync(x => x.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Phone).Name, "Item not found.");

                return _mapper.Map<GetPhoneResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> AddAsync(CreatePhoneRequest model)
        {
            try
            {
                var entity = _mapper.Map<Phone>(model);
                await _phoneRepository.AddAsync(entity);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateAsync(string code, UpdatePhoneRequest model)
        {
            try
            {
                var entity = await _phoneRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Phone).Name, "Item not found.");

                _mapper.Map(model, entity);

                await _phoneRepository.UpdateAsync(entity);

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
                var entity = await _phoneRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Phone).Name, "Item not found.");

                entity.Active = false;
                entity.DeletedAt = DateTime.UtcNow;

                await _phoneRepository.UpdateAsync(entity);

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
                var entity = await _phoneRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Phone).Name, "Item not found.");

                await _phoneRepository.DeleteAsync(entity);

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