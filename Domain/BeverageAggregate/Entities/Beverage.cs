namespace Domain.BeverageAggregate.Entities
{
    public class Beverage : BaseEntity
    {
        public string Name { get; set; }

        public int AchoolPercentage { get; set; }

        public string Origin { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
    }
}