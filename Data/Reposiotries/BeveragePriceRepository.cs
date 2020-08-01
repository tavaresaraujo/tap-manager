using Domain.BeverageAggregate.Entities;
using Domain.BeverageAggregate.Repository;

namespace Data.Reposiotries
{
    public class BeveragePriceRepository : Repository<BeveragePrice>, IBeveragePriceRepository
    {
        public BeveragePriceRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
