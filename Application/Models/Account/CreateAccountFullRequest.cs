using Application.Models.Address;
using Application.Models.Merchant;
using Application.Models.Phone;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Account
{
    public class CreateAccountFullRequest
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public CreateMerchantRequest Merchant { get; set; }

        [Required]
        public CreatePhoneRequest Phone { get; set; }

        [Required]
        public CreateAddressRequest Address { get; set; }
    }
}