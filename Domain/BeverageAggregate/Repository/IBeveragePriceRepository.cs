using Domain.BeverageAggregate.Entities;
using Domain.Interfaces;

namespace Domain.BeverageAggregate.Repository
{
    public interface IBeveragePriceRepository : IAsyncRepository<BeveragePrice>
    {
    }
}
