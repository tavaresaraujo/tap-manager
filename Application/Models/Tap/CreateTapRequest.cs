using System.ComponentModel.DataAnnotations;

namespace Application.Models.Tap
{
    public class CreateTapRequest
    {
        [Required, StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// Web location URL of the tap's server
        /// </summary>
        [Required]
        public string TargetUrl { get; set; }

        [Required]
        public string BeveragePriceCode { get; set; }
    }
}