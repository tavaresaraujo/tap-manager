using Domain.AddressAggregate.Entities;
using Domain.PhoneAggregate.Entities;

namespace Domain.UserAggregate.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public Phone Phone { get; set; }

        public int AddressId { get; set; }

        public int PhoneId { get; set; }

        /// <summary>
        /// (desnormalization) Credit amout desnormalization
        /// </summary>
        public int Amount { get; set; }
    }
}