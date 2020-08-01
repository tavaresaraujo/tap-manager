using Application.Models.Supply;
using System.Threading.Tasks;

namespace Domain.BeverageAggregate.Interfaces
{
    public interface ISupplyAppService
    {
        Task<GetSupplyResponse> GetByIdAsync(int id);
        Task<GetSupplyResponse> GetByCodeAsync(string code);
        Task<bool> UpdateAsync(string code, UpdateSupplyRequest model);
        Task<GetSupplyResponse> AddAsync(CreateSupplyRequest model);
        Task<bool> LogicDeleteAsync(string code);
        Task<bool> DeleteAsync(int id);
    }
}