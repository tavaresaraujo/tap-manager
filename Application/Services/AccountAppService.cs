using Application.Helpers;
using Application.Interfaces;
using Application.Models.Account;
using Application.Models.Address;
using Application.Models.Merchant;
using Application.Models.Phone;
using AutoMapper;
using Domain.AccountAggregate.Entities;
using Domain.AddressAggregate.Entities;
using Domain.BeverageAggregate.Entities;
using Domain.BeverageAggregate.Interfaces;
using Domain.Interfaces;
using Domain.MerchantAggregate.Entities;
using Domain.PhoneAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Account> _accountRepository;
        private readonly IAsyncRepository<Merchant> _merchantRepository;
        private readonly IAsyncRepository<Phone> _phoneRepository;
        private readonly IAsyncRepository<Address> _addressRepository;
        private readonly IAsyncRepository<AccountBeverage> _accountBeverageRepository;
        private readonly IAsyncRepository<BeveragePrice> _beveragePriceRepository;
        private readonly IBeverageAppService _beverageAppService;
        #endregion

        #region Constructors
        public AccountAppService(IMapper mapper, IAsyncRepository<Account> accountRepository, IAsyncRepository<Merchant> merchantRepository, IAsyncRepository<Phone> phoneRepository,
            IAsyncRepository<Address> addressRepository, IBeverageAppService beverageAppService, IAsyncRepository<AccountBeverage> accountBeverageRepository, IAsyncRepository<BeveragePrice> beveragePriceRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _merchantRepository = merchantRepository;
            _phoneRepository = phoneRepository;
            _addressRepository = addressRepository;
            _beverageAppService = beverageAppService;
            _accountBeverageRepository = accountBeverageRepository;
            _beveragePriceRepository = beveragePriceRepository;
        }
        #endregion

        #region Implmentations
        public async Task<GetAccountResponse> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _accountRepository.GetByIdAsync(id);

                if (entity == null)
                    throw new NotFoundException(typeof(Account).Name, "Item not found.");

                return _mapper.Map<GetAccountResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetAccountResponse> GetByCodeAsync(string code)
        {
            try
            {
                var entity = await _accountRepository.GetAsync(x => x.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Account).Name, "Item not found.");

                //Todo: implementar UnprocessableEntityException
                entity.Merchant = await _merchantRepository.GetByIdAsync(entity.MerchantId);
                entity.Address = await _addressRepository.GetByIdAsync(entity.AddressId);
                entity.Phone = await _phoneRepository.GetByIdAsync(entity.PhoneId);

                return _mapper.Map<GetAccountResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetAccountResponse> AddAsync(CreateAccountRequest model)
        {
            try
            {
                //Todo: check if codes  exist       
                //Todo: implementar get id by code       
                var merchant = await _merchantRepository.GetAsync(p => p.Code == model.MerchantCode);
                var address = await _addressRepository.GetAsync(p => p.Code == model.AddressCode);
                var phone = await _phoneRepository.GetAsync(p => p.Code == model.PhoneCode);

                var entity = _mapper.Map<Account>(model);

                entity.MerchantId = merchant.Id;
                entity.AddressId = address.Id;
                entity.PhoneId = phone.Id;

                var response = await _accountRepository.AddAsync(entity);

                return _mapper.Map<GetAccountResponse>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetAccountResponse> AddAsync(CreateAccountFullRequest model)
        {
            try
            {
                var merchantEntity = _mapper.Map<Merchant>(model.Merchant);
                var phoneEntity = _mapper.Map<Phone>(model.Phone);
                var addressEntity = _mapper.Map<Address>(model.Address);
                var entity = _mapper.Map<Account>(model);

                //Todo: start transaction
                var merchant = await _merchantRepository.AddAsync(merchantEntity);
                var phone = await _phoneRepository.AddAsync(phoneEntity);
                var address = await _addressRepository.AddAsync(addressEntity);

                entity.MerchantId = merchant.Id;
                entity.PhoneId = phone.Id;
                entity.AddressId = address.Id;

                var response = await _accountRepository.AddAsync(entity);

                return _mapper.Map<GetAccountResponse>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateAsync(string code, UpdateAccountRequest model)
        {
            try
            {
                var entity = await _accountRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Account).Name, "Item not found.");

                _mapper.Map(model, entity);

                await _accountRepository.UpdateAsync(entity);

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
                var entity = await _accountRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(Account).Name, "Item not found.");

                entity.Active = false;
                entity.DeletedAt = DateTime.UtcNow;

                await _accountRepository.UpdateAsync(entity);

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
                var entity = await _accountRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(Account).Name, "Item not found.");

                await _accountRepository.DeleteAsync(entity);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateMerchantAsync(string code, UpdateMerchantRequest model)
        {
            try
            {
                var account = await _accountRepository.GetAsync(p => p.Code == code);
                var entity = await _merchantRepository.GetByIdAsync(account.MerchantId);

                if (entity == null)
                    throw new KeyNotFoundException("Invalid merchant.");

                _mapper.Map(model, entity);

                await _merchantRepository.UpdateAsync(entity);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdatePhoneAsync(string code, UpdatePhoneRequest model)
        {
            try
            {
                var account = await _accountRepository.GetAsync(p => p.Code == code);
                var entity = await _phoneRepository.GetByIdAsync(account.PhoneId);

                if (entity == null)
                    throw new KeyNotFoundException("Invalid phone.");

                _mapper.Map(model, entity);

                await _phoneRepository.UpdateAsync(entity);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateAddressAsync(string code, UpdateAddressRequest model)
        {
            try
            {
                var account = await _accountRepository.GetAsync(p => p.Code == code);
                var entity = await _addressRepository.GetByIdAsync(account.AddressId);
                if (entity == null)
                    throw new KeyNotFoundException("Invalid address.");

                _mapper.Map(model, entity);

                await _addressRepository.UpdateAsync(entity);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetAccountBeverageResponse> AddAccountBeverageAsync(string code, CreateAccountBeverageRequest model)
        {
            try
            {
                var account = await _accountRepository.GetAsync(p => p.Code == code);
                var beveragePrice = await _beveragePriceRepository.GetAsync(p => p.Code == model.BeveragePriceCode);
                var entity = _mapper.Map<AccountBeverage>(model);

                entity.Account = account ?? throw new KeyNotFoundException("Invalid account.");
                entity.BeveragePrice = beveragePrice ?? throw new KeyNotFoundException("Invalid beveragePrice.");

                var response = await _accountBeverageRepository.AddAsync(entity);

                return _mapper.Map<GetAccountBeverageResponse>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}