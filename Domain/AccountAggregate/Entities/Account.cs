using Domain.AddressAggregate.Entities;
using Domain.MerchantAggregate.Entities;
using Domain.PhoneAggregate.Entities;

namespace Domain.AccountAggregate.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }

        public Merchant Merchant { get; set; }

        public Address Address { get; set; }

        public Phone Phone { get; set; }

        public int MerchantId { get; set; }

        public int AddressId { get; set; }

        public int PhoneId { get; set; }
    }
}