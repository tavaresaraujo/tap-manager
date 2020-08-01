using Application.Models.Consumption;
using System.Threading.Tasks;

namespace Domain.BeverageAggregate.Interfaces
{
    public interface IConsumptionAppService
    {
        Task<GetConsumptionResponse> GetByIdAsync(int id);
        Task<GetConsumptionResponse> GetByCodeAsync(string code);
        Task<bool> UpdateAsync(string code, UpdateConsumptionRequest model);
        Task<GetConsumptionResponse> AddAsync(CreateConsumptionRequest model);
        Task<bool> LogicDeleteAsync(string code);
        Task<bool> DeleteAsync(int id);
    }
}
