using Application.Models.Tap;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.TapAggregate.Interfaces
{
    public interface ITapAppService
    {
        Task<List<GetTapResponse>> Get();
        Task<GetTapResponse> GetByIdAsync(int id);
        Task<GetTapResponse> GetByCodeAsync(string code);
        Task<bool> UpdateAsync(string code, UpdateTapRequest model);
        Task<GetTapResponse> AddAsync(CreateTapRequest model);
        Task<bool> LogicDeleteAsync(string code);
        Task<bool> DeleteAsync(int id);
    }
}
