using Domain.UserAggregate.Entities;
using Domain.UserAggregate.Repository;

namespace Data.Reposiotries
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
