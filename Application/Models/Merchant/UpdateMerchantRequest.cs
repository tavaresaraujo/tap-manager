using System.ComponentModel.DataAnnotations;

namespace Application.Models.Merchant
{
    public class UpdateMerchantRequest
    {
        //Todo: max legnth validations
        [Required, StringLength(128)]
        public string Name { get; set; }
    }
}