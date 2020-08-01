using Application.Models.Beverage;
using System.Threading.Tasks;

namespace Domain.BeverageAggregate.Interfaces
{
    public interface IBeverageAppService
    {
        Task<GetBeverageResponse> GetByIdAsync(int id);
        Task<GetBeverageResponse> GetByCodeAsync(string code);
        Task<bool> UpdateAsync(string code, UpdateBeverageRequest model);
        Task<GetBeverageResponse> AddAsync(CreateBeverageRequest model);
        Task<bool> LogicDeleteAsync(string code);
        Task<bool> DeleteAsync(int id);

        Task<GetBeveragePriceResponse> CreateBeveragePriceAsync(string code, CreateBeveragePriceRequest model);
    }
}