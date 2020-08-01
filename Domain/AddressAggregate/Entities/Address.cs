namespace Domain.AddressAggregate.Entities
{
    public class Address : BaseEntity
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public string State { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Neighborhood { get; set; }

        public string Zip { get; set; }

        public string Complement { get; set; }

        public string Country { get; set; }
    }
}