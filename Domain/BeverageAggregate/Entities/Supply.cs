using Domain.TapAggregate.Entities;

namespace Domain.BeverageAggregate.Entities
{
    public class Supply : BaseEntity
    {
        public int Volume { get; set; }

        public Tap Tap { get; set; }

        public int TapId { get; set; }
    }
}