using Domain.AccountAggregate.Entities;

namespace Domain.BeverageAggregate.Entities
{
    public class BeveragePrice : BaseEntity
    {
        public int Amount { get; set; }

        public int BeverageId { get; set; }

        public int AccountId { get; set; }

        public Beverage Beverage { get; set; }
    }
}