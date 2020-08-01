using Domain.BeverageAggregate.Entities;
using Domain.Interfaces;

namespace Domain.BeverageAggregate.Repository
{
    public interface ISupplyRepository : IAsyncRepository<Supply>
    {
    }
}
