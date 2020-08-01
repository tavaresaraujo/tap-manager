using Domain.BeverageAggregate.Entities;

namespace Domain.AccountAggregate.Entities
{
    public class AccountBeverage : BaseEntity
    {
        public Account Account { get; set; }

        public BeveragePrice BeveragePrice { get; set; }

        public int AccountId { get; set; }

        public int BeveragePriceId { get; set; }
    }
}