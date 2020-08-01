using Domain.PhoneAggregate.Entities;
using Domain.PhoneAggregate.Repository;

namespace Data.Reposiotries
{
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        public PhoneRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
