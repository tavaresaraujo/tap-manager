using Domain.BeverageAggregate.Entities;
using Domain.BeverageAggregate.Repository;

namespace Data.Reposiotries
{
    public class BeverageRepository : Repository<Beverage>, IBeverageRepository
    {
        public BeverageRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}