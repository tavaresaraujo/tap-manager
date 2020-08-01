using Domain.AddressAggregate.Entities;
using Domain.Interfaces;

namespace Domain.AddressAggregate.Repository
{
    public interface IAddressRepository : IAsyncRepository<Address>
    {
    }
}