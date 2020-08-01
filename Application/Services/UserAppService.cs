using Application.Helpers;
using Application.Interfaces;
using Application.Models.Consumption;
using Application.Models.Credit;
using Application.Models.User;
using AutoMapper;
using Domain.AccountAggregate.Entities;
using Domain.AddressAggregate.Entities;
using Domain.BeverageAggregate.Entities;
using Domain.Interfaces;
using Domain.PhoneAggregate.Entities;
using Domain.TapAggregate.Entities;
using Domain.UserAggregate.Entities;
using Domain.UserAggregate.Enumerations;
using Domain.UserAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserAppService : IUserAppService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IAsyncRepository<Credit> _creditRepository;
        private readonly IAsyncRepository<Address> _addressRepository;
        private readonly IAsyncRepository<Phone> _phoneRepository;
        private readonly IAsyncRepository<Consumption> _consumptionRepository;
        private readonly IAsyncRepository<Beverage> _beverageRepository;
        private readonly IAsyncRepository<Tap> _tapRepository;
        private readonly IAsyncRepository<Account> _accountRepository;
        private readonly IAsyncRepository<BeveragePrice> _beveragePriceRepository;

        private readonly ITransactionAppService _transactionAppService;
        #endregion

        #region Constructors
        public UserAppService(IMapper mapper, IAsyncRepository<User> userRepository, IAsyncRepository<Credit> creditRepository, IAsyncRepository<Address> addressRepository,
            IAsyncRepository<Phone> phoneRepository, IAsyncRepository<Consumption> consumptionRepository, IAsyncRepository<Beverage> beverageRepository, IAsyncRepository<Tap> tapRepository,
            IAsyncRepository<Account> accountRepository, IAsyncRepository<BeveragePrice> beveragePriceRepository, ITransactionAppService transactionAppService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _creditRepository = creditRepository;
            _addressRepository = addressRepository;
            _phoneRepository = phoneRepository;
            _consumptionRepository = consumptionRepository;
            _beverageRepository = beverageRepository;
            _tapRepository = tapRepository;
            _accountRepository = accountRepository;
            _beveragePriceRepository = beveragePriceRepository;

            _transactionAppService = transactionAppService;
        }
        #endregion

        #region Implmentations
        public async Task<GetUserResponse> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _userRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(User).Name, "Item not found.");

                return _mapper.Map<GetUserResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetUserResponse> GetByCodeAsync(string code)
        {
            try
            {
                var entity = await _userRepository.GetAsync(x => x.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(User).Name, "Item not found.");

                return _mapper.Map<GetUserResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetUserResponse> AddAsync(CreateUserRequest model)
        {
            try
            {
                //Todo: check if codes  exist       
                //Todo: implementar get id by code       
                var address = await _addressRepository.GetAsync(p => p.Code == model.AddressCode);
                var phone = await _phoneRepository.GetAsync(p => p.Code == model.PhoneCode);

                var entity = _mapper.Map<User>(model);

                entity.AddressId = address.Id;
                entity.PhoneId = phone.Id;

                var response = await _userRepository.AddAsync(entity);

                return _mapper.Map<GetUserResponse>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateAsync(string code, UpdateUserRequest model)
        {
            try
            {
                var entity = await _userRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(User).Name, "Item not found.");

                _mapper.Map(model, entity);

                await _userRepository.UpdateAsync(entity);

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
                var entity = await _userRepository.GetAsync(p => p.Code == code);
                if (entity == null)
                    throw new NotFoundException(typeof(User).Name, "Item not found.");

                entity.Active = false;
                entity.DeletedAt = DateTime.UtcNow;

                await _userRepository.UpdateAsync(entity);

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
                var entity = await _userRepository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException(typeof(User).Name, "Item not found.");

                await _userRepository.DeleteAsync(entity);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetCreditResponse> AddCreditAsync(string code, CreateCreditRequest model)
        {
            try
            {
                var user = await _userRepository.GetAsync(p => p.Code == code);
                if (user == null)
                    throw new KeyNotFoundException("Invalid user.");

                //create gateway transaction
                //var teste = new Transaction()
                //{
                //};

                //create credit
                var entity = _mapper.Map<Credit>(model);
                entity.UserId = user.Id;
                entity.Type = TypeEnum.Credit;
                var response = await _creditRepository.AddAsync(entity);

                user.Amount += model.Amount;
                await _userRepository.UpdateAsync(user);

                return _mapper.Map<GetCreditResponse>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GetConsumptionResponse> AddConsumptionAsync(string code, CreateConsumptionRequest model)
        {
            try
            {
                var user = await _userRepository.GetAsync(p => p.Code == code);
                var tap = await _tapRepository.GetAsync(p => p.Code == model.TapCode);
                if (tap == null)
                    throw new KeyNotFoundException("Invalid tap.");

                var beveragePrice = await _beveragePriceRepository.GetAsync(p => p.BeverageId == tap.BeveragePriceId);
                if (tap == null)
                    throw new KeyNotFoundException("Invalid beveragePrice.");

                if (tap.Volume - model.Volume < 0)
                    throw new KeyNotFoundException("Insufficient supply.");

                var entity = _mapper.Map<Consumption>(model);
                entity.BeveragePrice = beveragePrice;
                entity.User = user ?? throw new KeyNotFoundException("Invalid user.");

                var response = await _consumptionRepository.AddAsync(entity);

                //Todo: implementar supply
                //var amount = (model.Volume / 100) * beveragePrice.Amount;
                var amount = (model.Volume / 100) * beveragePrice.Amount;
                user.Amount -= amount;
                await _userRepository.UpdateAsync(user);

                //Create debit credit
                var credit = _mapper.Map<Credit>(new CreateCreditRequest() { Amount = amount });
                credit.Type = TypeEnum.Debit;
                credit.User = user;

                await _creditRepository.AddAsync(credit);

                return _mapper.Map<GetConsumptionResponse>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}