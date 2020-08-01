using Application.Models.Address;
using System.Threading.Tasks;

namespace Domain.AddressAggregate.Interfaces
{
    public interface IAddressAppService
    {
        Task<GetAddressResponse> GetByIdAsync(int id);
        Task<GetAddressResponse> GetByCodeAsync(string code);
        Task<bool> UpdateAsync(string code, UpdateAddressRequest model);
        Task<GetAddressResponse> AddAsync(CreateAddressRequest model);
        Task<bool> LogicDeleteAsync(string code);
        Task<bool> DeleteAsync(int id);
    }
}