using System.ComponentModel.DataAnnotations;

namespace Application.Models.Supply
{
    public class UpdateSupplyRequest
    {
        [Required]
        public int Volume { get; set; }

        public int TapCode { get; set; }
    }
}