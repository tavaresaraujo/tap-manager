using System.ComponentModel.DataAnnotations;

namespace Application.Models.Beverage
{
    public class UpdateBeverageRequest
    {
        [Required, StringLength(128)]
        public string Name { get; set; }

        [Required]
        public int AchoolPercentage { get; set; }

        public string Origin { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
    }
}