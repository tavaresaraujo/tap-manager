using System.ComponentModel.DataAnnotations;

namespace Application.Models.Supply
{
    public class CreateSupplyRequest
    {
        [Required]
        public int Volume { get; set; }

        [Required]
        public string TapCode { get; set; }

        internal int TapId { get; set; }
    }
}