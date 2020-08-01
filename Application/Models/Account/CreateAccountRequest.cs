using System.ComponentModel.DataAnnotations;

namespace Application.Models.Account
{
    public class CreateAccountRequest
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string MerchantCode { get; set; }

        [Required]
        public string AddressCode { get; set; }

        [Required]
        public string PhoneCode { get; set; }

        internal int MerchantId { get; set; }

        internal int AddressId { get; set; }

        internal int PhoneId { get; set; }
    }
}
