using Domain.Interfaces;
using Domain.MerchantAggregate.Entities;

namespace Domain.MerchantAggregate.Repository
{
    public interface IMerchantRepository : IAsyncRepository<Merchant>
    {
    }
}
