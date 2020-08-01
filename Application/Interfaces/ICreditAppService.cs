using Application.Models.Credit;
using System.Threading.Tasks;

namespace Domain.UserAggregate.Interfaces
{
    public interface ICreditAppService
    {
        Task<GetCreditResponse> GetByIdAsync(int id);
        Task<GetCreditResponse> GetByCodeAsync(string code);
        Task<bool> UpdateAsync(string code, UpdateCreditRequest model);
        Task<GetCreditResponse> AddAsync(CreateCreditRequest model);
        Task<bool> LogicDeleteAsync(string code);
        Task<bool> DeleteAsync(int id);
    }
}