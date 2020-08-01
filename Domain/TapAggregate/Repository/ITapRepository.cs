using Domain.Interfaces;
using Domain.TapAggregate.Entities;

namespace Domain.TapAggregate.Repository
{
    public interface ITapRepository : IAsyncRepository<Tap>
    {
    }
}
