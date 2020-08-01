using Application.Models.Phone;
using System.Threading.Tasks;

namespace Domain.PhoneAggregate.Interfaces
{
    public interface IPhoneAppService
    {
        Task<GetPhoneResponse> GetByIdAsync(int id);
        Task<GetPhoneResponse> GetByCodeAsync(string code);
        Task<bool> UpdateAsync(string code, UpdatePhoneRequest model);
        Task<bool> AddAsync(CreatePhoneRequest model);
        Task<bool> LogicDeleteAsync(string code);
        Task<bool> DeleteAsync(int id);
    }
}