using System.ComponentModel.DataAnnotations;

namespace Application.Models.Beverage
{
    public class CreateBeverageRequest
    {
        [Required, StringLength(128)]
        public string Name { get; set; }

        [Required]
        public int AchoolPercentage { get; set; }

        /// <summary>
        /// What contry is
        /// </summary>
        public string Origin { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public int Amount { get; set; }
    }
}