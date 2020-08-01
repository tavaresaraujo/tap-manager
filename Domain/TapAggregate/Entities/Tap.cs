using Domain.BeverageAggregate.Entities;
using Domain.TapAggregate.Enumerations;

namespace Domain.TapAggregate.Entities
{
    public class Tap : BaseEntity
    {
        public string Name { get; set; }

        /// <summary>
        /// Web location URL of the tap's server
        /// </summary>
        public string TargetUrl { get; set; }

        public int Volume { get; set; }

        public int BeveragePriceId { get; set; }

        public BeveragePrice BeveragePrice { get; set; }

        public StatusEnum Status { get; set; }
    }
}