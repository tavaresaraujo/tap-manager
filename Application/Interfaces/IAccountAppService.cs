using Application.Models.Account;
using Application.Models.Address;
using Application.Models.Phone;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountAppService
    {
        Task<GetAccountResponse> GetByIdAsync(int id);
        Task<GetAccountResponse> GetByCodeAsync(string code);
        Task<bool> UpdateAsync(string code, UpdateAccountRequest model);
        Task<GetAccountResponse> AddAsync(CreateAccountRequest model);
        Task<GetAccountResponse> AddAsync(CreateAccountFullRequest model);
        Task<bool> LogicDeleteAsync(string code);
        Task<bool> DeleteAsync(int id);

        Task<bool> UpdatePhoneAsync(string code, UpdatePhoneRequest model);
        Task<bool> UpdateAddressAsync(string code, UpdateAddressRequest model);

        Task<GetAccountBeverageResponse> AddAccountBeverageAsync(string code, CreateAccountBeverageRequest model);
    }
}
