using Domain.UserAggregate.Entities;
using Domain.UserAggregate.Repository;

namespace Data.Reposiotries
{
    public class CreditRepository : Repository<Credit>, ICreditRepository
    {
        public CreditRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
