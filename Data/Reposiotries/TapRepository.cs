using Domain.TapAggregate.Entities;
using Domain.TapAggregate.Repository;

namespace Data.Reposiotries
{
    public class TapRepository : Repository<Tap>, ITapRepository
    {
        public TapRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
