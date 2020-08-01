using System.ComponentModel.DataAnnotations;

namespace Application.Models.Address
{
    public class CreateAddressRequest
    {
        [Required]
        public int Number { get; set; }

        [Required, StringLength(128)]
        public string Name { get; set; }

        [Required, StringLength(64)]
        public string Street { get; set; }

        [Required, StringLength(2)]
        public string State { get; set; }

        [Required, StringLength(64)]
        public string City { get; set; }

        [Required, StringLength(64)]
        public string Neighborhood { get; set; }

        [Required, StringLength(16)]
        public string Zip { get; set; }

        [Required, StringLength(64)]
        public string Complement { get; set; }

        //Todo: criar enum
        [Required, StringLength(2)]
        public string Country { get; set; }
    }
}