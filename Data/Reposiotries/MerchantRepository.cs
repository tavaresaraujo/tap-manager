using Domain.MerchantAggregate.Entities;
using Domain.MerchantAggregate.Repository;

namespace Data.Reposiotries
{
    public class MerchantRepository : Repository<Merchant>, IMerchantRepository
    {
        public MerchantRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
