using Domain.AccountAggregate.Entities;
using Domain.Interfaces;

namespace Domain.AccountAggregate.Repository
{
    public interface IAccountBeverageRepository : IAsyncRepository<AccountBeverage>
    {
    }
}
