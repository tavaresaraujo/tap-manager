using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Credit;

namespace Application.Services
{
    public class TransactionAppService : ITransactionAppService
    {
        public Task<GetTransactionResponse> AddAsync(CreateTransactionRequest model)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetTransactionResponse> GetByCodeAsync(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetTransactionResponse> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> LogicDeleteAsync(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(string code, UpdateTransactionRequest model)
        {
            throw new System.NotImplementedException();
        }
    }
}
