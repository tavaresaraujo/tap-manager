using Application.Helpers;
using Application.Models.Address;
using AutoMapper;
using Domain.AddressAggregate.Entities;
using Domain.AddressAggregate.Interfaces;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AddressAppService : IAddressAppService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Address> _addressRepository;
        #endregion

        #region Constructors
        public AddressAppService(IMapper mapper, IAsyncRepository<Address> addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }
        #endregion

        #region Implementations
        public async Task<GetAddressResponse> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _addressRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Address).Name, "Item not found.");

                return _mapper.Map<GetAddressResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetAddressResponse> GetByCodeAsync(string code)
        {
            try
            {
                var entity = await _addressRepository.GetAsync(x => x.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Address).Name, "Item not found.");

                return _mapper.Map<GetAddressResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetAddressResponse> AddAsync(CreateAddressRequest model)
        {
            try
            {
                var entity = _mapper.Map<Address>(model);
                var response = await _addressRepository.AddAsync(entity);

                return _mapper.Map<GetAddressResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateAsync(string code, UpdateAddressRequest model)
        {
            try
            {
                var entity = await _addressRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Address).Name, "Item not found.");

                _mapper.Map(model, entity);

                await _addressRepository.UpdateAsync(entity);

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
                var entity = await _addressRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Address).Name, "Item not found.");

                entity.Active = false;
                entity.DeletedAt = DateTime.UtcNow;

                await _addressRepository.UpdateAsync(entity);

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
                var entity = await _addressRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Address).Name, "Item not found.");

                await _addressRepository.DeleteAsync(entity);

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