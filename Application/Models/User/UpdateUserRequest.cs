using System.ComponentModel.DataAnnotations;

namespace Application.Models.User
{
    public class UpdateUserRequest
    {
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [Required]
        public int AddressId { get; set; }

        [Required]
        public int PhoneId { get; set; }
    }
}