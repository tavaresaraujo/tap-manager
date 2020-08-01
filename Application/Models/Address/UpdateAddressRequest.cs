using System.ComponentModel.DataAnnotations;

namespace Application.Models.Address
{
    public class UpdateAddressRequest
    {
        [StringLength(128)]
        public string Name { get; set; }

        public int Number { get; set; }

        [StringLength(64)]
        public string Street { get; set; }

        [StringLength(64)]
        public string City { get; set; }

        [StringLength(64)]
        public string Complement { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [StringLength(64)]
        public string Neighborhood { get; set; }

        [StringLength(16)]
        public string Zip { get; set; }

        [StringLength(2)]
        public string Country { get; set; }
    }
}