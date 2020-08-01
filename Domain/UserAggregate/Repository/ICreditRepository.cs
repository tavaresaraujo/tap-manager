using Domain.Interfaces;
using Domain.UserAggregate.Entities;

namespace Domain.UserAggregate.Repository
{
    public interface ICreditRepository : IAsyncRepository<Credit>
    {
    }
}
