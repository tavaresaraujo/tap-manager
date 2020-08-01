using System.ComponentModel.DataAnnotations;

namespace Application.Models.Tap
{
    public class UpdateTapRequest
    {
        [StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// Web location URL of the tap's server
        /// </summary>
        [Required]
        public string TargetUrl { get; set; }

        [Required]
        public int AddressId { get; set; }
    }
}