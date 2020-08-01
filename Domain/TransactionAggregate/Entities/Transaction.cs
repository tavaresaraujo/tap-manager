using Domain.UserAggregate.Entities;

namespace Domain.TransactionAggregate.Entities
{
    public class Transaction : BaseEntity
    {
        public string GatewayCode { get; set; }

        public int Amount { get; set; }

        public User User { get; set; }

        public int  UserId { get; set; }
    }
}