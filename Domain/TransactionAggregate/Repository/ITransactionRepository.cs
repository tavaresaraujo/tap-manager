using Domain.Interfaces;
using Domain.TransactionAggregate.Entities;

namespace Domain.TapAggregate.Repository
{
    public interface ITransactionRepository : IAsyncRepository<Transaction>
    {
    }
}
