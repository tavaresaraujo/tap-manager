using Domain.AddressAggregate.Entities;
using Domain.AddressAggregate.Repository;

namespace Data.Reposiotries
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
