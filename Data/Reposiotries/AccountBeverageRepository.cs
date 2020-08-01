using Domain.AccountAggregate.Entities;
using Domain.AccountAggregate.Repository;

namespace Data.Reposiotries
{
    public class AccountBeverageRepository : Repository<AccountBeverage>, IAccountBeverageRepository
    {
        public AccountBeverageRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
