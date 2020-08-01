using System.ComponentModel.DataAnnotations;

namespace Application.Models.Consumption
{
    public class UpdateConsumptionRequest
    {
        [Required]
        public int Volume { get; set; }

        [Required]
        public int BeverageId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}