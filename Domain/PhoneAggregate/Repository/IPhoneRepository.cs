using Domain.Interfaces;
using Domain.PhoneAggregate.Entities;

namespace Domain.PhoneAggregate.Repository
{
    public interface IPhoneRepository : IAsyncRepository<Phone>
    {
    }
}
