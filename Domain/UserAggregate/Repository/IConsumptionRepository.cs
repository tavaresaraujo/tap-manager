using Domain.Interfaces;
using Domain.UserAggregate.Entities;

namespace Domain.UsereAggregate.Repository
{
    public interface IConsumptionRepository : IAsyncRepository<Consumption>
    {
    }
}
