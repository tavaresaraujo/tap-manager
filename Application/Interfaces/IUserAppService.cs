using Application.Models.Consumption;
using Application.Models.Credit;
using Application.Models.User;
using System.Threading.Tasks;

namespace Domain.UserAggregate.Interfaces
{
    public interface IUserAppService
    {
        Task<GetUserResponse> GetByIdAsync(int id);
        Task<GetUserResponse> GetByCodeAsync(string code);
        Task<bool> UpdateAsync(string code, UpdateUserRequest model);
        Task<GetUserResponse> AddAsync(CreateUserRequest model);
        Task<bool> LogicDeleteAsync(string code);
        Task<bool> DeleteAsync(int id);

        Task<GetCreditResponse> AddCreditAsync(string code, CreateCreditRequest model);

        Task<GetConsumptionResponse> AddConsumptionAsync(string code, CreateConsumptionRequest model);
    }
}