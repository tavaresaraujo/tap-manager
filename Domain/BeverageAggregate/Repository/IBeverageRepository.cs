using Domain.BeverageAggregate.Entities;
using Domain.Interfaces;

namespace Domain.BeverageAggregate.Repository
{
    public interface IBeverageRepository : IAsyncRepository<Beverage>
    {
    }
}
