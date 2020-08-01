using Domain.TapAggregate.Repository;
using Domain.TransactionAggregate.Entities;

namespace Data.Reposiotries
{ 
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}