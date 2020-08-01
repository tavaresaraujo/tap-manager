using System.ComponentModel.DataAnnotations;

namespace Application.Models.Phone
{
    public class CreatePhoneRequest
    {
        [Required]
        public string Number { get; set; }

        [StringLength(128)]
        public string Discription { get; set; }
    }
}