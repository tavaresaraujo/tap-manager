using Domain.UserAggregate.Enumerations;

namespace Domain.UserAggregate.Entities
{
    public class Credit : BaseEntity
    {
        public int Amount { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public TypeEnum Type { get; set; }
    }
}