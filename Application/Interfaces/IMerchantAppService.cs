using Application.Models.Merchant;
using System.Threading.Tasks;

namespace Domain.MerchantAggregate.Interfaces
{
    public interface IMerchantAppService
    {
        Task<GetMerchantResponse> GetByIdAsync(int id);
        Task<GetMerchantResponse> GetByCodeAsync(string code);
        Task<bool> UpdateAsync(string code, UpdateMerchantRequest model);
        Task<GetMerchantResponse> AddAsync(CreateMerchantRequest model);
        Task<bool> LogicDeleteAsync(string code);
        Task<bool> DeleteAsync(int id);
    }
}
