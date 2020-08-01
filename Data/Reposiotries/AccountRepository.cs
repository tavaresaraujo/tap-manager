using Domain.AccountAggregate.Entities;
using Domain.AccountAggregate.Repository;

namespace Data.Reposiotries
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
