using Domain.Interfaces;
using Domain.UserAggregate.Entities;

namespace Domain.UserAggregate.Repository
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
