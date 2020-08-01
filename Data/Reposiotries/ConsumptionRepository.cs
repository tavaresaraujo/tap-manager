using Domain.BeverageAggregate.Entities;
using Domain.BeverageAggregate.Repository;
using Domain.UserAggregate.Entities;
using Domain.UsereAggregate.Repository;

namespace Data.Reposiotries
{
    public class ConsumptionRepository : Repository<Consumption>, IConsumptionRepository
    {
        public ConsumptionRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
