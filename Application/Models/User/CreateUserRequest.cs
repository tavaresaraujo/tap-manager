using System.ComponentModel.DataAnnotations;

namespace Application.Models.User
{
    public class CreateUserRequest
    {
        [Required, StringLength(128)]
        public string Name { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }

        [Required]
        public string AddressCode { get; set; }

        [Required]
        public string PhoneCode{ get; set; }

        internal int AddressId { get; set; }

        internal int PhoneId { get; set; }
    }
}