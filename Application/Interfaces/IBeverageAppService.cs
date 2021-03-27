using Application.Models.Beverage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.BeverageAggregate.Interfaces
{
    public interface IBeverageAppService
    {
        Task<List<GetBeverageResponse>> Get();
        Task<GetBeverageResponse> GetByIdAsync(int id);
        Task<GetBeverageResponse> GetByCodeAsync(string code);
        Task<bool> UpdateAsync(string code, UpdateBeverageRequest model);
        Task<GetBeverageResponse> AddAsync(CreateBeverageRequest model);
        Task<bool> LogicDeleteAsync(string code);
        Task<bool> DeleteAsync(int id);

        Task<GetBeveragePriceResponse> CreateBeveragePriceAsync(string code, CreateBeveragePriceRequest model);
    }
}