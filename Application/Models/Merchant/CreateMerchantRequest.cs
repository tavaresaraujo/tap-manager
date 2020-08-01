using System.ComponentModel.DataAnnotations;

namespace Application.Models.Merchant
{
    public class CreateMerchantRequest
    {
        [Required, StringLength(128)]
        public string Name { get; set; }
    }
}