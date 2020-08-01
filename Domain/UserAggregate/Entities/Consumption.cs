using Domain.BeverageAggregate.Entities;

namespace Domain.UserAggregate.Entities
{
    public class Consumption : BaseEntity
    {
        public int Volume { get; set; }

        public BeveragePrice BeveragePrice { get; set; }

        public User User { get; set; }

        public int BeveragePriceId { get; set; }

        public int UserId { get; set; }
    }
}