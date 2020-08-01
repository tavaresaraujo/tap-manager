using System.ComponentModel.DataAnnotations;

namespace Application.Models.Consumption
{
    public class CreateConsumptionRequest
    {
        [Required]
        public int Volume { get; set; }

        [Required]
        public string TapCode { get; set; }
    }
}