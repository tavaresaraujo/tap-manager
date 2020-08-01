using Application.Models.Credit;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITransactionAppService
    {
        Task<GetTransactionResponse> GetByIdAsync(int id);
        Task<GetTransactionResponse> GetByCodeAsync(string code);
        Task<bool> UpdateAsync(string code, UpdateTransactionRequest model);
        Task<GetTransactionResponse> AddAsync(CreateTransactionRequest model);
        Task<bool> LogicDeleteAsync(string code);
        Task<bool> DeleteAsync(int id);
    }
}