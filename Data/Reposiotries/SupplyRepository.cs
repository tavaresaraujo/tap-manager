using Domain.BeverageAggregate.Entities;
using Domain.BeverageAggregate.Repository;

namespace Data.Reposiotries
{
    public class SupplyRepository : Repository<Supply>, ISupplyRepository
    {
        public SupplyRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
